FROM debian:bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        php \
        php-mysqli \
        wget \
    && apt-get clean && rm -rf /var/lib/apt/lists/*

RUN mkdir -p /var/www/adminer && \
    wget --no-check-certificate https://github.com/vrana/adminer/releases/download/v4.8.1/adminer-4.8.1.php \
         -O /var/www/adminer/index.php

WORKDIR /var/www/adminer

EXPOSE 8888

CMD ["php", "-S", "0.0.0.0:8888"]