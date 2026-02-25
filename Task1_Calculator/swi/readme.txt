Zadanie 1 - Kalkulator Operacji
Autor: Mikołaj Kosiorek

ZAŁOŻENIA PROJEKTOWE:
1. Program zakłada, że plik wejściowy nosi nazwę "input.json" i znajduje się dokładnie w tym samym katalogu co plik wykonywalny "swi.exe" (ścieżka relatywna).
2. Wynik działania programu jest zapisywany w pliku "output.txt", który generuje się w tym samym katalogu. Wyniki są posortowane rosnąco.
3. Jeśli plik wejściowy zawiera błędne dane matematyczne (np. pierwiastkowanie liczby ujemnej), program zgłosi błąd na konsoli, ale nie ulegnie awarii (obsługa wyjątków).
4. Do uruchomienia programu nie są wymagane żadne dodatkowe kroki - wszystkie zależności znajdują się w folderze obok pliku .exe.

INFORMACJE O KODZIE ŹRÓDŁOWYM (znajduje się w folderze 'source'):
Aplikacja została napisana w oparciu o zasady Clean Code i SOLID.
- Architektura: Zastosowano wzorzec Fabryki (Factory Pattern - klasa OperationFactory) do dynamicznego tworzenia obiektów operacji. Dzięki temu kod jest otwarty na rozszerzenia (Open/Closed Principle) - dodanie nowej operacji to tylko stworzenie nowej klasy, bez modyfikacji głównej pętli.
- Testy: W rozwiązaniu znajduje się osobny projekt xUnit (swi.Tests) zawierający testy jednostkowe izolowane od systemu plików (wykorzystują pliki tymczasowe).

Dziękuję za sprawdzenie zadania i życzę miłego dnia!