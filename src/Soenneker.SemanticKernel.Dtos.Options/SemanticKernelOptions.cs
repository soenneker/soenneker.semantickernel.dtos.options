using Microsoft.SemanticKernel;
using Soenneker.SemanticKernel.Enums.KernelType;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.SemanticKernel.Dtos.Options;

/// <summary>
/// Options for creating a Microsoft.SemanticKernel.Kernel instance.
/// </summary>
public sealed class SemanticKernelOptions
{
    /// <summary>
    /// The model identifier (if applicable).
    /// </summary>
    [JsonPropertyName("modelId")]
    public string? ModelId { get; set; }

    /// <summary>
    /// The endpoint (if applicable).
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    /// <summary>
    /// The API key required to authenticate (if applicable).
    /// </summary>
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    /// <summary>
    /// The type of kernel to use, such as Chat, Completion, Embedding, Image, etc. 
    /// Determines how the model is initialized and what capabilities it provides.
    /// </summary>
    [JsonPropertyName("type")]
    public KernelType? Type { get; set; }

    /// <summary>
    /// Optional asynchronous delegate to further configure the kernel after creation.
    /// </summary>
    [JsonIgnore]
    public Func<Kernel, CancellationToken, ValueTask>? ConfigureKernel { get; set; }

    /// <summary>
    /// Optional delegate that creates a custom KernelBuilder.
    /// This delegate is always called (if provided) and allows you to inject connectors, plugins, etc.
    /// </summary>
    [JsonIgnore]
    public Func<SemanticKernelOptions, CancellationToken, ValueTask<IKernelBuilder>>? KernelFactory { get; set; }

    /// <summary>
    /// Optional delegate to further customize the KernelBuilder before building the kernel.
    /// Leave unset if no additional configuration is needed.
    /// </summary>
    [JsonIgnore]
    public Action<IKernelBuilder>? ConfigureBuilder { get; set; }

    // ---------- Rate limits (usage windows) ----------

    /// <summary>
    /// Maximum number of requests allowed per second. Used for rate limiting.
    /// </summary>
    [JsonPropertyName("requestsPerSecond")]
    public int? RequestsPerSecond { get; set; }

    /// <summary>
    /// Maximum number of requests allowed per minute. Used for rate limiting.
    /// </summary>
    [JsonPropertyName("requestsPerMinute")]
    public int? RequestsPerMinute { get; set; }

    /// <summary>
    /// Maximum number of requests allowed per day. Used for rate limiting.
    /// </summary>
    [JsonPropertyName("requestsPerDay")]
    public int? RequestsPerDay { get; set; }

    /// <summary>
    /// Maximum number of tokens allowed per day (input + output). Used for quota control.
    /// </summary>
    [JsonPropertyName("tokensPerDay")]
    public int? TokensPerDay { get; set; }

    /// <summary>
    /// Maximum number of tokens allowed per minute (optional). Used for burst control.
    /// </summary>
    [JsonPropertyName("tokensPerMinute")]
    public int? TokensPerMinute { get; set; }

    // ---------- Generation parameters (applied per request) ----------

    /// <summary>
    /// The maximum number of tokens the model is allowed to generate in a single response.
    /// </summary>
    [JsonPropertyName("maxTokens")]
    public int? MaxTokens { get; set; }

    /// <summary>
    /// Sampling temperature (0.0 - 2.0). Higher values produce more randomness; lower values are more deterministic.
    /// </summary>
    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }
}
