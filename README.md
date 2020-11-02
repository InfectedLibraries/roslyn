# Patholyn - A soft fork of the .NET Compiler Platform ("Roslyn")

[![MIT Licensed](https://img.shields.io/github/license/infectedlibraries/roslyn?style=flat-square)](LICENSE.txt)
[![Sponsor](https://img.shields.io/badge/sponsor-%E2%9D%A4-lightgrey?logo=github&style=flat-square)](https://github.com/sponsors/PathogenDavid)

This is a soft fork of Roslyn. It is primarily serves as a sandbox for testing out ideas for C#. All changes to the language are locked behind feature flags, meaning you can opt into them individually. (In theory anwyay, the way Roslyn is designed means mistakes could break expecations here.)

The intent is that eventually you'll be able to consume this compiler as a NuGet package and eventually we'll automatically keep pace with the Roslyn upstream using CI.

## Feature Flags

### `StructParameterlessConstructors`

This feature is similar to [dotnet/csharplang#99](https://github.com/dotnet/csharplang/issues/99)

This feature flag enables parameterless instance constructors on structs, for example:

```csharp
public struct MyStruct
{
    private string Message;

    public MyStruct()
        => Message = "Initialized from parameterless constructor.";

    public MyStruct(string message)
        => Message = message;

    public override string ToString()
        => Message ?? "Defaulted struct.";
}
```

The implementation of this feature is based on the cut C# 6 feature that [was removed](https://github.com/dotnet/roslyn/pull/1106) before Roslyn 1.0 was released.

(Note that the Visual Basic implementation of this feature was not restored.)

[Roslyn actually supports calling parameterless constructors on structs when they exist](https://github.com/PathogenPlayground/CSharpParameterlessStruct). So using this feature on public API does not make it incompatible with vanilla Roslyn. Parameterless constructors will be called as expected.

# Roslyn Readme

Past this point is the original Roslyn readme, unmodified.

<!-- Don't modify the original readme! Doing so makes it harder to merge changes. -->

----------------------------------

## Welcome to the .NET Compiler Platform ("Roslyn")

[![Join the chat at https://gitter.im/dotnet/roslyn](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/dotnet/roslyn?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) [![Chat on Discord](https://discordapp.com/api/guilds/143867839282020352/widget.png)](http://aka.ms/discord-csharp-roslyn)

Roslyn provides open-source C# and Visual Basic compilers with rich code analysis APIs.  It enables building code analysis tools with the same APIs that are used by Visual Studio.

### C# and Visual Basic Language Feature Suggestions

If you want to suggest a new feature for the C# or Visual Basic languages go here:
- [dotnet/csharplang](https://github.com/dotnet/csharplang) for C# specific issues
- [dotnet/vblang](https://github.com/dotnet/vblang) for VB-specific features
- [dotnet/csharplang](https://github.com/dotnet/csharplang) for features that affect both languages

## Contribute!

Some of the best ways to contribute are to try things out, file bugs, and join in design conversations. 

### Questions

A great way to get started is to ask some questions!
- Start with a question on [discussions](https://github.com/dotnet/roslyn/discussions)
- You can also join in on the design discussions on [gitter](https://gitter.im/dotnet/roslyn) or [discord](http://aka.ms/discord-csharp-roslyn)

### See if your issue is already being worked on! (Add your own votes using the 👍 reaction)
- [IDE](https://aka.ms/roslyn-ide-in-progress)
- [Compiler](https://aka.ms/roslyn-compiler-in-progress)

### Vote in the Backlog! (Add your own votes using the 👍 reaction)
- [IDE Bugs](https://aka.ms/roslyn-ide-bug-backlog)
- [IDE Features](https://aka.ms/roslyn-ide-feature-backlog)
- [Compiler Bugs](https://aka.ms/roslyn-compiler-bug-backlog)
- [Compiler Features](https://aka.ms/roslyn-compiler-features-backlog)

### Find a bug to fix! (Add your own votes using the 👍 reaction)
- First read this guide: [How to Contribute](docs/wiki/Contributing-Code.md)
- [Building, testing and debugging the sources](docs/wiki/Building-Testing-and-Debugging.md)
- Top Bugs 
  - [IDE](https://aka.ms/roslyn-ide-bugs-help-wanted)
  - [Compiler](https://aka.ms/roslyn-compiler-bugs-help-wanted)

### Find a feature to implement! (Add your own votes using the 👍 reaction)
- [IDE](https://aka.ms/roslyn-ide-feature-help-wanted)
- [Compiler](https://aka.ms/roslyn-compiler-feature-help-wanted)


### Getting started with the Roslyn APIs

If you want to get started using Roslyn's APIs to analyzer your code take a look at these links:
- [Roslyn Architecture Overview](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/compiler-api-model) 
  - [Syntax APIs](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/work-with-syntax)
  - [Semantic APIs](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/work-with-semantics)
  - [Workspace APIs](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/work-with-workspace)
- [Tutorial: Write your first analyzer and code fix](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix)
- Useful Tools
  - [Syntax Visualizer Tool](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/syntax-visualizer)
  - [Syntax Quoter Tool](http://roslynquoter.azurewebsites.net)
  - Browse the source with the [enhanced source view](http://sourceroslyn.io/)

**The latest pre-release builds** are available from the following public NuGet feeds: 
- [Compiler](https://dev.azure.com/dnceng/public/_packaging?_a=feed&feed=dotnet-tools): `https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json`
- [IDE Services](https://dev.azure.com/azure-public/vside/_packaging?_a=feed&feed=vssdk): `https://pkgs.dev.azure.com/azure-public/vside/_packaging/vssdk/nuget/v3/index.json`
- [.NET SDK](https://dev.azure.com/dnceng/public/_packaging?_a=feed&feed=dotnet5): `https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json`

[//]: # (Begin current test results)

### Continuous Integration status

#### Desktop Unit Tests
|Branch|Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|
**master**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20debug_32&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20debug_64&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20release_32&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20release_64&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|
**master-vs-deps**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20debug_32&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20debug_64&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20release_32&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Desktop_Unit_Tests&configuration=Windows_Desktop_Unit_Tests%20release_64&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|

#### CoreClr Unit Tests
|Branch|Windows Debug|Windows Release|Linux|
|:--:|:--:|:--:|:--:|
**master**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_CoreClr_Unit_Tests&configuration=Windows_CoreClr_Unit_Tests%20debug&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_CoreClr_Unit_Tests&configuration=Windows_CoreClr_Unit_Tests%20release&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Linux_Test&configuration=Linux_Test%20coreclr&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|
**master-vs-deps**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_CoreClr_Unit_Tests&configuration=Windows_CoreClr_Unit_Tests%20debug&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_CoreClr_Unit_Tests&configuration=Windows_CoreClr_Unit_Tests%20release&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Linux_Test&configuration=Linux_Test%20coreclr&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|

#### Integration Tests
|Branch|Debug|Release
|:--:|:--:|:--:|
**master**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-integration-CI?branchname=master&jobname=VS_Integration&configuration=VS_Integration%20debug_async&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=245&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-integration-CI?branchname=master&jobname=VS_Integration&configuration=VS_Integration%20release_async&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=245&branchname=master&view=logs)|
**master-vs-deps**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-integration-CI?branchname=master-vs-deps&jobname=VS_Integration&configuration=VS_Integration%20debug_async&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=245&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-integration-CI?branchname=master-vs-deps&jobname=VS_Integration&configuration=VS_Integration%20release_async&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=245&branchname=master-vs-deps&view=logs)|

#### Misc Tests
|Branch|Determinism|Build Correctness|Spanish|Mono|
|:--:|:--:|:--:|:--:|:--:|
**master**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Determinism_Test&configuration=Windows_Determinism_Test&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Correctness_Test&configuration=Windows_Correctness_Test&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Windows_Desktop_Spanish_Unit_Tests&configuration=Windows_Desktop_Spanish_Unit_Tests&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master&jobname=Linux_Test&configuration=Linux_Test%20mono&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master&view=logs)|
**master-vs-deps**|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Determinism_Test&configuration=Windows_Determinism_Test&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Correctness_Test&configuration=Windows_Correctness_Test&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Windows_Desktop_Spanish_Unit_Tests&configuration=Windows_Desktop_Spanish_Unit_Tests&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|[![Build Status](https://dev.azure.com/dnceng/public/_apis/build/status/dotnet/roslyn/roslyn-CI?branchname=master-vs-deps&jobname=Linux_Test&configuration=Linux_Test%20mono&label=build)](https://dev.azure.com/dnceng/public/_build/latest?definitionId=15&branchname=master-vs-deps&view=logs)|

[//]: # (End current test results)

This [project](CODE-OF-CONDUCT.md) has adopted the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

### .NET Foundation

This project is part of the [.NET Foundation](http://www.dotnetfoundation.org/projects) along with other
projects like [the .NET Runtime](https://github.com/dotnet/runtime/).
