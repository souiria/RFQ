# Seq Log Server Container

This directory contains the Docker Compose configuration for Seq, a centralized log server that collects and analyzes structured log data from your applications.

## What is Seq?

Seq is a self-hosted search, analysis, and alerting server built specifically for structured log data. It provides:
- Real-time log search and filtering
- Structured logging with rich query capabilities
- Dashboards and visualizations
- Alerting and notifications
- API access for programmatic integration

## Quick Start

### 1. Start the Seq container:
```powershell
cd c:\source\docker\seq-container
docker-compose up -d
```

### 2. Access the Seq Web UI:
Open your browser and navigate to: **http://localhost**

Default credentials (if no custom password is set):
- Username: `admin`
- Password: (leave blank on first login, you'll be prompted to set one)

### 3. Configure your applications to send logs to Seq:
- **Ingestion endpoint**: `http://seq_service:5341` (from other containers)
- **External ingestion**: `http://localhost:5341` (from host machine)

## Configuration

### Environment Variables
Copy `.env.example` to `.env` and customize:

```bash
cp .env.example .env
```

Key settings:
- `SEQ_ADMIN_USERNAME`: Admin user name (default: admin)
- `SEQ_ADMIN_PASSWORD_HASH`: Hashed admin password (optional)

### Custom Password Setup
To set a custom admin password:

```powershell
# Generate password hash
$password = "YourSecurePassword123"
$hash = echo $password | docker run --rm -i datalust/seq config hash
echo "SEQ_ADMIN_PASSWORD_HASH=$hash" >> .env
```

## Integration Examples

### Python Applications
Install the required package:
```bash
pip install seqlog
```

Use the sample configuration in `sample_python_logging.py`:
```python
import logging
import seqlog

# Configure logging to Seq
seqlog.configure_from_dict({
    # ... (see sample file for full configuration)
})

logger = logging.getLogger(__name__)
logger.info("Hello from Python!", extra={"user_id": 123})
```

### .NET Applications
Install Serilog.Sinks.Seq package and use the configuration in `sample_dotnet_appsettings.json`:

```json
{
  "Serilog": {
    "WriteTo": [
      {
        "Name": "Seq",
        "Args": {
          "serverUrl": "http://seq_service:5341"
        }
      }
    ]
  }
}
```

### Node.js Applications
Install the required packages:
```bash
npm install @datalust/winston-seq winston
```

Use the sample configuration in `sample_nodejs_logging.js`.

## Container Network

The Seq container is connected to the `shared-dev-network`, allowing it to communicate with other containers:
- **Container name**: `seq_service`
- **Web UI**: Port 80 (mapped to host port 80)
- **Ingestion**: Port 5341 (mapped to host port 5341)

## Port Mappings

- **80:80** - Web UI interface
- **5341:5341** - HTTP log ingestion endpoint

## Data Persistence

Seq data is stored in a Docker volume (`seq_data`) ensuring logs persist across container restarts.

## Health Check

The container includes a health check that verifies Seq is responding on the web interface.

## Common Use Cases

### Application Logging
Send structured logs from your applications running in other containers:
```python
logger.info("User login", extra={
    "user_id": 12345,
    "ip_address": "192.168.1.100",
    "user_agent": "Mozilla/5.0...",
    "success": True
})
```

### Error Tracking
Track and analyze application errors:
```python
logger.error("Database connection failed", extra={
    "error_code": "DB_TIMEOUT",
    "database": "postgresql_service",
    "retry_count": 3,
    "duration_ms": 5000
})
```

### Performance Monitoring
Log performance metrics:
```python
logger.info("API request completed", extra={
    "endpoint": "/api/users",
    "method": "GET",
    "duration_ms": 150,
    "status_code": 200,
    "user_id": 789
})
```

## Querying Logs in Seq

Once logs are flowing into Seq, you can use its powerful query language:

```sql
-- Find all errors in the last hour
@Level = 'Error' and @Timestamp > Now() - 1h

-- Find slow API requests
method = 'GET' and duration_ms > 1000

-- Track user activity
user_id = 12345 and @Timestamp > Today()

-- Find database connection issues
error_code like '%DB%' or database is not null
```

## Troubleshooting

### Container not starting:
```powershell
docker-compose logs seq
```

### Can't access web UI:
- Ensure port 80 is not in use by another service
- Check Windows firewall settings
- Verify container is running: `docker ps`

### Applications can't send logs:
- Ensure both containers are on the `shared-dev-network`
- Use container name `seq_service` as hostname
- Check port 5341 is accessible

### Reset Seq data:
```powershell
docker-compose down
docker volume rm seqdev_seq_data
docker-compose up -d
```

## Advanced Configuration

For production environments, consider:
- Setting up HTTPS with SSL certificates
- Configuring authentication providers (Active Directory, etc.)
- Setting up log retention policies
- Configuring email/Slack alerts
- Using API keys for secure log ingestion

See the [official Seq documentation](https://docs.datalust.co/docs) for more advanced configuration options.
