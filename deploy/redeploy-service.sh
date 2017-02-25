find kestrel-dotnetlive-*.service -exec systemctl enable {} \;

cp kestrel-dotnetlive-* /etc/systemd/system

find kestrel-dotnetlive-*.service -exec systemctl disable {} \;