// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace Alimer.Bindings.WebGPU;

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUChainedStruct
{
	public unsafe WGPUChainedStruct* next;
	public WGPUSType sType;

}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUChainedStructOut
{
	public unsafe WGPUChainedStructOut* next;
	public WGPUSType sType;

}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUAdapterProperties
{
	public unsafe WGPUChainedStructOut* nextInChain;
	public uint vendorID;
	public unsafe sbyte* vendorName;
	public unsafe sbyte* architecture;
	public uint deviceID;
	public unsafe sbyte* name;
	public unsafe sbyte* driverDescription;
	public WGPUAdapterType adapterType;
	public WGPUBackendType backendType;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBindGroupEntry
{
	public unsafe WGPUChainedStruct* nextInChain;
	public uint binding;
	public WGPUBuffer buffer;
	public ulong offset;
	public ulong size;
	public WGPUSampler sampler;
	public WGPUTextureView textureView;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBlendComponent
{
	public WGPUBlendOperation operation;
	public WGPUBlendFactor srcFactor;
	public WGPUBlendFactor dstFactor;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBufferBindingLayout
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUBufferBindingType type;
	public bool hasDynamicOffset;
	public ulong minBindingSize;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBufferDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUBufferUsageFlags usage;
	public ulong size;
	public bool mappedAtCreation;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUColor
{
	public double r;
	public double g;
	public double b;
	public double a;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUCommandBufferDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUCommandEncoderDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUCompilationMessage
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* message;
	public WGPUCompilationMessageType type;
	public ulong lineNum;
	public ulong linePos;
	public ulong offset;
	public ulong length;
	public ulong utf16LinePos;
	public ulong utf16Offset;
	public ulong utf16Length;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUComputePassTimestampWrite
{
	public WGPUQuerySet querySet;
	public uint queryIndex;
	public WGPUComputePassTimestampLocation location;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUConstantEntry
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* key;
	public double value;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUExtent3D
{
	public uint width;
	public uint height;
	public uint depthOrArrayLayers;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUInstanceDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPULimits
{
	public uint maxTextureDimension1D;
	public uint maxTextureDimension2D;
	public uint maxTextureDimension3D;
	public uint maxTextureArrayLayers;
	public uint maxBindGroups;
	public uint maxBindingsPerBindGroup;
	public uint maxDynamicUniformBuffersPerPipelineLayout;
	public uint maxDynamicStorageBuffersPerPipelineLayout;
	public uint maxSampledTexturesPerShaderStage;
	public uint maxSamplersPerShaderStage;
	public uint maxStorageBuffersPerShaderStage;
	public uint maxStorageTexturesPerShaderStage;
	public uint maxUniformBuffersPerShaderStage;
	public ulong maxUniformBufferBindingSize;
	public ulong maxStorageBufferBindingSize;
	public uint minUniformBufferOffsetAlignment;
	public uint minStorageBufferOffsetAlignment;
	public uint maxVertexBuffers;
	public ulong maxBufferSize;
	public uint maxVertexAttributes;
	public uint maxVertexBufferArrayStride;
	public uint maxInterStageShaderComponents;
	public uint maxInterStageShaderVariables;
	public uint maxColorAttachments;
	public uint maxColorAttachmentBytesPerSample;
	public uint maxComputeWorkgroupStorageSize;
	public uint maxComputeInvocationsPerWorkgroup;
	public uint maxComputeWorkgroupSizeX;
	public uint maxComputeWorkgroupSizeY;
	public uint maxComputeWorkgroupSizeZ;
	public uint maxComputeWorkgroupsPerDimension;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUMultisampleState
{
	public unsafe WGPUChainedStruct* nextInChain;
	public uint count;
	public uint mask;
	public bool alphaToCoverageEnabled;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUOrigin3D
{
	public uint x;
	public uint y;
	public uint z;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUPipelineLayoutDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint bindGroupLayoutCount;
	public unsafe WGPUBindGroupLayout* bindGroupLayouts;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUPrimitiveDepthClipControl
{
	public WGPUChainedStruct chain;
	public bool unclippedDepth;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUPrimitiveState
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUPrimitiveTopology topology;
	public WGPUIndexFormat stripIndexFormat;
	public WGPUFrontFace frontFace;
	public WGPUCullMode cullMode;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUQuerySetDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUQueryType type;
	public uint count;
	public unsafe WGPUPipelineStatisticName* pipelineStatistics;
	public uint pipelineStatisticsCount;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUQueueDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderBundleDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderBundleEncoderDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint colorFormatsCount;
	public unsafe WGPUTextureFormat* colorFormats;
	public WGPUTextureFormat depthStencilFormat;
	public uint sampleCount;
	public bool depthReadOnly;
	public bool stencilReadOnly;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderPassDepthStencilAttachment
{
	public WGPUTextureView view;
	public WGPULoadOp depthLoadOp;
	public WGPUStoreOp depthStoreOp;
	public float depthClearValue;
	public bool depthReadOnly;
	public WGPULoadOp stencilLoadOp;
	public WGPUStoreOp stencilStoreOp;
	public uint stencilClearValue;
	public bool stencilReadOnly;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderPassDescriptorMaxDrawCount
{
	public WGPUChainedStruct chain;
	public ulong maxDrawCount;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderPassTimestampWrite
{
	public WGPUQuerySet querySet;
	public uint queryIndex;
	public WGPURenderPassTimestampLocation location;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURequestAdapterOptions
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUSurface compatibleSurface;
	public WGPUPowerPreference powerPreference;
	public bool forceFallbackAdapter;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSamplerBindingLayout
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUSamplerBindingType type;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSamplerDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUAddressMode addressModeU;
	public WGPUAddressMode addressModeV;
	public WGPUAddressMode addressModeW;
	public WGPUFilterMode magFilter;
	public WGPUFilterMode minFilter;
	public WGPUMipmapFilterMode mipmapFilter;
	public float lodMinClamp;
	public float lodMaxClamp;
	public WGPUCompareFunction compare;
	public ushort maxAnisotropy;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUShaderModuleCompilationHint
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* entryPoint;
	public WGPUPipelineLayout layout;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUShaderModuleSPIRVDescriptor
{
	public WGPUChainedStruct chain;
	public uint codeSize;
	public unsafe uint* code;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUShaderModuleWGSLDescriptor
{
	public WGPUChainedStruct chain;
	public unsafe sbyte* code;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUStencilFaceState
{
	public WGPUCompareFunction compare;
	public WGPUStencilOperation failOp;
	public WGPUStencilOperation depthFailOp;
	public WGPUStencilOperation passOp;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUStorageTextureBindingLayout
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUStorageTextureAccess access;
	public WGPUTextureFormat format;
	public WGPUTextureViewDimension viewDimension;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromAndroidNativeWindow
{
	public WGPUChainedStruct chain;
	public unsafe void* window;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromCanvasHTMLSelector
{
	public WGPUChainedStruct chain;
	public unsafe sbyte* selector;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromMetalLayer
{
	public WGPUChainedStruct chain;
	public unsafe void* layer;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromWaylandSurface
{
	public WGPUChainedStruct chain;
	public unsafe void* display;
	public unsafe void* surface;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromWindowsHWND
{
	public WGPUChainedStruct chain;
	public unsafe void* hinstance;
	public unsafe void* hwnd;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromXcbWindow
{
	public WGPUChainedStruct chain;
	public unsafe void* connection;
	public uint window;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSurfaceDescriptorFromXlibWindow
{
	public WGPUChainedStruct chain;
	public unsafe void* display;
	public uint window;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSwapChainDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUTextureUsageFlags usage;
	public WGPUTextureFormat format;
	public uint width;
	public uint height;
	public WGPUPresentMode presentMode;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUTextureBindingLayout
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUTextureSampleType sampleType;
	public WGPUTextureViewDimension viewDimension;
	public bool multisampled;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUTextureDataLayout
{
	public unsafe WGPUChainedStruct* nextInChain;
	public ulong offset;
	public uint bytesPerRow;
	public uint rowsPerImage;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUTextureViewDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUTextureFormat format;
	public WGPUTextureViewDimension dimension;
	public uint baseMipLevel;
	public uint mipLevelCount;
	public uint baseArrayLayer;
	public uint arrayLayerCount;
	public WGPUTextureAspect aspect;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUVertexAttribute
{
	public WGPUVertexFormat format;
	public ulong offset;
	public uint shaderLocation;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBindGroupDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUBindGroupLayout layout;
	public uint entryCount;
	public unsafe WGPUBindGroupEntry* entries;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBindGroupLayoutEntry
{
	public unsafe WGPUChainedStruct* nextInChain;
	public uint binding;
	public WGPUShaderStageFlags visibility;
	public WGPUBufferBindingLayout buffer;
	public WGPUSamplerBindingLayout sampler;
	public WGPUTextureBindingLayout texture;
	public WGPUStorageTextureBindingLayout storageTexture;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBlendState
{
	public WGPUBlendComponent color;
	public WGPUBlendComponent alpha;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUCompilationInfo
{
	public unsafe WGPUChainedStruct* nextInChain;
	public uint messageCount;
	public unsafe WGPUCompilationMessage* messages;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUComputePassDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint timestampWriteCount;
	public unsafe WGPUComputePassTimestampWrite* timestampWrites;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUDepthStencilState
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUTextureFormat format;
	public bool depthWriteEnabled;
	public WGPUCompareFunction depthCompare;
	public WGPUStencilFaceState stencilFront;
	public WGPUStencilFaceState stencilBack;
	public uint stencilReadMask;
	public uint stencilWriteMask;
	public int depthBias;
	public float depthBiasSlopeScale;
	public float depthBiasClamp;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUImageCopyBuffer
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUTextureDataLayout layout;
	public WGPUBuffer buffer;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUImageCopyTexture
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUTexture texture;
	public uint mipLevel;
	public WGPUOrigin3D origin;
	public WGPUTextureAspect aspect;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUProgrammableStageDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUShaderModule module;
	public unsafe sbyte* entryPoint;
	public uint constantCount;
	public unsafe WGPUConstantEntry* constants;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderPassColorAttachment
{
	public WGPUTextureView view;
	public WGPUTextureView resolveTarget;
	public WGPULoadOp loadOp;
	public WGPUStoreOp storeOp;
	public WGPUColor clearValue;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURequiredLimits
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPULimits limits;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUShaderModuleDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint hintCount;
	public unsafe WGPUShaderModuleCompilationHint* hints;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUSupportedLimits
{
	public unsafe WGPUChainedStructOut* nextInChain;
	public WGPULimits limits;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUTextureDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUTextureUsageFlags usage;
	public WGPUTextureDimension dimension;
	public WGPUExtent3D size;
	public WGPUTextureFormat format;
	public uint mipLevelCount;
	public uint sampleCount;
	public uint viewFormatCount;
	public unsafe WGPUTextureFormat* viewFormats;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUVertexBufferLayout
{
	public ulong arrayStride;
	public WGPUVertexStepMode stepMode;
	public uint attributeCount;
	public unsafe WGPUVertexAttribute* attributes;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUBindGroupLayoutDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint entryCount;
	public unsafe WGPUBindGroupLayoutEntry* entries;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUColorTargetState
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUTextureFormat format;
	public unsafe WGPUBlendState* blend;
	public WGPUColorWriteMaskFlags writeMask;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUComputePipelineDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUPipelineLayout layout;
	public WGPUProgrammableStageDescriptor compute;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUDeviceDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint requiredFeaturesCount;
	public unsafe WGPUFeatureName* requiredFeatures;
	public unsafe WGPURequiredLimits* requiredLimits;
	public WGPUQueueDescriptor defaultQueue;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderPassDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public uint colorAttachmentCount;
	public unsafe WGPURenderPassColorAttachment* colorAttachments;
	public unsafe WGPURenderPassDepthStencilAttachment* depthStencilAttachment;
	public WGPUQuerySet occlusionQuerySet;
	public uint timestampWriteCount;
	public unsafe WGPURenderPassTimestampWrite* timestampWrites;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUVertexState
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUShaderModule module;
	public unsafe sbyte* entryPoint;
	public uint constantCount;
	public unsafe WGPUConstantEntry* constants;
	public uint bufferCount;
	public unsafe WGPUVertexBufferLayout* buffers;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPUFragmentState
{
	public unsafe WGPUChainedStruct* nextInChain;
	public WGPUShaderModule module;
	public unsafe sbyte* entryPoint;
	public uint constantCount;
	public unsafe WGPUConstantEntry* constants;
	public uint targetCount;
	public unsafe WGPUColorTargetState* targets;
}

[StructLayout(LayoutKind.Sequential)]
public partial struct WGPURenderPipelineDescriptor
{
	public unsafe WGPUChainedStruct* nextInChain;
	public unsafe sbyte* label;
	public WGPUPipelineLayout layout;
	public WGPUVertexState vertex;
	public WGPUPrimitiveState primitive;
	public unsafe WGPUDepthStencilState* depthStencil;
	public WGPUMultisampleState multisample;
	public unsafe WGPUFragmentState* fragment;
}

