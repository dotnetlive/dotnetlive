find /etc/systemd/system/kestrel-dotnetlive-*.service -exec systemctl enable {} \;

cp kestrel-dotnetlive-* /etc/systemd/system

find /etc/systemd/system/kestrel-dotnetlive-*.service -exec systemctl disable {} \;