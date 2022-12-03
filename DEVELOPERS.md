# User API Dev Guide
The ZipPay API is implemented using .NET Core 6 and MySQL as backend store.

## Building
1. Install .NET Core 6 in local and build agent
2. To build
```bash
dotnet build
```
3. Included nuget packages,
Microsoft.EntityFrameworkCore
Pomelo.EntityFrameworkCore.MySql
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools

## Testing
Unit tests are return in Xnuit. SO Make sure XUnit is installe din local and build agent.
```bash
dotnet build && dotnet test --logger xunit --results-directory ./reports/
```

## Integration Testing
Use fiddler/postman/etc to do integration cases. Attached sample postman tests, postman_integration_tests

## Deploying
To run
```bash
dotnet run TestProject.WebAPI.dll
```
1. Publish docker image to artifactory
2. Setup containerized virtualization using Rancher/KUBE to deploy and run.

# Contributing

## Contribution Process

### 1. Create your feature branch

```bash
git checkout -b my-new-feature
```

### 2. Commit your changes

If you have multiple commits, squash merge them into a single commit. This helps keep the history light. [Here's a nice guide](https://www.devroom.io/2011/07/05/git-squash-your-latests-commits-into-one/).

```bash
git commit -am 'Added some feature'
```

### 3. Push to the feature branch

```bash
git push origin my-new-feature
```

### 4. Create a Pull Request

## Contribution Guidelines

1. Coding style must match what exists in the project.
2. Must not contain any merge conflicts.
3. Include tests for the modifications in your commit.