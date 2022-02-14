# Medea
![tests](https://github.com/scato/medea/actions/workflows/push.yml/badge.svg)

My JSON database side project

# Dependencies
Medea depends on [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1) and runs on [MiniKube](https://minikube.sigs.k8s.io/docs/start/). MiniKube takes quite a bit of work to set up. If you are on Windows and unable to use Docker Desktop, I can only tell you Hyper-V is probably your best shot, and it will be a pain to set up.

## Running tests
To run the tests using MiniKube, run PowerShell as Administrator and call these scripts:

```
.\MiniKube\Setup.ps1
.\MiniKube\Test.ps1
```

Or, you can go to the directories and run the tests outside of MiniKube:

```
cd Test
dotnet test
cd ..\Spec
dotnet test
```

## Updating the parser

The parser is generated with [Hime](https://cenotelie.fr/projects/hime). There are several ways to install the
Hime SDK. One of them is by adding the "Hime Language Support" extension to Visual Studio Code. If you open the
grammar file, it will give you a tiny link called "Compile" on top of the page. Click this link to update the grammar.
