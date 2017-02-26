systemctl stop kestrel-dotnetlive-searchweb.service
rm -rf /data/dotnetlive/pubsite/dotnetlive.searchweb/
dotnet restore $WORKSPACE/src/DotNetLive.SearchWeb.sln 
cd $WORKSPACE/src/DotNetLive.SearchWeb && npm install && bower install --allow-root && gulp default
dotnet publish $WORKSPACE/src/DotNetLive.SearchWeb/DotNetLive.SearchWeb.csproj -c "Release" -o /data/dotnetlive/pubsite/dotnetlive.searchweb/ 
systemctl start kestrel-dotnetlive-searchweb.service

