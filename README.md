# Projekt-2

Aplikacja konsolowa sluzaca do zarzadzania sprzetem uczelnianym, obslugujaca wypozyczenia, 
zwroty oraz naliczanie kar dla studentow i pracownikow.

Instrukcja uruchomienia:
Bedac w pliku .csproj wpisz dotnet run

Podzial na foldery i pliki: Kod nie znajduje sie w jednym pliku Program.cs. 
Rozdzielilem modele danych (folder Model) od logiki operacyjnej (folder Service). 
Dzieki temu latwiej jest wprowadzac zmiany w jednym miejscu bez psucia reszty programu.

Podzial zadan miedzy klasami: Kazda klasa odpowiada za jedna konkretna rzecz. 
Klasa Inventory zarzadza tylko stanem sprzetu, UserService zajmuje sie lista osob, a RentalService obsluguje 
sam proces wypozyczania i naliczania kar.

Stosowanie dziedziczenia i abstrakcji: Uzylem klas abstrakcyjnych dla Equipment oraz User. 
Dziedziczenie dla klas takich jak Laptop, Camera czy Student wynika z modelu (kazdy laptop to sprzet).
Kazdy typ sprzetu posiada tez swoje wlasne, specyficzne pola.

Zarzadzanie regulami biznesowymi: Limity wypozyczen (2 dla studenta, 5 dla pracownika) oraz zasady naliczania kar 
sa zapisane w czytelny sposob wewnatrz klas. 
Dzieki temu latwo je zmodyfikowac w przyszlosci bez przeszukiwania calego projektu.

Obsluga bledow: System reaguje na niepoprawne operacje. 
Przykladowo, proba wypozyczenia zajetego sprzetu lub przekroczenia limitu przez uzytkownika konczy sie wyrzuceniem 
wyjatku z komunikatem.
