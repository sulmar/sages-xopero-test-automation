# Struktura projektu – BackupSystem

Ten projekt jest budowany **krok po kroku podczas szkolenia**.  
Każdy katalog w `src/` odpowiada **innemu poziomowi testów**.

---

## Struktura katalogów

```
src/
├── BackupSystem.Code
├── BackupSystem.UnitTests
├── BackupSystem.Api.IntegrationTests
└── BackupSystem.Web.UiTests
```

---

## Utworzenie projektów – krok po kroku

Zakładamy, że jesteś w katalogu głównym repo.

1. Utworzenie katalogu src/ jeśli nie istnieje
```
mkdir src
```

2. Projekt z kodem aplikacji
```
dotnet new classlib -n BackupSystem.Code -o src/BackupSystem.Code
```

3. Projekt testów jednostkowych
```
dotnet new xunit -n BackupSystem.UnitTests -o src/BackupSystem.UnitTests
```

Dodanie referencji:
```
dotnet add src/BackupSystem.UnitTests reference src/BackupSystem.Code
```


4. Projekt testów API
```
dotnet new web -n BackupSystem.Api -o src/BackupSystem.Api
```

Dodanie referencji:
```
dotnet add src/BackupSystem.Api.IntegrationTests reference src/BackupSystem.Api
```

---

## BackupSystem.Core

Projekt zawiera klasy reprezentujące system backupu plików i folderów.

### Klasa FileBackup

Klasa reprezentująca backup pojedynczego pliku.

**Poznane mechanizmy:**
- **Właściwości (Properties)** - `FileName`, `FileSizeInBytes`, `IsBackedUp` (z `private set`), `CreatedOn`
- **Konstruktor** z parametrem opcjonalnym (`fileSizeInBytes = 0`)
- **Metody** `Backup()` i `Restore()` z walidacją
- **Wyjątki**: `FormatException` (pusta nazwa pliku), `InvalidOperationException` (nieprawidłowy rozmiar lub próba przywrócenia niebackupowanego pliku), `FileNotFoundException` (plik nie istnieje)
- **Dependency Injection** - wstrzykiwanie `IFileSystem` przez konstruktor
- **Interfejsy** - `IFileSystem` jako kontrakt, implementacje `FileSystem` (produkcja) i `FakeFileSystem` (testy)
- **Test doubles (Fakes)** - `FakeFileSystem` do izolacji testów od systemu plików
- **Metody prywatne** - refaktoryzacja walidacji do metody `Validate()`
- **Programowanie asynchroniczne** - metoda `BackupAsync()` z `async Task` i `await Task.Delay()`

### Klasa FolderBackup

Klasa reprezentująca backup folderu zawierającego wiele plików.

**Poznane mechanizmy:**
- **Kolekcja** `List<FileBackup>` - lista typowana generycznie
- **Iteracja** `foreach` - przechodzenie po elementach kolekcji
- **Obsługa wyjątków** `try-catch` - przechwytywanie `FormatException` i kontynuacja dla pozostałych plików
- **Rzucanie wyjątku** `Exception` gdy lista plików jest pusta
- **LINQ** - metoda `CalculateTotalSize()` używająca `Sum()` z wyrażeniem lambda do obliczania całkowitego rozmiaru folderu

---

## BackupSystem.UnitTests

Projekt zawiera testy jednostkowe dla klas z projektu BackupSystem.Core.

### Framework testowy: xUnit

**Poznane mechanizmy:**
- **Atrybut** `[Fact]` - oznacza metodę testową
- **Wzorzec AAA** (Arrange-Act-Assert) - struktura testów
- **Metody `Assert`** - `Assert.True()`, `Assert.False()`, `Assert.Throws<T>()`, `Assert.All()`, `Assert.NotEqual()`
- **`Action` i wyrażenia lambda** `() =>` - opakowanie kodu do testowania wyjątków
- **LINQ** `Where()` i `ToList()` - filtrowanie kolekcji w testach

### Klasa FileBackupTests

Testy Happy Path i Unhappy Path dla klasy `FileBackup`. Weryfikacja zachowań konstruktora, metod `Backup()` i `Restore()`, oraz obsługi wyjątków.

### Klasa FolderBackupTests

Testy Happy Path i Unhappy Path dla klasy `FolderBackup`. Weryfikacja backupu wielu plików, pomijania niepoprawnych plików, oraz obsługi pustej listy. Testy dla metody `CalculateTotalSize()` z użyciem LINQ.

### Klasa AuthenticationServiceTests

Testy dla klasy `AuthenticationService` z użyciem `[Theory]` i `[InlineData]` do testów parametrycznych. Weryfikacja logowania i sprawdzania roli użytkownika.

### Klasa LoginPageTests i HomePageTests

Testy integracyjne dla wzorca Page Object - `LoginPage` i `HomePage`. Demonstracja testowania współpracy między komponentami z użyciem Dependency Injection.

---

## Nowe mechanizmy i wzorce

### Dependency Injection

Wprowadzenie interfejsu `IFileSystem` pozwala na izolację testów od systemu plików. Implementacje:
- `FileSystem` - produkcyjna implementacja używająca `File.Exists()`
- `FakeFileSystem` - implementacja testowa (test double) pozwalająca kontrolować zachowanie w testach

### Programowanie asynchroniczne

Metoda `BackupAsync()` demonstruje użycie `async/await` w C#. Testowanie metod asynchronicznych w xUnit wymaga użycia `async Task` w sygnaturze testu.

### LINQ

Użycie LINQ `Sum()` z wyrażeniem lambda (`file => file.FileSizeInBytes`) do operacji na kolekcjach zamiast tradycyjnych pętli `foreach`.

### AuthenticationService

Klasa serwisu z logiką autentykacji:
- Właściwość `IsAuthenticated` z `private set` do śledzenia stanu
- Metoda `Login()` z walidacją
- Metoda `IsInRole()` do sprawdzania roli użytkownika

### UserAccount

Klasa z mechanizmem bezpieczeństwa:
- Śledzenie nieudanych prób logowania (`FailedLoginAttempts`)
- Blokowanie konta po przekroczeniu limitu (`MaxLoginAttempts = 3`)
- Właściwość `IsLocked` z `private set`
- Rzucanie `InvalidOperationException` przy próbie logowania na zablokowane konto

### Page Object Pattern

Wzorzec reprezentujący strony aplikacji jako klasy:
- `LoginPage` - reprezentacja strony logowania
- `HomePage` - reprezentacja strony głównej z właściwością `IsAuthorized`
- Dependency Injection - strony otrzymują `AuthenticationService` przez konstruktor
- Testowanie integracji komponentów

---

## Powrót do tagu unit-test-foundations

Aby wrócić do stanu projektu z tagiem `unit-test-foundations` (zawierającego opis projektów BackupSystem.Core i BackupSystem.UnitTests):

```bash
git checkout unit-test-foundations
```

Aby wrócić do najnowszej wersji na gałęzi `main`:

```bash
git checkout main
```

