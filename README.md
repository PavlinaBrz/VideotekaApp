# VideotekaApp

**VideotekaApp*
** Jednoduch� webov� aplikace postaven� na ASP.NET Core MVC a Entity Framework Core s vyu�it�m datab�ze SQLite. 
** Aplikace slou�� k evidenci film�, p�i�em� pro ka�d� film se uchov�vaj� n�sleduj�c� �daje:*
- **N�zev filmu**
- **Rok vyd�n�**
- **��nr**
- **Hodnocen� filmu** (rozsah 1-10)


 ## Funkce
- **Zobrazen� seznamu film�:** P�ehled v�ech film� v datab�zi.
- **P�id�n� nov�ho filmu:** U�ivatel m��e vyplnit formul�� pro zad�n� nov�ho filmu.
- **�prava existuj�c�ho filmu:** Mo�nost editovat informace u ji� existuj�c�ho filmu.
- **Smaz�n� filmu:** Mo�nost odstranit film z datab�ze.


## Pou�it� technologie
- **ASP.NET Core MVC** � pro webov� rozhran� a zpracov�n� HTTP po�adavk�.
- **Entity Framework Core** � pro p��stup k datab�zi (Code First p��stup).
- **SQLite** � jako datab�zov� �e�en� (�et�zec p�ipojen�: `Data Source=Videot�kaDb.sqlite`).
- **C#** � programovac� jazyk.


## Instalace a spu�t�n�
1. **Clone repozit��e:**  
   ```bash
   git clone https://github.com/uzivatel/VideotekaApp.git

2. Obnoven� NuGet bal��k�:
   ```bash
	dotnet restore

3. Spu�t�n� datab�zov�ho kontextu:
   P�i spu�t�n� aplikace se datab�ze automaticky vytvo�� d�ky vol�n� Database.EnsureCreated() v kontextu.

4. Spu�t�n� aplikace:
   Ve Visual Studiu stiskn�te F5 nebo z p��kazov� ��dky spus�te:
   bash
   ```dotnet run
   Aplikace pob�� na adrese https://localhost:5001 (nebo http://localhost:5000).
