# SEWSE.Commercial.SalesSystem

## Testing

1. **Categories**

```

        [Test]
        [Category("Unit")]
        [Category("Integration")]
        [Category("Regression")]
        [Category("Performance")]

```

   - Use the appropriate category attributes to classify tests.
   - Unit tests should focus on individual components, integration tests on interactions between components, and regression tests on ensuring existing functionality remains intact.

2. **Usings and global usings**
   - Include necessary namespaces for testing frameworks and project components in GlobalUsings.cs
```
global using NUnit.Framework;
global using Moq;
global using SEWSE.Commercial.SalesSystem;
global using SEWSE.Commercial.SalesSystem.Models;
global using SEWSE.Commercial.SalesSystem.Services;
```
   - Module specific usings go to each test file to maintain test isolation between modules
```
using CDb;
using CDb.Data.Context;
using CDb.Data.Model.Components;
using CDb.Data.Model.Masters;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Extensions;
using CDb.Services;
```

