# AI with DotNet (Azure AI)

Harness AI advanced capabilities with C#. The Pythonic version of this repository is [here](https://github.com/antazo/ai-python).

## Installation

Clone (or fork) this git repository:

```bash
git clone https://github.com/antazo/ai-dotnet.git
cd ai-dotnet/azure
```

### Libraries

Libraries used in this project:

```powershell
dotnet add package Newtonsoft.Json
dotnet add package DotNetEnv
```

### Build and run

```powershell
dotnet build
dotnet run
```

Try it: <https://127.0.0.1/>

## Azure Portal

This application uses a valid subscription to Azure AI Services and Cognitive APIs to be able to use Language, Vision (Computer Vision, Custom Vision, Face), Decision, Speech, Metrics Advisor, and Document Intelligence.

Create a single resource for all of them, your Keys and Endpoints information must be stored in a **.env** file.

Note that the Translator service uses its own endpoint. Save your key-values like this:

```plaintext
LOCATION=
AI_SERVICES_KEY=
AI_SERVICES_ENDPOINT=
TRANSLATOR_ENDPOINT=https://api.cognitive.microsofttranslator.com/
```

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

## Resources
