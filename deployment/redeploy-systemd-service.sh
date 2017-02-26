# this shell is only for jenkins deploy
#!/bin/sh

find /etc/systemd/system/kestrel-dotnetlive-*.service -exec systemctl disable {} \;

rm /etc/systemd/system/kestrel-dotnetlive-*.service

cp $WORKSPACE/deploy/*.service /etc/systemd/system/

find /etc/systemd/system/kestrel-dotnetlive-*.service -exec systemctl enable {} \;

