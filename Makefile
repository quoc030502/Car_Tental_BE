MIGRATION_NAME ?= Init

watch:
	dotnet watch run

build:
	dotnet build

run:
	dotnet run

publish:
	dotnet publish -c Release -o out

migration_create:
	dotnet ef migrations add $(MIGRATION_NAME)

migration_up:
	dotnet ef database update

migration_down:
	dotnet ef migrations remove

migration_list:
	dotnet ef migrations list
