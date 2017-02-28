mkdir -p /data/dotnetlive/pubsite/dotnetlive.staticresource

rm -rf /data/dotnetlive/pubsite/dotnetlive.staticresource/

cd $WORKSPACE/src && npm install && bower install --allow-root && gulp default

cp -R $WORKSPACE/src/lib /data/dotnetlive/pubsite/dotnetlive.staticresource/
