# AI with DotNet (Cognitive Services)

Harness AI advanced capabilities with C#. The Pythonic version of this repository is [https://github.com/antazo/ai-python](here).

## Documentation

We created our ASP.NET Core project for Azure:

```powershell
dotnet new web -n azure
cd azure
```

After enabling unit tests to the project, add the references:

```powershell
dotnet add azureTest/azureTest.csproj reference azure/azure.csproj
```

Nuget needed for unit testing:

```powershell
https://api.nuget.org/v3/index.json
```

Libraries used in this project:

```powershell
# These are not compatible with net8.0
dotnet add package Figgle --version 0.5.1
dotnet add package ConsoleTables --version 2.4.2
```

More information:

* [Figgle](<https://github.com/drewnoakes/figgle)\
* [ConsoleTables](https://github.com/khalidabuhakmeh/ConsoleTables)

## Resources
