V r�mci tohoto projektu jsou definov�ny n�sleduj�c� funk�n� a nefunk�n� po�adavky:

**Funk�n� po�adavky:**
- Seznam film�:
  U�ivatel mus� b�t schopen zobrazit seznam v�ech film� ulo�en�ch v datab�zi.
- P�id�n� filmu:
  U�ivatel mus� m�t mo�nost vyplnit formul�� a ulo�it nov� film. Validace:
  1. N�zev:
     D�lka 2 a� 60 znak�, povinn�.
  2. Rok vyd�n�:
     Hodnota mezi 1900 a 2025, povinn�.
  3. ��nr:
     D�lka 3 a� 30 znak�, povinn�.
  4. Hodnocen�:
     Cel� ��slo mezi 1 a 10, povinn�.
- �prava filmu:
  U�ivatel mus� b�t schopen upravit �daje existuj�c�ho filmu a zm�ny ulo�it do datab�ze.
- Smaz�n� filmu:
  U�ivatel mus� m�t mo�nost smazat film z datab�ze, p�i�em� p�ed smaz�n�m bude vy�adov�no potvrzen�.
- 
**Nefunk�n� po�adavky:**
- Bezpe�nost:
  Aplikace by m�la vyu��vat HTTPS a zabezpe�en� p�ipojen� k datab�zi.
- V�kon:
  Pou�it� asynchronn�ch operac� zaji��uje, �e aplikace je responzivn� a dob�e �k�lovateln�.
- U�ivatelsk� p��v�tivost:
  I kdy� nen� kladen d�raz na grafiku, formul��e a navigace by m�ly b�t p�ehledn� a intuitivn�.
- Modularita a �dr�ba:
  Aplikace by m�la b�t dob�e strukturovan� (architektura MVC), aby bylo snadn� p�id�vat nov� funkce a upravovat existuj�c� k�d.