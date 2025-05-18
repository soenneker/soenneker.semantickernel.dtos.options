using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

namespace Soenneker.SemanticKernel.Dtos.Options;

/// <summary>
/// Options for creating a Microsoft.SemanticKernel.Kernel instance.
/// </summary>
public sealed class SemanticKernelOptions
{
    /// <summary>
    /// The model identifier (if applicable).
    /// </summary>
    public string? ModelId { get; set; }

    /// <summary>
    /// The endpoint (if applicable).
    /// </summary>
    public string? Endpoint { get; set; }

    /// <summary>
    /// The API key required to authenticate (if applicable).
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Optional asynchronous delegate to further configure the kernel after creation.
    /// </summary>
    public Func<Kernel, CancellationToken, ValueTask>? ConfigureKernel { get; set; }

    /// <summary>
    /// Optional delegate that creates a custom KernelBuilder.
    /// This delegate is always called (if provided) and allows you to inject connectors, plugins, etc.
    /// </summary>
    public Func<SemanticKernelOptions, CancellationToken, ValueTask<IKernelBuilder>>? KernelFactory { get; set; }

    /// <summary>
    /// Optional delegate to further customize the KernelBuilder before building the kernel.
    /// Leave unset if no additional configuration is needed.
    /// </summary>
    public Action<IKernelBuilder>? ConfigureBuilder { get; set; }
}
