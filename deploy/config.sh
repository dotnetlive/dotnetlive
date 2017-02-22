## scan current dnl service
## install all dnl service
## update nginx config

mkdir /data && echo "/dev/sdc  /data   ext4  defaults 1 1" >> /etc/fstab


cp kestrel-dotnetlive-* /etc/systemd/system
find kestrel-dotnetlive-*.service -exec systemctl enable {} \;