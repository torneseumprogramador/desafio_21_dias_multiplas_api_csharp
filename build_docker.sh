docker stop desafio_multiplasapis_dotnet_usuario
docker rm desafio_multiplasapis_dotnet_usuario
dotnet build --configuration Release
docker build -t didox/desafio_multiplasapis_dotnet_usuario -f Dockerfile .

export DATABASE_URL='Server=localhost;Port=3306;Database=desafio_21_dias_multiplas_apis;Uid=root;Pwd=root;'
docker run -d -e DATABASE_URL -p 5001:80 --name desafio_multiplasapis_dotnet_usuario didox/desafio_multiplasapis_dotnet_usuario

docker logs desafio_multiplasapis_dotnet_usuario -f --tail 100
