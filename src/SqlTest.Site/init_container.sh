# Setup SSH to run
sed -i "s/SSH_PORT/$SSH_PORT/g" /etc/ssh/sshd_config
mkdir -p /var/run/sshd
/usr/sbin/sshd