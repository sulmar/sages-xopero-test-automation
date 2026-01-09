# Testy jednostkowe – przygotowanie projektu (.NET / C#)

Instrukcja przygotowania podstawowej struktury do testów jednostkowych w .NET:  
sprawdzenie SDK, ustawienie `global.json`, utworzenie **Solution** oraz projektów **Core** i **UnitTests**.

---

## Wymagania wstępne

- .NET SDK (zalecane: 9.0.308)
- dostęp do terminala (PowerShell / zsh / bash)

Sprawdzenie wersji:

```bash
dotnet --version
```

Sprawdzenie wszystkich zainstalowanych SDK:

```bash
dotnet --list-sdks
```

> 💡 Jeśli `dotnet` nie działa: doinstaluj .NET SDK i upewnij się, że jest na `PATH`.

---

## 1. Ustawienie `global.json` (wymuszenie wersji SDK)

`global.json` warto dodać w katalogu głównym repozytorium, żeby każdy miał tę samą wersję SDK.

### Opcja A – utworzenie pliku z terminala

W katalogu repozytorium:

```bash
dotnet new globaljson --sdk 9.0.308
```

> Zamiast `9.0.308` wpisz konkretną wersję, którą widzisz w `dotnet --list-sdks`.

### Opcja B – ręcznie (gdy chcesz wkleić gotową wersję)

Utwórz plik `global.json` w katalogu repozytorium:

```json
{
  "sdk": {
    "version": "9.0.308"
  }
}
```

Sprawdzenie, czy repo używa wskazanego SDK:

```bash
dotnet --version
```

---

## 2. Utworzenie Solution

W katalogu repozytorium (tam gdzie chcesz trzymać `.sln`):

```bash
dotnet new sln -n BackupSystem
```

> 💡 Nazwa Solution nie musi odpowiadać nazwie repo, ale powinna być spójna z projektami.

---

## 3. Utworzenie projektu „Core” (Class Library)

Najczęstszy układ katalogów to `src/` na kod i `tests/` na testy.

```bash
mkdir -p src tests
dotnet new classlib -n BackupSystem.Core -o src/BackupSystem.Core
```

Dodanie projektu do Solution:

```bash
dotnet sln BackupSystem.sln add src/BackupSystem.Core/BackupSystem.Core.csproj
```

---

## 4. Utworzenie projektu testów jednostkowych (xUnit)

```bash
dotnet new xunit -n BackupSystem.Core.UnitTests -o tests/BackupSystem.Core.UnitTests
```

Dodanie projektu testowego do Solution:

```bash
dotnet sln BackupSystem.sln add tests/BackupSystem.Core.UnitTests/BackupSystem.Core.UnitTests.csproj
```

---

## 5. Referencja testów do „Core”

Testy muszą widzieć kod z `BackupSystem.Core`.

```bash
dotnet add tests/BackupSystem.Core.UnitTests/BackupSystem.Core.UnitTests.csproj reference src/BackupSystem.Core/BackupSystem.Core.csproj
```

---

## 6. Przywrócenie paczek i uruchomienie testów

```bash
dotnet restore
dotnet test
```

> 💡 Jeśli chcesz uruchomić tylko testy z jednego projektu:
>
> ```bash
> dotnet test tests/BackupSystem.Core.UnitTests/BackupSystem.Core.UnitTests.csproj
> ```

---

## Rekomendacje

- Trzymaj logikę domenową w `Core`, a testy w `UnitTests` – bez mieszania
- Pierwsze testy niech będą małe i „czytelne jak dokumentacja”
- Jeśli w zespole są różne systemy (Windows/macOS), `global.json` oszczędza dużo czasu

