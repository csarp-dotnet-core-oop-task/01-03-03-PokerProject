# 01-03-03 feladat
## Poker projekt 


A póker asztalnál szeretnénk játszani és ezért egy olyan játékost kifejleszteni, aki egy elért pénzösszeg elérését tűzi ki célul. Ha a játékos pénze eléri a kívánt nyereményt abbahagyja a játékot, nem vesz részt több körben. A játékosunk vigyáz arra is, hogy nagy veszteséget ne halmozzon fel! Amint tartozása van abbahagyja a játékot, nem vesz részt több körben!


A feladat megoldását a következő UML diagram segíti:


![Póker](https://github.com/csarp-dotnet-core-oop-task/01-03-03-PokerProject/blob/main/PokerProjekt/poker.png)
 
A Price osztályban private elérésű adattagok és public elérésű metódusok vannak!
A mezők jelentése
```
Price PriceStart = new Price(100, 120);
```
A játékos 100 egységgel lép a játékba (amount) és 120 egység elérése a célja (winningTarget)!

A Palyer osztályban private elérésű adattagok vannak. A ToConsoleName és a ToConsoleRound metódusok private elérésűek! A két publikus metódus a konstruktor és a SumUpNextRound metódus!

Futási példa:
```
            Price PriceStart = new Price(100, 120);
            PriceStart.ToConsole();

            Player playerWinner = new Player("Nyerő Jani", PriceStart);
            playerWinner.SumUpNextRound(10);
            playerWinner.SumUpNextRound(-5);
            playerWinner.SumUpNextRound(20);
            playerWinner.SumUpNextRound(10);
```
```
A játékos jelenlegi bevétele: 100 Ft
A játékos célja 120 Ft elérése.
A Játékos neve: Nyerő Jani.
A forduló eredménye:
A játékos jelenlegi bevétele: 110 Ft
A játékos célja 120 Ft elérése.
A forduló eredménye:
A játékos jelenlegi bevétele: 105 Ft
A játékos célja 120 Ft elérése.
A forduló eredménye:
A játékos elérte a játékban a 120 összeget és kiszált a játékból! Nyereménye 125 Ft.
A forduló eredménye:
A játékos elérte a játékban a 120 összeget és kiszált a játékból! Nyereménye 125 Ft.
```
```
            Price PriceEnd = new Price(20, 120);
            PriceEnd.ToConsole();

            Player playerLoser = new Player("Vesztő Vendel", PriceEnd);
            playerLoser.SumUpNextRound(-10);
            playerLoser.SumUpNextRound(5);
            playerLoser.SumUpNextRound(-20);
            playerLoser.SumUpNextRound(-10);
```
```
A játékos jelenlegi bevétele: 20 Ft
A játékos célja 120 Ft elérése.
A Játékos neve: Vesztő Vendel.
A forduló eredménye:
A játékos jelenlegi bevétele: 10 Ft
A játékos célja 120 Ft elérése.
A forduló eredménye:
A játékos jelenlegi bevétele: 15 Ft
A játékos célja 120 Ft elérése.
A forduló eredménye:
A játékos vesztett! Vesztesége -5 Ft.
A forduló eredménye:
A játékos vesztett! Vesztesége -5 Ft.
```
