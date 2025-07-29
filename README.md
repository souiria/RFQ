# SEWSE.Commercial.SalesSystem

## CDb v2.0.0

1. Partials
   - Whenever there is a `Partials` folder, it contains partial classes that extend the functionality of the main classes.
   - Be careful in using the Sync Namespces, this will change the namespace of the partial class and that will break the code.
   - The areas where these partail classes are user are:
		- `namespace CDb.Endpoints.GrpcServices` for `CDbGrpcService` 
		- `namespace CDb.Services` for `CDbAccessDataService` and `SampleCDbAccessDataService`
