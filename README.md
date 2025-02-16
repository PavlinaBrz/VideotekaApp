# VideotekaApp

**VideotekaApp*
** Jednoduchá webová aplikace postavená na ASP.NET Core MVC a Entity Framework Core s vyuitím databáze SQLite. 
** Aplikace slouí k evidenci filmù, pøièem pro kadı film se uchovávají následující údaje:*
- **Název filmu**
- **Rok vydání**
- **ánr**
- **Hodnocení filmu** (rozsah 1-10)


 ## Funkce
- **Zobrazení seznamu filmù:** Pøehled všech filmù v databázi.
- **Pøidání nového filmu:** Uivatel mùe vyplnit formuláø pro zadání nového filmu.
- **Úprava existujícího filmu:** Monost editovat informace u ji existujícího filmu.
- **Smazání filmu:** Monost odstranit film z databáze.


## Pouité technologie
- **ASP.NET Core MVC** – pro webové rozhraní a zpracování HTTP poadavkù.
- **Entity Framework Core** – pro pøístup k databázi (Code First pøístup).
- **SQLite** – jako databázové øešení (øetìzec pøipojení: `Data Source=VideotékaDb.sqlite`).
- **C#** – programovací jazyk.


## Instalace a spuštìní
1. **Clone repozitáøe:**  
   ```bash
   git clone https://github.com/uzivatel/VideotekaApp.git

2. Obnovení NuGet balíèkù:
   ```bash
	dotnet restore

3. Spuštìní databázového kontextu:
   Pøi spuštìní aplikace se databáze automaticky vytvoøí díky volání Database.EnsureCreated() v kontextu.

4. Spuštìní aplikace:
   Ve Visual Studiu stisknìte F5 nebo z pøíkazové øádky spuste:
   bash
   ```dotnet run
   Aplikace pobìí na adrese https://localhost:5001 (nebo http://localhost:5000).
