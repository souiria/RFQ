# SEWSE.Commercial.SalesSystem

## Migrations and IDesign coding rules

1. **Migrations**:
   - Migrations are used to update the database schema.
   - **DO NOT** use the `Add-Migration` command in the Package Manager Console as this way build errors are hidden; use instead the terminal command `dotnet ef migrations add <migration_name>`.
   - Ensure that migrations are named appropriately to reflect the changes made.
	- This line needs to be added:
		`[System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "Generated file with wrong format for new object creation according to iDesign rules, even if the source code is conformant...")]`

## CDb v2.0.0

2. **Partials**
   - Whenever there is a `Partials` folder, it contains partial classes that extend the functionality of the main classes.
   - Be careful in using the Sync Namespaces, this will change the namespace of the partial class and that will break the code.
   - The areas where these partial classes are user are:
		- `namespace CDb.Endpoints.GrpcServices` for `CDbGrpcService` 
		- `namespace CDb.Services` for `CDbAccessDataService` and `SampleCDbAccessDataService`
