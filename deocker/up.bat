docker compose -f ./compose.yml -p contracts --env-file ./env/.env.dev --env-file ./env/.env.containers up
docker-compose up --build --d --remove-orphans  --no-deps