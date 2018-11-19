# HistoryTable
This solution shows the usage of [temporal tables](https://docs.microsoft.com/en-us/sql/relational-databases/tables/temporal-tables?view=sql-server-2017) in sql server 2016 and later.

The following techniques are demonstrated:
- Entity Framework Core (Context set up in the Startup class)
- Dependency Injection in the controller and Configure method in the Startup class
- SQL queries
- Resilient connections in EF Core.
- Temporal tables
- Docker (including docker-compose)

EF Core is used to create entities for the database. To keep it simple, only one record is used described by an entity that represents the amount of money on a bank account.
The history is stored by using a new features of SQL Server 2016. No queries are executed to save history. SQL Server does this for you by convention.

You may be surprised by the fact that SQL queries are used while we have EF. This is because temporal tables are not (fully) supported by EF. EF Core and SQL can be combined with the [FromSql](https://docs.microsoft.com/en-us/ef/core/querying/raw-sql#basic-raw-sql-queries) method introduced by EF Core 2.0 already.

Also [relient calls](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency) are done. This is to ensure queries work when they can work.

You do not need to install sql server yourself. Docker compose files describe all the dependencies so docker can resolve them and put each system dependency (sql server and the microservice) in a seperate container. 

Here is how you can get started

```bash
$ git clone https://github.com/ConnectingApps/HistoryTable.git
cd HistoryTable
docker-compose build
docker-compose up
```
Visit http://localhost:5982/swagger/



