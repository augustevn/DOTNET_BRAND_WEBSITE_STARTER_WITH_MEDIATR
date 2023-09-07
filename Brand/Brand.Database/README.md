## Database

Create migration:

`dotnet ef migrations add InitialMigration --project ./Brand/Brand.Database --startup-project ./Brand/Brand.Api --context BrandDbContext`

Apply migrations:

`dotnet ef database update --project ./Brand/Brand.Database --startup-project ./Brand/Brand.Api --context BrandDbContext`

Remove migrations:

`dotnet ef migrations remove --project ./Brand/Brand.Database --startup-project ./Brand/Brand.Api --context BrandDbContext`

Drop database:

`dotnet ef database drop -f --project ./Brand/Brand.Database --startup-project ./Brand/Brand.Api --context BrandDbContext`