#!/bin/sh
set -e

# Read from environment variables (set by Docker Compose from .env)
DB_NAME="${DB_NAME:-testdb}"
DBDEV_USER="${DBDEV_USER:-dbdevusr}"
DBDEV_PASSWORD="${DBDEV_PASSWORD:-OwnhjKZqZMCY0vL}"

# Create user if it doesn't exist
psql -v ON_ERROR_STOP=1 -U postgres <<EOSQL
DO \$\$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_catalog.pg_roles WHERE rolname = '$DBDEV_USER') THEN
        EXECUTE format('CREATE ROLE %I WITH LOGIN PASSWORD %L', '$DBDEV_USER', '$DBDEV_PASSWORD');
        EXECUTE format('ALTER ROLE %I CREATEDB', '$DBDEV_USER');
        EXECUTE format('ALTER ROLE %I CREATEROLE', '$DBDEV_USER');
    END IF;
END
\$\$;
EOSQL

# Create database if it doesn't exist
psql -v ON_ERROR_STOP=1 -U postgres <<EOSQL
SELECT 'CREATE DATABASE $DB_NAME OWNER $DBDEV_USER'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = '$DB_NAME')\gexec
EOSQL

# Grant privileges and set up the database
psql -v ON_ERROR_STOP=1 -U postgres -d "$DB_NAME" <<EOSQL
DO \$\$
BEGIN
    GRANT ALL PRIVILEGES ON DATABASE $DB_NAME TO $DBDEV_USER;
    GRANT USAGE, CREATE ON SCHEMA public TO $DBDEV_USER;
    GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO $DBDEV_USER;
    GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO $DBDEV_USER;
    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON TABLES TO $DBDEV_USER;
    ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL ON SEQUENCES TO $DBDEV_USER;
END
\$\$;
EOSQL
