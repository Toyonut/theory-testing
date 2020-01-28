# App to test interfaces, database access in C# and learn dependency injection

App to start figuring out dependency injection, interfaces, Entity Framework and breaking up code in C#.
We have three persistence providers, in memory, file and DB based. They can be injected into the StorageMabob class through constructor injection to provide different ways to persist our strings and read them back.

This is currently running on dotnet core 3.1.101 on Pop_OS (Ubuntu) Linux with Postgres 10.10 from the default repos.

## Set up the DB and EF core tools

1. In your shell, install the ef tools with dotnet core 3.

    ``` bash
    dotnet tool install dotnet-ef --global
    ```

2. In Postgres, create a database user `testuser` with the password `testpassword` to match the connection string in `StorageModel.cs`.

    ``` sql
    CREATE USER testuser WITH PASSWORD testpassword;
    ```

3. In Postgres, create a database `testdb`.

    ``` sql
    CREATE DATABASE testdb;
    ```

4. In Postgres, grant `testuser` rights to the `testdb` database.

    ``` sql
    GRANT ALL ON DATABASE testdb TO testuser;
    GRANT ALL ON SCHEMA public TO testuser;
    ```

5. In your shell, run the migration to set up the database tables.

    ``` bash
    dotnet ef database update
    ```
