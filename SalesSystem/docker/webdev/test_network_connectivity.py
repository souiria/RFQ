#!/usr/bin/env python3
"""
Test script to verify network connectivity between containers
Run this from within the python-webdev-container
"""

import socket
import sys

def test_connection(host, port, service_name):
    """Test if we can connect to a host on a specific port"""
    try:
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.settimeout(5)
        result = sock.connect_ex((host, port))
        sock.close()
        
        if result == 0:
            print(f"✅ {service_name} ({host}:{port}) - Connection successful")
            return True
        else:
            print(f"❌ {service_name} ({host}:{port}) - Connection failed")
            return False
    except Exception as e:
        print(f"❌ {service_name} ({host}:{port}) - Error: {e}")
        return False

def main():
    print("Testing network connectivity between containers...\n")
    
    # Test connections to database services
    tests = [
        ("postgresql_service", 5432, "PostgreSQL Database"),
        ("sqlserver_service", 1433, "SQL Server Database"),
    ]
    
    all_passed = True
    for host, port, service in tests:
        if not test_connection(host, port, service):
            all_passed = False
    
    print(f"\n{'=' * 50}")
    if all_passed:
        print("🎉 All connectivity tests passed!")
    else:
        print("⚠️  Some connectivity tests failed.")
        print("Make sure all containers are running and on the shared network.")
    
    # Additional network info
    print(f"\n📋 Container network information:")
    try:
        hostname = socket.gethostname()
        ip = socket.gethostbyname(hostname)
        print(f"   Current container: {hostname} ({ip})")
    except:
        print("   Could not determine container network info")

if __name__ == "__main__":
    main()
