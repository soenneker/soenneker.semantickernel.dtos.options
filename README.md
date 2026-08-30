[![](https://img.shields.io/nuget/v/soenneker.semantickernel.dtos.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.dtos.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.dtos.options/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.dtos.options/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.semantickernel.dtos.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.dtos.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.dtos.options/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.dtos.options/actions/workflows/codeql.yml)

# Soenneker.SemanticKernel.Dtos.Options

A shared configuration object for constructing Semantic Kernel instances and carrying model policy metadata.

## Installation

```bash
dotnet add package Soenneker.SemanticKernel.Dtos.Options
```

## Usage

```csharp
using Microsoft.SemanticKernel;
using Soenneker.SemanticKernel.Dtos.Options;
using Soenneker.SemanticKernel.Enums.KernelType;

var options = new SemanticKernelOptions
{
    ModelId = "primary-chat-model",
    Endpoint = "https://models.example.com",
    ApiKey = configuration["Models:ApiKey"],
    Type = KernelType.Chat,
    RequestsPerMinute = 60,
    TokensPerDay = 100_000,
    MaxTokens = 2_000,
    Temperature = 0.2,
    KernelFactory = static (options, cancellationToken) =>
    {
        IKernelBuilder builder = Kernel.CreateBuilder();

        // Add the connector for options.ModelId, Endpoint, and ApiKey.

        return ValueTask.FromResult(builder);
    },
    ConfigureBuilder = builder =>
    {
        // Add pre-build services or plugins.
    },
    ConfigureKernel = async (kernel, cancellationToken) =>
    {
        // Perform asynchronous post-build setup.
        await ValueTask.CompletedTask;
    }
};
```

## What applies the values

`SemanticKernelOptions` only stores values. It does not create a connector, enforce request/token limits, or apply `MaxTokens` and `Temperature` to execution settings by itself. The cache, pool, connector factory, or request pipeline consuming the options must implement those behaviors.

The three delegates define the construction hooks used by Soenneker Semantic Kernel caches and pools:

- `KernelFactory` creates an `IKernelBuilder` and receives the options plus cancellation token.
- `ConfigureBuilder` runs synchronously before the builder is built.
- `ConfigureKernel` runs asynchronously after the `Kernel` has been built.

When `KernelFactory` is absent, consumers may create an empty default builder. `ModelId`, `Endpoint`, and `ApiKey` are therefore not automatically meaningful unless the selected consumer or connector reads them.

## Serialization

The scalar configuration properties use explicit camel-case JSON names. `KernelFactory`, `ConfigureBuilder`, and `ConfigureKernel` are excluded from JSON because delegates cannot be represented as portable configuration.

`ApiKey` is included in JSON serialization. Do not serialize this object into logs, client responses, telemetry, or unprotected storage. Prefer resolving secrets from a protected configuration provider at the point where the options are built.

The DTO does not validate ranges or required combinations. Validate provider-specific requirements—such as a positive limit, supported temperature range, absolute endpoint, or required API key—before using the options.
