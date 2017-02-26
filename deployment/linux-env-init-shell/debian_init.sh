#!/bin/bash
apt-get install apt-transport-https -y
echo "add dotdeb package source"
echo "deb http://packages.dotdeb.org jessie all" >> /etc/apt/sources.list.d/dotdeb.list
echo "deb-src http://packages.dotdeb.org jessie all" >> /etc/apt/sources.list.d/dotdeb.list
wget --quiet -O - https://www.dotdeb.org/dotdeb.gpg | sudo apt-key add -

echo "add postgresql package source"
echo "deb http://apt.postgresql.org/pub/repos/apt/ jessie-pgdg main" >> /etc/apt/sources.list.d/pgdg.list
wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | sudo apt-key add - && apt-get update

echo "update package source"
sudo apt-get update

apt-get install vim git mongodb-server postgresql-9.6 redis-server nginx -y

echo "start install dotnet core"
sudo apt-get install curl libunwind8 gettext -y
wget -O /tmp/dotnet_sdk_x64.tar.gz https://go.microsoft.com/fwlink/?linkid=841689
sudo mkdir -p /opt/dotnet && sudo tar zxf /tmp/dotnet_sdk_x64.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
echo "dotnet core install completed"

echo "install front-end component"
curl -sL https://deb.nodesource.com/setup_7.x | sudo -E bash -
sudo apt-get install -y nodejs
npm install bower gulp -g

echo "elasticsearch"
echo "https://www.elastic.co/guide/en/elasticsearch/reference/current/deb.html"
wget -qO - https://artifacts.elastic.co/GPG-KEY-elasticsearch | sudo apt-key add -
sudo apt-get install apt-transport-https
echo "deb https://artifacts.elastic.co/packages/5.x/apt stable main" | sudo tee -a /etc/apt/sources.list.d/elastic-5.x.list
sudo apt-get update && sudo apt-get install elasticsearch

echo "rabbitmq"
echo "http://www.rabbitmq.com/install-debian.html"
echo 'deb http://www.rabbitmq.com/debian/ testing main' > /etc/apt/sources.list.d/rabbitmq.list
wget -O- https://www.rabbitmq.com/rabbitmq-release-signing-key.asc | sudo apt-key add - && apt-get update
apt-get install rabbitmq-server
