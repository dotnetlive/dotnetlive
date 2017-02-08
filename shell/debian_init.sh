#!/bin/bash
apt-get install vim git apt-transport-https -y
echo "add dotdeb package source"
echo "deb http://packages.dotdeb.org jessie all" >> /etc/apt/sources.list.d/dotdeb.list
echo "deb-src http://packages.dotdeb.org jessie all" >> /etc/apt/sources.list.d/dotdeb.list
wget --quiet -O - https://www.dotdeb.org/dotdeb.gpg | sudo apt-key add -

echo "add postgresql package source"
echo "deb http://apt.postgresql.org/pub/repos/apt/ jessie-pgdg main" >> /etc/apt/sources.list.d/pgdg.list
wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | sudo apt-key add - && apt-get update

echo "update package source"
sudo apt-get update

apt-get install mongodb-server postgresql-9.6 redis-server nginx -y

echo "start install dotnet core"
sudo apt-get install curl libunwind8 gettext -y
wget -O /tmp/dotnet_sdk_x64.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/rel-1.0.0/dotnet-dev-debian-x64.latest.tar.gz
sudo mkdir -p /opt/dotnet && sudo tar zxf /tmp/dotnet_sdk_x64.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
echo "dotnet core install completed"

echo "install front-end component"
curl -sL https://deb.nodesource.com/setup_7.x | sudo -E bash -
sudo apt-get install -y nodejs
npm install bower gulp -g
