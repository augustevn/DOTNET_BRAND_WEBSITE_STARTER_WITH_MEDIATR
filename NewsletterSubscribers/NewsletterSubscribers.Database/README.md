## Database

Create migration:

`dotnet ef migrations add InitialMigration --project ./NewsletterSubscribers/NewsletterSubscribers.Database --startup-project ./Brand/Brand.Api --context NewsletterSubscribersDbContext`

Apply migrations:

`dotnet ef database update --project ./NewsletterSubscribers/NewsletterSubscribers.Database --startup-project ./Brand/Brand.Api --context NewsletterSubscribersDbContext`

Remove migrations:

`dotnet ef migrations remove --project ./NewsletterSubscribers/NewsletterSubscribers.Database --startup-project ./Brand/Brand.Api --context NewsletterSubscribersDbContext`

Drop database:

`dotnet ef database drop -f --project ./NewsletterSubscribers/NewsletterSubscribers.Database --startup-project ./Brand/Brand.Api --context NewsletterSubscribersDbContext`