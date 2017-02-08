start:
	systemctl start kestrel-dotnetlive-website.service

stop:
	systemctl stop kestrel-dotnetlive-website.service

delete_current_build:
	rm -rf /var/dotnetlive/pubsite/dotnetlive.website/

publish:
	git clean -df
	git pull
	dotnet restore src/DotNetLive.Web.sln 
	cd src/DotNetLive.Web && npm install && bower install --allow-root && gulp default
	dotnet publish src/DotNetLive.Web/DotNetLive.Web.csproj -c "Release" -o /var/dotnetlive/pubsite/dotnetlive.website/ 

deploy: stop publish start
