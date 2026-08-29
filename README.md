[![](https://img.shields.io/nuget/v/soenneker.semantickernel.dtos.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.dtos.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.dtos.options/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.dtos.options/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.semantickernel.dtos.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.dtos.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.dtos.options/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.dtos.options/actions/workflows/codeql.yml)

# Soenneker.SemanticKernel.Dtos.Options

Options for creating a Microsoft.SemanticKernel.Kernel instance.

## Install

```bash
dotnet add package Soenneker.SemanticKernel.Dtos.Options
```

## What you get

- `SemanticKernelOptions` — Options for creating a Microsoft.SemanticKernel.Kernel instance.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `SemanticKernelOptions.ModelId` | The model identifier (if applicable). | The model identifier (if applicable). |
| `SemanticKernelOptions.Endpoint` | The endpoint (if applicable). | The endpoint (if applicable). |
| `SemanticKernelOptions.ApiKey` | The API key required to authenticate (if applicable). | The API key required to authenticate (if applicable). |
| `SemanticKernelOptions.Type` | The type of kernel to use, such as Chat, Completion, Embedding, Image, etc. Determines how the model is initialized and what capabilities it provides. | The type of kernel to use, such as Chat, Completion, Embedding, Image, etc. Determines how the model is initialized and what capabilities it provides. |
| `SemanticKernelOptions.ConfigureKernel` | Optional asynchronous delegate to further configure the kernel after creation. | Optional asynchronous delegate to further configure the kernel after creation. |
| `SemanticKernelOptions.KernelFactory` | Optional delegate that creates a custom KernelBuilder. This delegate is always called (if provided) and allows you to inject connectors, plugins, etc. | Optional delegate that creates a custom KernelBuilder. This delegate is always called (if provided) and allows you to inject connectors, plugins, etc. |
| `SemanticKernelOptions.ConfigureBuilder` | Optional delegate to further customize the KernelBuilder before building the kernel. Leave unset if no additional configuration is needed. | Optional delegate to further customize the KernelBuilder before building the kernel. Leave unset if no additional configuration is needed. |
| `SemanticKernelOptions.RequestsPerSecond` | Maximum number of requests allowed per second. Used for rate limiting. | Maximum number of requests allowed per second. Used for rate limiting. |
| `SemanticKernelOptions.RequestsPerMinute` | Maximum number of requests allowed per minute. Used for rate limiting. | Maximum number of requests allowed per minute. Used for rate limiting. |
| `SemanticKernelOptions.RequestsPerDay` | Maximum number of requests allowed per day. Used for rate limiting. | Maximum number of requests allowed per day. Used for rate limiting. |
| `SemanticKernelOptions.TokensPerDay` | Maximum number of tokens allowed per day (input + output). Used for quota control. | Maximum number of tokens allowed per day (input + output). Used for quota control. |
| `SemanticKernelOptions.TokensPerMinute` | Maximum number of tokens allowed per minute (optional). Used for burst control. | Maximum number of tokens allowed per minute (optional). Used for burst control. |
| `SemanticKernelOptions.MaxTokens` | The maximum number of tokens the model is allowed to generate in a single response. | The maximum number of tokens the model is allowed to generate in a single response. |
| `SemanticKernelOptions.Temperature` | Sampling temperature (0.0 - 2.0). Higher values produce more randomness; lower values are more deterministic. | Sampling temperature (0.0 - 2.0). Higher values produce more randomness; lower values are more deterministic. |
