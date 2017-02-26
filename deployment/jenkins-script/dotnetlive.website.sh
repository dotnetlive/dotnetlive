systemctl stop kestrel-dotnetlive-website.service
rm -rf /data/dotnetlive/pubsite/dotnetlive.website/

dotnet restore src/DotNetLive.Web.sln 
cd $WORKSPACE/src/DotNetLive.Web && npm install && bower install --allow-root && gulp default
echo "CURRENT PATH"
pwd
dotnet publish $WORKSPACE/src/DotNetLive.Web/DotNetLive.Web.csproj -c "Release" -o /data/dotnetlive/pubsite/dotnetlive.website/ 

systemctl start kestrel-dotnetlive-website.service
