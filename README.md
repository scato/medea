# Medea
![tests](https://github.com/scato/medea/actions/workflows/push.yml/badge.svg)

My JSON database side project

# Dependencies
Medea depends on [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1) and runs on [MiniKube](https://minikube.sigs.k8s.io/docs/start/). MiniKube takes quite a bit of work to set up, especially if it turns out your BIOS doesn't support Hypervisor.

FAIL: I can't get MiniKube to work because my laptop doesn't support virtualization :(

## Running tests
To run the tests using MiniKube, follow these steps:

```
minikube start
minikube kubectl -- ???
```
