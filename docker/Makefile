project_name?=contracts

up: showLogo
	@docker compose -f ./compose.yml -p "${project_name}" --env-file ./env/.env.dev --env-file ./env/.env.containers up

down: 
	@docker compose -f ./compose.yml -p "${project_name}" --env-file ./env/.env.dev --env-file ./env/.env.containers down

build:
	@docker compose -f ./compose.yml -p "${project_name}" --env-file ./env/.env.dev --env-file ./env/.env.containers build

config:
	@docker compose -f ./compose.yml -p "${project_name}" --env-file ./env/.env.dev --env-file ./env/.env.containers config

showLogo:
	@printf "$(colorMagenta)   ___    ___    _  _   _____   ___     _      ___   _____   ___  \n";
	@printf "  / __|  / _ \  | \| | |_   _| | _ \   /_\    / __| |_   _| / __| \n";
	@printf " | (__  | (_) | | .  |   | |   |   /  / _ \  | (__    | |   \__ \ \n";
	@printf "  \___|  \___/  |_|\_|   |_|   |_|_\ /_/ \_\  \___|   |_|   |___/ \n\n$(resetColor)\n";

colorMagenta = \e[95m
resetColor = \e[0m





