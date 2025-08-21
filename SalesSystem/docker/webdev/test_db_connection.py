#!/usr/bin/env python3
"""
PostgreSQL connection test script for the webdev container
"""
import os
import psycopg2
import pymssql
from sqlalchemy import create_engine, text
import sys

def test_mssql_connection():
    """Test connection to MSSqlServer database"""
    
    # Get connection parameters from environment variables
    db_host = os.getenv('DB_SQLSERVER_HOST', 'sqlserver')
    db_port = os.getenv('DB_SQLSERVER_PORT', '1433')
    db_name = os.getenv('DB_SQLSERVER_NAME', 'testdb')
    db_user = os.getenv('DB_SQLSERVER_USER', 'dbdevusr')
    db_password = os.getenv('DB_SQLSERVER_PASSWORD', 'OwnhjKZqZMCY0vL')
    
    print(f"Testing connection to SqlServer...")
    print(f"Host: {db_host}:{db_port}")
    print(f"Database: {db_name}")
    print(f"User: {db_user}")
    print("-" * 50)
    
    try:
        # Test with pymssql
        print("Testing with pymssql...")
        conn = pymssql.connect(
            host=db_host,
            port=db_port,
            database=db_name,
            user=db_user,
            password=db_password
        )
        cursor = conn.cursor()

        cursor.execute("SELECT @@VERSION AS server")
        server = cursor.fetchone()[0]
        cursor.execute("SELECT SERVERPROPERTY('productversion') AS product, SERVERPROPERTY ('productlevel') AS level, SERVERPROPERTY ('edition') AS edition")
        (product, level, edition) = cursor.fetchone()
        
        print(f"✓ pymssql connection successful!")
        print(f"  PyMSSql version: {'.'.join(str(s) for s in pymssql.VERSION)}")
        print(f"  SQL Server version: {server}")
        print(f"  Version info: product {product}, level {level}, edition {edition}")

        cursor.close()
        conn.close()
        
        # Test with SQLAlchemy
        print("\nTesting with SQLAlchemy...")
        engine = create_engine(f'mssql+pymssql://{db_user}:{db_password}@{db_host}:{db_port}/{db_name}')
        with engine.connect() as connection:
            result = connection.execute(text("SELECT DB_NAME() as SELECTED_DB, CURRENT_USER;"))
            row = result.fetchone()
            print(f"✓ SQLAlchemy connection successful!")
            print(f"  Current database: {row[0]}")
            print(f"  Current user: {row[1]}")
        
        return True
        
    except Exception as e:
        print(f"❌ Connection failed: {e}")
        return False

def test_postgresql_connection():
    """Test connection to PostgreSQL database"""
    
    # Get connection parameters from environment variables
    db_host = os.getenv('DB_HOST', 'postgresql')
    db_port = os.getenv('DB_PORT', '5432')
    db_name = os.getenv('DB_NAME', 'testdb')
    db_user = os.getenv('DB_USER', 'dbdevusr')
    db_password = os.getenv('DB_PASSWORD', 'OwnhjKZqZMCY0vL')
    
    print(f"Testing connection to PostgreSQL...")
    print(f"Host: {db_host}:{db_port}")
    print(f"Database: {db_name}")
    print(f"User: {db_user}")
    print("-" * 50)
    
    try:
        # Test with psycopg2
        print("Testing with psycopg2...")
        conn = psycopg2.connect(
            host=db_host,
            port=db_port,
            database=db_name,
            user=db_user,
            password=db_password
        )
        cursor = conn.cursor()
        cursor.execute("SELECT version();")
        version = cursor.fetchone()
        print(f"✓ psycopg2 connection successful!")
        print(f"  PostgreSQL version: {version[0]}")
        cursor.close()
        conn.close()
        
        # Test with SQLAlchemy
        print("\nTesting with SQLAlchemy...")
        engine = create_engine(f'postgresql://{db_user}:{db_password}@{db_host}:{db_port}/{db_name}')
        with engine.connect() as connection:
            result = connection.execute(text("SELECT current_database(), current_user;"))
            row = result.fetchone()
            print(f"✓ SQLAlchemy connection successful!")
            print(f"  Current database: {row[0]}")
            print(f"  Current user: {row[1]}")
        
        return True
        
    except Exception as e:
        print(f"❌ Connection failed: {e}")
        return False

if __name__ == "__main__":
    print("-" * 80)
    success = test_postgresql_connection()
    print("-" * 80)
    success_mssql = test_mssql_connection()
    print("-" * 80)
    if(success and success_mssql):
        print("\n🎉 All database connections working properly!")
        sys.exit(0)
    sys.exit(1)
    