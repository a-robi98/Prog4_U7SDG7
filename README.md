Projekt név: MyGuitarShop

Téma: A saját gitárboltom applikációját készítem el. 
Árulok gitárokat, erősítőket, és különféle kiegészítőket, 
ezeket viszont szettben árulom, így fog egymáshoz kapcsolódni a három táblám.

Az applikáció Data (Entity Framework) / Repository / Logic rétegekből épül fel, ehhez csatlakozik egy Konzolos UI, és egy kliens Webes UI (Endpointtal). 
Az Endpoint és a Webkliens REST apival kommunikál.
Továbbá egy Test réteg is megtalálható. 

A Konzolos UI a következő funkciókkal fog rendelkezni:
 - Gitárok listázása / hozzáadása / módosítása / törlése
 - Erősítők listázása / hozzáadása / módosítása / törlése
 - Kiegészítők listázása / hozzáadása / módosítása / törlése
 - Gitár-erősítő-kiegészítő kombó listázása / hozzáadása / törlése
 - Legyen lehetőségünk kiírni a teljes árat: gitár ára + erősítő ára + kiegészítők ára
 - Legyen lehetőségünk kiírni gitáronként csoportosítva a hozzájuk megfelelő erősítőket
 - Legyen lehetőségünk kiírni, hogy a különböző kiegészítők hányszor vannak gitárhoz kapcsolva

A Webes UI funkciói:
 - Gitárok listázása
 - Gitárok hozzáadása
 - Gitárok módosítása
 - Gitárok törlése
 
További implementálandó funkciók:
 - Wpf UI implementáció
 - Webes UI az összes táblára
 - SignalR-es összeköttetés a UI-ok között
 - A Konzolos UI-t is kliensé változtatni
