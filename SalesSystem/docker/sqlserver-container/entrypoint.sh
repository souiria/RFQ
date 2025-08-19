#!/bin/bash

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait until SQL Server is ready
echo "Waiting for SQL Server to be available..."
until /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -Q "SELECT 1" > /dev/null 2>&1; do
  sleep 1
  echo "Still Waiting for SQL Server to be available..."
done

# Run your init script
echo "Running init.sql..."
/opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -i /db/init.sql
# echo "Finished running init.sql."


if [ $? -eq 0 ]; then
    echo "Database initialized successfully."
else
    echo "Database initialization failed."
    exit 1
fi
# Keep container alive
wait