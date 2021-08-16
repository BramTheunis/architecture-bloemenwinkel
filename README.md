# architecture-bloemenwinkel

## OPSTARTEN APPLICATIE: 
In de file appsettings.Development.json pas je de "FlowerstoreConnection string aan met je eigen gegevens voor de lokale database. Om de databse aan te maken en de migraties te runnen: "dotnet ef database update". Vervolgens in het mapje BasicRestApi.API het command "dotnet run" uitvoeren.
                      

## SWAGGERUI url: 
localhost:5000/swagger/index.html

## BEREIKT:
Er zijn basic endpoints voorzien voor de API. Er is een connectie mogelijk met een lokale database waaruit winkels/bloemen/verkopen kunnen worden toegevoegd/verwijderd/aangepast/opgehaald. Er is zoveel mogelijk asynchroon gewerkt alsook met dependency injection.
