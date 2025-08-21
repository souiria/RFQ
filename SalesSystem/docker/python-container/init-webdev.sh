#!/bin/bash

# At somepoint this container will be converted to a Dockerfile/image

# Add some things
# freshen the apt cache
apt update
# install mimimal toolset
apt install -y vim-nox mc openssh-server net-tools dnsutils iproute2 iputils-ping

# Configure SSH to run on port 2222 and accept public key authentication
echo "Configuring SSH..."
sed -i 's/#Port 22/Port 2222/' /etc/ssh/sshd_config
sed -i 's/#PubkeyAuthentication yes/PubkeyAuthentication yes/' /etc/ssh/sshd_config

sed -i 's/#LoginGraceTime 2m/LoginGraceTime 2m/' /etc/ssh/sshd_config
sed -i 's/#PermitRootLogin prohibit-password/PermitRootLogin no/' /etc/ssh/sshd_config
sed -i 's/#StrictModes yes/StrictModes yes/' /etc/ssh/sshd_config
sed -i 's/#MaxAuthTries 6/MaxAuthTries 6/' /etc/ssh/sshd_config
sed -i 's/#MaxSessions 10/MaxSessions 10/' /etc/ssh/sshd_config

sed -i 's/#PasswordAuthentication yes/PasswordAuthentication yes/' /etc/ssh/sshd_config
# PKA (Public Key Authentication) is better!
#sed -i 's/#PasswordAuthentication yes/PasswordAuthentication no/' /etc/ssh/sshd_config
sed -i 's/#PermitEmptyPasswords no/PermitEmptyPasswords no/' /etc/ssh/sshd_config
mkdir -p /run/sshd
/usr/sbin/sshd -f /etc/ssh/sshd_config

# Create webdev user with UID 1000 and GID 1000
echo "Creating webdev user..."
groupadd -g 1000 webdev 2>/dev/null || echo "Group webdev already exists"
useradd -u 1000 -g 1000 -m -s /bin/bash webdev 2>/dev/null || echo "User webdev already exists"

# Set ownership of home directory
echo "Setting up home directory permissions..."
chown -R webdev:webdev /home/webdev

# Set ssh authorized_keys
echo "Setting up SSH authorized_keys..."
mkdir -p /home/webdev/.ssh
chown webdev:webdev /home/webdev/.ssh
chmod 700 /home/webdev/.ssh
touch /home/webdev/.ssh/authorized_keys
# echo "YOU NEED A SSH KEY HERE TO ALLOW CONNECTION WITH PKA" > /home/webdev/.ssh/authorized_keys
chown webdev:webdev /home/webdev/.ssh/authorized_keys
chmod 600 /home/webdev/.ssh/authorized_keys

# Create and set permissions for share directory
echo "Setting up share directory..."
mkdir -p /home/webdev/share
chown webdev:webdev /home/webdev/share

# Install Python packages as webdev user
echo "Installing Python packages..."
su webdev -c 'pip install --user --upgrade pip setuptools wheel'
su webdev -c 'pip install --user psycopg2-binary pymssql sqlalchemy pandas'

echo "Setup complete! Starting container (connect using 'docker exec -it pythondev /bin/bash')..."

# Switch to webdev user and keep container running
exec su webdev -c 'cd /home/webdev && tail -f /dev/null'
