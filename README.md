# DevOpsTools

## Getting started

1. Create an appsettings.json file like this in the root folder:

```json
{
  "DevOpsSettings":
  {
    "BaseAddress": "https://somedevsopsurl/",
    "PersonalAccessToken": "your devops personal access token here",
    "CurrentProject": "The project you want to retreive information from",
    "Top": 10
  }
}
```

## Links

- Inspired by and used some code from [AnyStatus](https://github.com/AnyStatus/AzureDevOps).
- Used [this](https://github.com/garoyeri/sample-console-app-net-core-01) repository as an inspiration for the console application.