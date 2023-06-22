# Cursus administratie systeem

### Beschrijving

Dit is een cursus administratie systeem met de volgende abstracte functionaliteit:
- Cursus overzicht bekijken
- Cursist inschrijven
- Cursusinschrijving bekijken
- Cursussen invoeren
- Cursustraject bekijken

### Instructies
- Clone repository
- Open in Visual Studio
- Run project on: https://localhost:7243

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
 

