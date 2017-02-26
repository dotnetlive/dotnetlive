#this shell is only for jenkins use

cp $WORKSPACE/deploy/nginxconfig/*.conf /etc/nginx/conf.d/
nginx -s reload
