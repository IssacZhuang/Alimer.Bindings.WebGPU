// Copyright (c) Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Text;
using CppAst;

namespace Generator;

public static partial class CsCodeGenerator
{
    private static readonly HashSet<string> s_outReturnFunctions =
    [
        "wgpuAdapterGetLimits",
        "wgpuAdapterGetProperties",
        "wgpuDeviceGetLimits",
        "wgpuSurfaceGetCapabilities",
        "wgpuSurfaceGetCurrentTexture",
    ];

    private static string GetFunctionPointerSignature(CppFunction function, bool canUseOut)
    {
        return GetFunctionPointerSignature(function.ReturnType, function.Parameters, canUseOut);
    }

    private static string GetFunctionPointerSignature(CppType returnType, CppContainerList<CppParameter> parameters, bool canUseOut)
    {
        StringBuilder builder = new();
        foreach (CppParameter parameter in parameters)
        {
            string paramCsType = GetCsTypeName(parameter.Type, false);

            if (canUseOut &&
                CanBeUsedAsOutput(parameter.Type, out CppTypeDeclaration? cppTypeDeclaration))
            {
                builder.Append("out ");
                paramCsType = GetCsTypeName(cppTypeDeclaration, false);
            }

            builder.Append(paramCsType).Append(", ");
        }

        string returnCsName = GetCsTypeName(returnType, false);
        builder.Append(returnCsName);

        return $"delegate* unmanaged<{builder}>";
    }

