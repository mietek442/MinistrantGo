# Ministrant Go 1.0 📱

### O Aplikacji 🎯

Witaj w Ministrant Go! 🚀 Ten projekt to kompleksowy system do zarządzania aplikacją liczącą punkty dla ministrantów. Celem jest usprawnienie liczenia punktów oraz organizacji zbiórek ministrantów, wykorzystując najnowsze i najbardziej niezawodne technologie. 🛠️📊

### About Application 🎯
Welcome to Ministrant Go! 🚀 This project is a comprehensive system for managing an application that tracks points for altar servers. The goal is to streamline the point counting and organization of altar server meetings, using the latest and most reliable technologies. 🛠️📊



## Technologies in Frontend Used
- Vue + Vite ✔️
- QR CODE Scaner ✔️ 
- vue-router - for many pages ✔️ 

## Technologies in Backend Used
- ASP .NET CORE Web Api  ✔️
- .Net 9.0  ✔️
- CQRS ✔️
- Vertical Architecture ✔️
- Dotnet Entity Framework Core ✔️
- ASP.NET Core Identity in .NET 9 ✔️
- Fluent Validator (Work in progress)
- Docker ✔️
- Azure Blob Storage for Pictures ✔️
- QR CODE Generator ✔️


## Endpoints Overview
- **Users**: Login, Logout, Register
- **ScanQrCode**: Generate and scan QR code, verify QR code
- **StatisticsPoint**: User points count, total points of all users
- **Point**: Retrieve all points entries, edit points count, soft delete points
- **Duties**: Add duty, list duties, edit duties, delete duties, confirm duties by user


# Guide in English for Building a Project 🇬🇧
## Building on Docker:
```docker command
dokker bild -t username/ministrantgo:1.0 .
```
-dokker bild: Command used for building Docker images based on Dockerfile.

-t: Parameter used for tagging the image, i.e., assigning it a name and version. After executing the command dokker imidzs, you can see the image ID, its name, and assigned tag.

-username/ministrantgo: This is the image name in the format username/application_name. While other names can be used, it is recommended to use this structure username/application_name.

-1.0: Specifies the version of the image. While it is possible to omit the version and use the default tag latest, it is better to specify a version number (e.g., 1.0) to ensure that you are using a specific image. Using latest can lead to situations where the image is not up-to-date or properly tagged, which can cause misunderstandings.

## Displaying the list of built images:
```docker command
dokker images
```
- shows the list of built images

## Running Docker:
```docker command
dokker ran -d -p 8808:8080 c429c59dae79
```
dokker ran – used to run a Docker container on the server.
-d – enables running the container in the background, so you don't have to stay in the console.
-p – responsible for port mapping. Without this option, the container would only run on Docker's internal port, e.g., 5522321, without visibility on the computer at port 5522321.
8808 – the port on which the container will be available on the local computer.
8080 – the port on which the container will run the application inside Docker.
c429c59dae79 – the image identifier to be run, known by doing: dokker imidzs.

## Displaying the list of running containers:
```docker command
dokker ps
```
- shows the id of the running image, image_name, status (start)




# Poradnik Po Polsku Bildowania Projektu   🇵🇱 
## Bildowanie na dockerze:
```docker command
 docker build -t nazwa_uzytkownik/ministrantgo:1.0 .
```
-docker build: Komenda służąca do budowania obrazu Dockera na podstawie pliku Dockerfile.

-t: Parametr używany do tagowania obrazu, czyli przypisania mu nazwy i wersji. Po wykonaniu komendy docker images, można zobaczyć ID obrazu, jego nazwę oraz przypisany tag.

-nazwa_uzytkownik/ministrantgo: Jest to nazwa obrazu w formacie nazwa_użytkownika/nazwa_aplikacji. Choć możliwe jest stosowanie innych nazw, ale zaleca się używanie tej struktury nazwa_uzytkownika/nazwa_aplikacji.

-1.0: Określa wersję obrazu. Choć można zrezygnować z określenia wersji i używać domyślnego tagu latest, lepiej jest wskazać numer wersji (np. 1.0), aby mieć pewność, że korzystamy z konkretnego obrazu. Korzystanie z latest może prowadzić do sytuacji, w której obraz nie jest aktualny lub nie jest odpowiednio oznaczony, co może powodować nieporozumienia.


## Pokazanie  listy zbildowanych obrazów:
```docker command
docker images
```
- pokazanie zbuildowanych obrazów

Uruchomienie dockera:
```docker command
docker run -d -p 8808:8080 c429c59dae79
```
docker run – służy do uruchomienia kontenera Dockera na serwerze.
-d – umożliwia uruchomienie kontenera w tle, dzięki czemu nie musisz pozostawać w konsoli.
-p – odpowiada za mapowanie portów. Bez tej opcji kontener działałby tylko na wewnętrznym porcie Dockera, np. 5522321, bez widoczności na komputerze  na porcie 5522321.
8808 – port, na którym kontener będzie dostępny na komputerze lokalnym.
8080 – port, na którym kontener uruchomi aplikację wewnątrz Dockera.
c429c59dae79 – identyfikator obrazu, który ma zostać uruchomiony, poznajemy go gdy zrobimy:  docker images.   


pokazanie listy uruchomionych kontenerów:
```docker command
docker ps
```
- pokazuje id uruchomionego obrazu, nazwa_obrazu, status(start)


# How to do Migrations : 
Jak zrobić migracje 
```bash
dotnet ef migrations remove
dotnet ef migrations add Init
dotnet ef database drop
dotnet ef database
```
🇬🇧 Make sure to change the server connection when you make migration string in your, after migrations you change defaultconnection string back `appsettings.json` file from: 
🇵🇱 Upewnij się, że zmieniłeś appseting gdy tworzysz migracje w  pliku appsettings.json, a po migracjach zmień appsettings.json spowrotem. :

During normal work:  
```json
"DefaultConnection": "Server=ministrantgo.database;Database=ministrantgo;User Id=ministrantgo;Password=ministrantgo;"
```

to:
During Migrations:
```json
"DefaultConnection": "Server=localhost;Database=ministrantgo;User Id=ministrantgo;Password=ministrantgo;"
```

  
