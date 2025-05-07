API Dokumentation
Denna dokumentation beskriver hur du använder API:et för att hantera användare, hobbies, och relaterade länkar.
1. Hämta alla användare
Hämtar alla användare från databasen.

Metod: GET
URL: /api/User
Responsstatus: 200 OK
Responsbody:

[
  {
    "id": 1,
    "name": "Löpning",
    "description": "Springa i skogen",
    "userHobbies": null
  },
  {
    "id": 2,
    "name": "Gitarr",
    "description": "Spela akustisk gitarr",
    "userHobbies": null
  },
  {
    "id": 1001,
    "name": "Hästar",
    "description": "gnägg",
    "userHobbies": null
  },
  {
    "id": 1002,
    "name": "avancerad häst",
    "description": "häst",
    "userHobbies": null
  }
]

2. Hämta användare efter ID
Hämtar en användare baserat på deras ID.

Metod: GET
URL: /api/UserHobby/{UserId}/User
Parametrar:
UserId (path): Användarens ID (heltal)


Responsstatus: 200 OK
Responsbody:

[
  {
    "id": 1,
    "name": "Löpning",
    "description": "Springa i skogen",
    "userHobbies": null
  },
  {
    "id": 2,
    "name": "Gitarr",
    "description": "Spela akustisk gitarr",
    "userHobbies": null
  },
  {
    "id": 1001,
    "name": "Hästar",
    "description": "gnägg",
    "userHobbies": null
  }
]

3. Hämta länkar kopplade till en användare
Hämtar alla länkar kopplade till en användare baserat på användar-ID.

Metod: GET
URL: /api/UserHobby/{UserId}/User/Link
Parametrar:
UserId (path): Användarens ID (heltal)


Responsstatus: 200 OK
Responsbody:

[
  {
    "hobbyName": "Gitarr",
    "userName": "Björn Berg",
    "link": "https://github.com"
  },
  {
    "hobbyName": "Gitarr",
    "userName": "Björn Berg",
    "link": "www.learntoplay.com"
  }
]

4. Skapa en ny UserHobby
Kopplar en användare till en hobby genom att skapa en ny UserHobby.

Metod: POST
URL: /api/UserHobby?UserId={UserId}&HobbyId={HobbyId}
Parametrar:
UserId (query): Användarens ID (heltal)
HobbyId (query): Hobbyns ID (heltal)


Responsstatus: 201 Created
Responsbody:

{
  "userId": 2,
  "hobbyId": 1001
}

5. Skapa en ny länk
Skapar en ny länk kopplad till en användare och hobby.

Metod: POST
URL: /api/Link
Body:

{
  "userId": 1,
  "hobbyId": 1,
  "url": "https://www.example.com"
}


Responsstatus: 201 Created
Responsbody:

{
  "id": 17,
  "url": "https://www.example.com",
  "userHobbyId": 1
}

