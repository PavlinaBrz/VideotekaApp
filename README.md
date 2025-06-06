# VideotekaApp

VideotekaApp je jednoduchá webová aplikace pro správu a hodnocení filmù, postavená na technologii ASP.NET Core Razor Pages s vyuitím Entity Framework Core a databáze SQLite.

## Funkce
- **Seznam filmù:** Zobrazení všech filmù v databázi.
- **Pøidání filmu:** Formuláø pro zadání nového filmu.
- **Úprava filmu:** Editace údajù o filmu.
- **Smazání filmu:** Odstranìní filmu z databáze.
- **Statistiky:** Základní statistiky o filmech.
- **Uivatelskı ebøíèek:** Monost tvoøit a upravovat vlastní poøadí filmù.

## Pouité technologie
- ASP.NET Core Razor Pages (.NET 8)
- Entity Framework Core (Code First)
- SQLite
- C#
- Bootstrap 5 (styly)

## Instalace a spuštìní
1. **Klonujte repozitáø:**
2. **Obnovte NuGet balíèky:**
3. **Spuste aplikaci:**
- Ve Visual Studiu stisknìte F5
- nebo v terminálu spuste:
  ```bash
  dotnet run
  ```
Aplikace pobìí na adrese [https://localhost:5001](https://localhost:5001) nebo [http://localhost:5000](http://localhost:5000).

## Poznámky
- Databáze se vytvoøí automaticky pøi prvním spuštìní.
- Vıchozí uivatel je "demo" (pro ebøíèek filmù).