# Cursus administratie systeem

### Beschrijving

Het ontwikkelde programma is een webtoepassing ontwikkeld in .NET die zich richt op het beheren van cursisten, cursusinstanties en cursussen. Het biedt een robuuste API om cursistgegevens te maken, lezen, bijwerken en verwijderen. De toepassing maakt gebruik van het Entity Framework voor gegevensbeheer en is geïntegreerd met een SQL Server-database. Met behulp van unit tests wordt de functionaliteit van het systeem gecontroleerd.

Dit cursus administratie systeem heeft de volgende abstracte functionaliteit:
- Cursus overzicht bekijken
- Cursist inschrijven
- Cursusinschrijving bekijken
- Cursussen invoeren
- Cursustraject bekijken

### Instructies

- Clone repository
- Open in Visual Studio
- Run project on: https://localhost:7243

### Functionaliteit

BLAUW: Ingeplande cursusinstanties bekijken
BLAUW: tekstbestand selecteren
BLAUW: cursusplanning importeren
BLAUW: Resultaat bekijken
BLAUW: Gesorteerde lijst bekijken
BLAUW: geen bestaande of dubbele cursus-instanties importeren
BLAUW: Melden hoveel duplicaten er zijn tegengekomen
BLAUW: geen cursusplanning "in incorrect formaat" importeren
BLAUW: Foutmelding bekijken

ROOD: Huidige week tonen
ROOD: Weeknummer (en jaar) kiezen
ROOD: lijst in gekozen week tonen
ROOD: weekoverzicht in favorieten

ZWART: Navigeren naar volgende en vorige week
ZWART: begin- en einddatum opgeven
ZWART: alleen cursusinstanties binnen periode importeren
ZWART: Cursusinstantie kiezen
ZWART: Voor- en achternaam cursist invullen
ZWART: Melding krijgen dat inschrijving gelukt is

EXTRA: Aantal ingeschreven cursisten voor elke cursus tonen
EXTRA: Melding krijgen dat inschrijving mislukt is


### Testing

Methodenaam Conventie
We hanteren de conventie MethodName_StateUnderTest_ExpectedBehavior voor het benoemen van onze testmethoden. Dit maakt het eenvoudiger om te begrijpen wat elke test doet, wat de leesbaarheid en efficiëntie van het oplossen van problemen bevordert.

xUnit Test Framework
We gebruiken xUnit.net voor onze unit tests. Dit is een gratis, open-source tool voor unit testing voor het .NET Framework. De uitbreidbaarheid en compatibiliteit met verschillende tools maken het een ideale keuze.

FluentAssertions
FluentAssertions wordt gebruikt om onze testasserties leesbaarder en expressiever te maken. Het maakt test schrijven in natuurlijke taal mogelijk en biedt meer beschrijvende foutberichten.

Moq
Moq wordt gebruikt voor het maken van mock objecten van interfaces of klassen. Het helpt ons om de code onder test te isoleren van andere delen van het systeem, zoals databases of externe diensten, om te garanderen dat onze tests echte unit tests zijn.

### API-endpoints:

#### CURSISTEN-API
Get all cursisten
GET https://localhost:7243/api/v1/cursisten HTTP/1.1


Get a single cursist by ID
GET https://localhost:7243/api/v1/cursisten/5 HTTP/1.1

Create a new particulier
POST https://localhost:7243/api/v1/cursisten HTTP/1.1
Content-Type: application/json

{
    "voornaam": "Api",
    "achternaam": "post"
}

Update a particulier by ID
PUT https://localhost:7243/api/v1/cursisten/1 HTTP/1.1
Content-Type: application/json

{
    "id": 1,
    "voornaam": "John Updated",
    "achternaam": "Updated achternaam"
}

Delete a cursist by ID
DELETE https://localhost:7243/api/v1/cursisten/2 HTTP/1.1



#### CURSUSSEN-API 
Get all cursussen
GET https://localhost:7243/api/v1/cursussen HTTP/1.1

Get cursus by id
GET https://localhost:7243/api/v1/cursussen/1 HTTP/1.1

Create a new cursus
POST https://localhost:7243/api/v1/cursussen HTTP/1.1
Content-Type: application/json

{
    "duur": 4,
    "titel": "Javascript",
    "code": "JASC"
}

Update a cursus by id
PUT https://localhost:7243/api/v1/cursussen/1 HTTP/1.1
Content-Type: application/json

{
    "id": 1,
    "duur": 1,
    "titel": "Beginner .NET",
    "code": ".NETB"
}

Delete cursus by id
DELETE https://localhost:7243/api/v1/cursussen/1 HTTP/1.1 
 