    private static void GenerateCommands(CppCompilation compilation)
    {
        string visibility = _options.PublicVisiblity ? "public" : "internal";

        // Generate Functions
        using CodeWriter writer = new(Path.Combine(_options.OutputPath, "Commands.cs"),
            true,
            _options.Namespace,
            ["System", "System.Runtime.InteropServices"]
            );

        // Generate callback
        foreach (CppTypedef typedef in compilation.Typedefs)
        {
            if (typedef.Name == "WGPUProc" ||
                typedef.Name == "WGPULogCallback" ||
                typedef.Name == "WGPUErrorCallback" ||
                !typedef.Name.EndsWith("Callback"))
            {
                continue;
            }

            if (typedef.ElementType is not CppPointerType pointerType)
            {
                continue;
            }

            CppFunctionType functionType = (CppFunctionType)pointerType.ElementType;

            //string functionPointerSignature = GetFunctionPointerSignature(functionType);
            //AddCsMapping(typedef.Name, functionPointerSignature);

            string returnCsName = GetCsTypeName(functionType.ReturnType, false);
            string argumentsString = GetParameterSignature(functionType, false);

            writer.WriteLine($"[UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
            writer.WriteLine($"{visibility} unsafe delegate {returnCsName} {typedef.Name}({argumentsString});");
            writer.WriteLine();
        }

        Dictionary<string, CppFunction> commands = new();
        foreach (CppFunction? cppFunction in compilation.Functions)
        {
            string? returnType = GetCsTypeName(cppFunction.ReturnType, false);
            string? csName = cppFunction.Name;

            commands.Add(csName, cppFunction);
        }

        using (writer.PushBlock($"{visibility} unsafe partial class {_options.ClassName}"))
        {

            foreach (KeyValuePair<string, CppFunction> command in commands)
            {
                CppFunction cppFunction = command.Value;
                bool canUseOut = s_outReturnFunctions.Contains(cppFunction.Name);

                if (_options.GenerateFunctionPointers)
                {
                    string functionPointerSignature = GetFunctionPointerSignature(cppFunction, false);
                    writer.WriteLine($"private static {functionPointerSignature} {command.Key}_ptr;");

                    if (canUseOut)
                    {
                        functionPointerSignature = GetFunctionPointerSignature(cppFunction, true);
                        writer.WriteLine($"private static {functionPointerSignature} {command.Key}_out_ptr;");
                    }
                }

                WriteFunctionInvocation(writer, cppFunction, _options.GenerateFunctionPointers, false);

                if(canUseOut)
                {
                    WriteFunctionInvocation(writer, cppFunction, _options.GenerateFunctionPointers, true);
                }
            }

            if (_options.GenerateFunctionPointers)
            {
                WriteCommands(writer, "GenLoadCommands", commands);
            }
        }
    }

    private static void WriteCommands(CodeWriter writer, string name, Dictionary<string, CppFunction> commands)
    {
        using (writer.PushBlock($"private static void {name}()"))
        {
            foreach (KeyValuePair<string, CppFunction> instanceCommand in commands)
            {
                string commandName = instanceCommand.Key;
                bool canUseOut = s_outReturnFunctions.Contains(instanceCommand.Value.Name);

                string functionPointerSignature = GetFunctionPointerSignature(instanceCommand.Value, false);

                writer.WriteLine($"{commandName}_ptr = ({functionPointerSignature}) LoadFunctionPointer(nameof({commandName}));");

                if (canUseOut)
                {
                    functionPointerSignature = GetFunctionPointerSignature(instanceCommand.Value, true);
                    writer.WriteLine($"{commandName}_out_ptr = ({functionPointerSignature}) load(context, nameof({commandName}));");
                }
            }
        }
    }

    private static void WriteFunctionInvocation(CodeWriter writer, CppFunction cppFunction, bool useFunctionPointers, bool canUseOut)
    {
        string returnCsName = GetCsTypeName(cppFunction.ReturnType, false);
        string argumentsString = GetParameterSignature(cppFunction, canUseOut);
        string functionName = cppFunction.Name;

        if (cppFunction.Name == "wgpuSetLogCallback")
        {
        }

        string modifier = "public static";
        if (!useFunctionPointers)
        {
            modifier += " partial";
            writer.WriteLine($"[LibraryImport(LibName, EntryPoint = \"{cppFunction.Name}\")]");
        }

        if (useFunctionPointers)
        {
            using (writer.PushBlock($"{modifier} {returnCsName} {functionName}({argumentsString})"))
            {
                if (returnCsName != "void")
                {
                    writer.Write("return ");
                }

                writer.Write($"{cppFunction.Name}_ptr(");

                int index = 0;
                foreach (CppParameter cppParameter in cppFunction.Parameters)
                {
                    string paramCsName = GetParameterName(cppParameter.Name);

                    if (CanBeUsedAsOutput(cppParameter.Type, out CppTypeDeclaration? cppTypeDeclaration))
                    {
                        writer.Write("out ");
                    }

                    writer.Write($"{paramCsName}");

                    if (index < cppFunction.Parameters.Count - 1)
                    {
                        writer.Write(", ");
                    }

                    index++;
                }

                writer.WriteLine(");");
            }
        }
        else
        {
            writer.WriteLine($"{modifier} {returnCsName} {functionName}({argumentsString});");
        }

        writer.WriteLine();

        if (returnCsName == "void" &&
            (cppFunction.Name.EndsWith("SetLabel") ||
            cppFunction.Name.EndsWith("InsertDebugMarker") ||
            cppFunction.Name.EndsWith("PushDebugGroup")
            ))
        {
            IEnumerable<CppParameter> parameters = cppFunction.Parameters.Take(cppFunction.Parameters.Count - 1);
            string paramCsName = GetParameterName(cppFunction.Parameters.Last().Name);
            argumentsString = GetParameterSignature(cppFunction.Name, parameters, false);

            using (writer.PushBlock($"public static void {cppFunction.Name}({argumentsString}, ReadOnlySpan<sbyte> {paramCsName})"))
            {
                string pointerName = "p" + char.ToUpperInvariant(paramCsName[0]) + paramCsName.Substring(1);
                using (writer.PushBlock($"fixed (sbyte* {pointerName} = {paramCsName})"))
                {
                    if (useFunctionPointers)
                    {
                        writer.Write($"{cppFunction.Name}_ptr(");
                    }
                    else
                    {
                        writer.Write($"{cppFunction.Name}(");
                    }

                    int index = 0;
                    foreach (CppParameter cppParameter in parameters)
                    {
                        string localParamCsName = GetParameterName(cppParameter.Name);

                        writer.Write($"{localParamCsName}");

                        if (index < cppFunction.Parameters.Count - 1)
                        {
                            writer.Write(", ");
                        }

                        index++;
                    }

                    writer.Write(pointerName);
                    writer.WriteLine(");");
                }
            }

            writer.WriteLine();

            using (writer.PushBlock($"public static void {cppFunction.Name}({argumentsString}, string? {paramCsName} = default)"))
            {
                string instanceParamName = GetParameterName(cppFunction.Parameters[0].Name);
                writer.WriteLine($"{cppFunction.Name}({instanceParamName}, {paramCsName}.GetUtf8Span());");
            }
            writer.WriteLine();
        }
    }

    public static string GetParameterSignature(CppFunction cppFunction, bool canUseOut, bool unsafeStrings = true)
    {
        return GetParameterSignature(cppFunction.Name, cppFunction.Parameters, canUseOut, unsafeStrings);
    }

    public static string GetParameterSignature(CppFunctionType cppFunctionType, bool canUseOut, bool unsafeStrings = true)
    {
        return GetParameterSignature(cppFunctionType.FullName, cppFunctionType.Parameters, canUseOut, unsafeStrings);
    }

    private static string GetParameterSignature(string functionName, IEnumerable<CppParameter> parameters, bool canUseOut, bool unsafeStrings = true)
    {
        StringBuilder argumentBuilder = new();
        int index = 0;

        if (functionName == "wgpuAdapterRequestDevice")
        {
        }

        foreach (CppParameter cppParameter in parameters)
        {

            string paramCsTypeName;
            string direction = string.Empty;
            // Callback parameters
            if (cppParameter.Type is CppTypedef typedef &&
                typedef.ElementType is CppPointerType pointerType &&
                pointerType.ElementType is CppFunctionType functionType)
            {
                paramCsTypeName = GetCallbackMemberSignature(functionType);
            }
            else
            {
                paramCsTypeName = GetCsTypeName(cppParameter.Type, false);
            }

            string paramCsName = GetParameterName(cppParameter.Name);

            //if (cppParameter.Name.EndsWith("Count"))
            //{
            //    if (functionName.StartsWith("vkEnumerate") ||
            //        functionName.StartsWith("vkGet"))
            //    {
            //        paramCsTypeName = "int*";
            //    }
            //    else
            //    {
            //        paramCsTypeName = "int";
            //    }
            //}

            if (paramCsName == "sbyte*" && unsafeStrings == false)
            {
                paramCsName = "ReadOnlySpan<sbyte>";
            }


            if (canUseOut && CanBeUsedAsOutput(cppParameter.Type, out CppTypeDeclaration? cppTypeDeclaration))
            {
                argumentBuilder.Append("out ");
                paramCsTypeName = GetCsTypeName(cppTypeDeclaration, false);
            }

            argumentBuilder.Append(paramCsTypeName).Append(' ').Append(paramCsName);

            if (paramCsTypeName == "nint" && paramCsName == "userdata")
            {
                argumentBuilder.Append(" = 0");
            }

            if (functionName.EndsWith("SetVertexBuffer") || functionName.EndsWith("SetIndexBuffer"))
            {
                if (paramCsName == "offset")
                {
                    argumentBuilder.Append(" = 0");
                }
                else if (paramCsName == "size")
                {
                    argumentBuilder.Append(" = WGPU_WHOLE_SIZE");
                }
            }

            if (functionName.EndsWith("Draw") ||
                functionName.EndsWith("DrawIndexed"))
            {
                if (paramCsName == "instanceCount")
                {
                    argumentBuilder.Append(" = 1");
                }
                else if (paramCsName == "firstVertex" ||
                    paramCsName == "firstIndex" ||
                    paramCsName == "baseVertex" ||
                    paramCsName == "firstInstance")
                {
                    argumentBuilder.Append(" = 0");
                }
            }

            if (index < parameters.Count() - 1)
            {
                argumentBuilder.Append(", ");
            }

            index++;
        }

        return argumentBuilder.ToString();
    }

    private static string GetParameterName(string name)
    {
        if (name == "event")
            return "@event";

        if (name == "object")
            return "@object";

        if (name.StartsWith('p')
            && char.IsUpper(name[1]))
        {
            name = char.ToLower(name[1]) + name.Substring(2);
            return GetParameterName(name);
        }

        return name;
    }

    private static string GetCallbackMemberSignature(CppFunctionType functionType)
    {
        StringBuilder builder = new();
        foreach (CppParameter parameter in functionType.Parameters)
        {
            string paramCsType = GetCsTypeName(parameter.Type, false);
            // Otherwise we get interop issues with non blittable types
            if (paramCsType == "WGPUBool")
                paramCsType = "uint";
            builder.Append(paramCsType).Append(", ");
        }

        string returnCsName = GetCsTypeName(functionType.ReturnType, false);
        // Otherwise we get interop issues with non blittable types
        if (returnCsName == "WGPUBool")
            returnCsName = "uint";

        builder.Append(returnCsName);

        return $"delegate* unmanaged<{builder}>";
    }

    private static bool CanBeUsedAsOutput(CppType type, out CppTypeDeclaration? elementTypeDeclaration)
    {
        if (type is CppPointerType pointerType)
        {
            if (pointerType.ElementType is CppTypedef typedef)
            {
                elementTypeDeclaration = typedef;
                return true;
            }
            else if (pointerType.ElementType is CppClass @class
                && @class.ClassKind != CppClassKind.Class
                && @class.SizeOf > 0)
            {
                elementTypeDeclaration = @class;
                return true;
            }
            else if (pointerType.ElementType is CppEnum @enum
                && @enum.SizeOf > 0)
            {
                elementTypeDeclaration = @enum;
                return true;
            }
        }

        elementTypeDeclaration = null;
        return false;
    }
}
