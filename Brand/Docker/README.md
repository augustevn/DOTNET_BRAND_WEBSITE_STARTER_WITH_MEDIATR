

## Database

First time ever with MSSQL image (accept EULA):
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<pw-in-docker-compose>" -p "127.0.0.1:1436:1433" --name MSSQL_BRAND -d mcr.microsoft.com/mssql/server:2017-latest
```

Commands:

```
docker-compose -f ./Docker/docker-compose.yml -p brand up -d
docker-compose -f ./Docker/docker-compose.yml -p brand stop
```

Connect:

```
User=sa
Host=127.0.0.1
Database=brand
```
Database `brand` becomes available after first database update. Before that, the only existing database is `master`.

## Back-ups

1. Export database from Azure Portal into Blob storage.
    1. Or use Azure Data Studio > Data-tier Application Wizard.
2. LOCAL restore: use Azure Data Studio > Data-tier Application Wizard.
    2. Create database from .bacpac
3. PROD restore: use Azure Portal + Blob storage to restore from.

Sources:

- https://www.sqlservercentral.com/articles/sql-server-dacpac-in-azure-data-studio
- https://docs.docker.com/compose/aspnet-mssql-compose/
- https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/database-server-container
- https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-configure-environment-variables?view=sql-server-2017