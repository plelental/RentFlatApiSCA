EF Core 2.2 commands for adding migrations and db update:

dotnet ef migrations add init -s ../RentFlatApi/ --context RentContext
dotnet ef database update -s ../RentFlatApi/ --context RentContext