systemctl stop kestrel-dotnetlive-accountweb.service
rm -rf /data/dotnetlive/pubsite/dotnetlive.accountweb/
dotnet restore $WORKSPACE/src/accountweb/DotNetLive.AccountWeb.sln 
cd $WORKSPACE/src/accountweb/DotNetLive.AccountWeb && npm install && bower install --allow-root && gulp default
dotnet publish $WORKSPACE/src/accountweb/DotNetLive.AccountWeb/DotNetLive.AccountWeb.csproj -c "Release" -o /data/dotnetlive/pubsite/dotnetlive.accountweb/ 
systemctl start kestrel-dotnetlive-accountweb.service


systemctl stop kestrel-dotnetlive-accountapi.service
rm -rf /data/dotnetlive/pubsite/dotnetlive.accountapi/
dotnet restore $WORKSPACE/src/accountapi/DotNetLive.AccountApi.sln 
dotnet publish $WORKSPACE/src/accountapi/DotNetLive.AccountApi/DotNetLive.AccountApi.csproj -c "Release" -o /data/dotnetlive/pubsite/dotnetlive.accountapi/ 
systemctl start kestrel-dotnetlive-accountapi.service

