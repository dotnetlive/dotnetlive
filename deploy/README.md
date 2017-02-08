# dotnetlive system deploy 

# Overall
## File: dotnet.live.conf

dotnet.live all system nginx configuration file, location at: /etc/nginx/conf.d

# For Each Application

## dotnetlive-website http://dotnet.live

### File: kestrel-dotnetlive-website.service

dotnetlive.website daemond configuration file, located at: /etc/systemd/system/

* added dotnetlive-website as a daemod application
systemctl enable kestrel-dotnetlive-website.service

* start dotnetlive-website
systemctl kestrel-dotnetlive-website.service start

* stop dotnetlive-website
systemctl kestrel-dotnetlive-website.service stop

