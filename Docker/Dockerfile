FROM ubuntu:latest

Run apt update

RUN apt install -y apache2

COPY ./index.html /var/www/html/

RUN cat /var//www/html/index.html

CMD ["cat", "/var/www/html/index.html"]
