dotnet build --configuration Release
docker build -t didox/desafio_multiplasapis_dotnet_usuario -f Dockerfile .
docker tag didox/desafio_multiplasapis_dotnet_usuario hub.docker.com/r/didox/desafio_multiplasapis_dotnet_usuario
docker push didox/desafio_multiplasapis_dotnet_usuario