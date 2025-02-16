V rámci tohoto projektu jsou definovány následující funkèní a nefunkèní poadavky:

**Funkèní poadavky:**
- Seznam filmù:
  Uivatel musí bıt schopen zobrazit seznam všech filmù uloenıch v databázi.
- Pøidání filmu:
  Uivatel musí mít monost vyplnit formuláø a uloit novı film. Validace:
  1. Název:
     Délka 2 a 60 znakù, povinnı.
  2. Rok vydání:
     Hodnota mezi 1900 a 2025, povinnı.
  3. ánr:
     Délka 3 a 30 znakù, povinnı.
  4. Hodnocení:
     Celé èíslo mezi 1 a 10, povinné.
- Úprava filmu:
  Uivatel musí bıt schopen upravit údaje existujícího filmu a zmìny uloit do databáze.
- Smazání filmu:
  Uivatel musí mít monost smazat film z databáze, pøièem pøed smazáním bude vyadováno potvrzení.
- 
**Nefunkèní poadavky:**
- Bezpeènost:
  Aplikace by mìla vyuívat HTTPS a zabezpeèené pøipojení k databázi.
- Vıkon:
  Pouití asynchronních operací zajišuje, e aplikace je responzivní a dobøe škálovatelná.
- Uivatelská pøívìtivost:
  I kdy není kladen dùraz na grafiku, formuláøe a navigace by mìly bıt pøehledné a intuitivní.
- Modularita a údrba:
  Aplikace by mìla bıt dobøe strukturovaná (architektura MVC), aby bylo snadné pøidávat nové funkce a upravovat existující kód.