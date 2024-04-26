# Minimal Repro for `System.IO.FileLoadException: Undefined resource string ID:0x80131621`

## Overview

Run `dotnet run --project FileNotFoundError`. Observe that `client.GetAsync` errors out with the following error message: `System.IO.FileLoadException: Undefined resource string ID:0x80131621`. This issue only occurs when **both conditions are true**:

1. Using a `HttpClient` created with a custom `HttpClientHandler` overriding `SendAsync` (even though the overriding method merely calls the base method and so it should technically be equivalent to not overriding the method).

2. Specifying `<InternalsVisibleTo>` in the `.csproj` file, where the `Include` property has a value with at least 1 `/` e.g. `../ProjectMoreThanOnePathAway`.
