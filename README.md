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

## Docker

3. **Docker containers**
   - The sqlserver-container folder has a Docker configured image that allows the usage of a local dev sqlserver_service
    - The service can be accessed at `localhost:1433` with the credentials:
        - **User**: `dbdevusr`
        - **Password**: `OwnhjKZqZMCY0vL`
    - The database name is `testdb`
    - The postgres-container folder has a Docker configured image that allows the usage of a local dev postgres_service
    - The service can be accessed at `localhost:5432` with the credentials:
        - **User**: `dbdevusr`
        - **Password**: `OwnhjKZqZMCY0vL`
    - The database name is `testdb`
    - The python-container folder has a Docker configured image that allows the usage of a local dev python_container and this has the purpose to test the configuration of the two databases
    - The testing procedure is this:
        - Run the `docker-compose up` command in the terminal or in VSCode to start all the containers
        - Consirm the containers are running in the terminal with the command `docker ps` or with the script dic.ps1
        - dic.ps1 should show something like this:
            ```
            Container: python_container, IP: 172.25.0.4, Ports: 2222/tcp -> 127.0.0.1:2222
            Container: sqlserver_service, IP: 172.25.0.3, Ports: 1433/tcp -> 0.0.0.0:1433
            Container: postgresql_service, IP: 172.25.0.2, Ports: 5432/tcp -> 0.0.0.0:5432
            ```
        - Open a terminal in the python-container folder using `docker exec -it python_container /bin/bash`
        - Note that when root, the prompt is starts with `root@`; if console is at root, please witch to the limited user webd dev using `su - webdev`
        - In order to test the connectivity between the containers, you need to run two python scripts:
            ```
            root@741e51a4c390:~# su - webdev
            webdev@741e51a4c390:~$ cd share/
            webdev@741e51a4c390:~/share$ ls -al
            total 16
            drwxrwxrwx 1 webdev webdev  512 Aug 19 06:36 .
            drwxr-xr-x 6 webdev webdev 4096 Aug 19 10:44 ..
            -rwxrwxrwx 1 webdev webdev   24 Aug 18 11:26 test.txt
            -rwxrwxrwx 1 webdev webdev 4579 Aug 19 10:28 test_db_connection.py
            -rwxrwxrwx 1 webdev webdev 1896 Aug 19 06:37 test_network_connectivity.py
            webdev@741e51a4c390:~/share$ python test_network_connectivity.py 
            Testing network connectivity between containers...

            ✅ PostgreSQL Database (postgresql_service:5432) - Connection successful
            ✅ SQL Server Database (sqlserver_service:1433) - Connection successful

            ==================================================
            🎉 All connectivity tests passed!

            📋 Container network information:
            Current container: 741e51a4c390 (172.25.0.4)
            webdev@741e51a4c390:~/share$ python test_db_connection.py 
            --------------------------------------------------------------------------------
            Testing connection to PostgreSQL...
            Host: postgresql:5432
            Database: testdb
            User: dbdevusr
            --------------------------------------------------
            Testing with psycopg2...
            ✓ psycopg2 connection successful!
            PostgreSQL version: PostgreSQL 15.13 on x86_64-pc-linux-musl, compiled by gcc (Alpine 14.2.0) 14.2.0, 64-bit
            SQL Server version: Microsoft SQL Server 2022 (RTM-CU20) (KB5059390) - 16.0.4205.1 (X64)
                    Jun 13 2025 13:38:45
                    Copyright (C) 2022 Microsoft Corporation
                    Developer Edition (64-bit) on Linux (Ubuntu 22.04.5 LTS) <X64>
            Version info: product b'16.0.4205.1', level b'RTM', edition b'Developer Edition (64-bit)'

            Testing with SQLAlchemy...
            ✓ SQLAlchemy connection successful!
            Current database: testdb
            Current user: dbo
            --------------------------------------------------------------------------------

            🎉 All database connections working properly!
            ```
        - You now have aaccess setup between container
