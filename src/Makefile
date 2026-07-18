COMPOSE := docker compose -f docker-compose.yml -f docker-compose.override.yml

.PHONY: all up down stop restart clean re build logs ps \
        catalog basket adminer catalogdb-shell basketdb-shell


all: up

up:
	$(COMPOSE) up -d --build

## Build images only, no start
build:
	$(COMPOSE) build

## Stop and remove containers (keep volumes)
stop:
	$(COMPOSE) stop

## Stop and remove containers, networks (keep volumes)
down:
	$(COMPOSE) down

## Restart all services
restart:
	$(COMPOSE) restart

## Full teardown: containers, networks AND volumes
clean:
	$(COMPOSE) down -v

## Nuke everything then rebuild fresh
re: clean all

## Tail logs from all services
logs:
	$(COMPOSE) logs -f

## Tail logs from a single service . make logs-catalog
logs-%:
	$(COMPOSE) logs -f $*

## Show running containers
ps:
	$(COMPOSE) ps


## Open adminer in browser info
adminer:
	@echo "Adminer running at http://localhost:8888"