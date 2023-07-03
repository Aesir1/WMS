[![Continuous Integration and Deployment](https://github.com/Aesir1/WMS/actions/workflows/ci-cd.yaml/badge.svg)](https://github.com/Aesir1/WMS/actions/workflows/ci-cd.yaml)
# Warehouse Management System 
### What's an WMS?
A warehouse management system (WMS) consists of software and processes that allow organizations to control and administer warehouse operations from the time goods or materials enter a warehouse until they move out.
### What does this WMS do?
The purpose of a WMS is to help ensure that goods and materials move through warehouses in the most efficient and cost-effective way. 
This application handle the following aspects:
- Infrastructure management (Create, Modify and delete)
- Reception of goods
- Shipment of goods
- Internal shipments (between internal warehouses)
- Inventory
- Picking process
### Objectives:
This project has only **educational objectives** behind it. Through it will be applied the following list of contents
  - Clean code architecture design
  - Unit and Integration tests
  - Entity Framework Core 
  - REST & gRPC APIs
  - basic concepts from OOP and C# specifics concepts


### Migrations command
## Add a new migration and update db structure 
> dotnet ef migrations add ContextInjection  --startup-project WarehouseApp --project WarehouseInfrastructure --context WarehouseInfrastructure.Contexts.WarehouseDbContext
> 
> dotnet ef database update --startup-project WarehouseApp --project WarehouseInfrastructure --context WarehouseInfrastructure.Contexts.WarehouseDbContext

## Roll back to an old specifc migration and delete the last one
> dotnet ef database update <Migration>.<Name>  --startup-project WarehouseApp --project WarehouseInfrastructure --context WarehouseInfrastructure.Contexts.WarehouseDbContext
> 
> dotnet ef migrations remove --project WarehouseInfrastructure --context WarehouseDbContext --startup-project WarehouseApp
