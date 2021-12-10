https://trello.com/c/100P3PDo/20-api-em-c

dotnet build --configuration Release

docker build -t didox/desafio_multiplasapis_dotnet_usuario -f Dockerfile .

docker run -d -p 5001:80 --name desafio_multiplasapis_dotnet_usuario didox/desafio_multiplasapis_dotnet_usuario

docker ps

docker images | grep desafio_multiplasapis_dotnet_usuario

docker logs desafio_multiplasapis_dotnet_usuario -f --tail 100

docker start desafio_multiplasapis_dotnet_usuario
docker stop desafio_multiplasapis_dotnet_usuario
docker rm desafio_multiplasapis_dotnet_usuario
