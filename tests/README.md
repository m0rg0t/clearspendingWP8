# Search query regression checks

Run from repository root with the .NET 10 SDK:

```sh
dotnet run --project tests/Portable.Tests/Portable.Tests.csproj --configuration Release
```

Links the actual SDK Models/SearchParamItem.cs. An empty ViewModelBase test stand-in suffices because these parameter types invoke no MVVM methods. Every string-valued customer, supplier and contract filter is tested with Unicode and reserved delimiters, decoded round-trip, and checked for injected page parameters. Default pagination, omission of empty filters and top-level search routing are covered. Original source splits namesearch at the first ampersand and leaks page=999 into the query.

The harness has no NuGet package dependencies and clears package sources in its own NuGet.Config. It is a separate modern test host, not a port or a whole-app build. Stubs are test-only and are not included in the legacy project. Only synthetic fixtures are used; no HTTP requests, device access, capture, user data or credentials.

Still unvalidated: Windows Phone 8 SDK, PCL Profile78 restore/build, Telerik and MVVM Light binding, historic API availability and service behavior. Original target, dependency manifests and binary references are preserved. Dependency upgrades require a compatible historical restore/build baseline; this PR does not claim modernized dependencies or a functioning remote service.
