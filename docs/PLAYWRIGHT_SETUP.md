# Playwright – instalacja (C# / .NET)

Instrukcja instalacji Playwrighta do testów UI w .NET  
z uwzględnieniem systemów **Windows** i **macOS**.

---

## Wymagania wstępne

- .NET SDK 8 lub 9
- dostęp do terminala (PowerShell / zsh / bash)

Sprawdzenie:

```bash
dotnet --version
```

---

## 1. Utworzenie nowego projektu testowego (xUnit)

```bash
dotnet new xunit -n BackupSystem.Ui.Tests
cd BackupSystem.Ui.Tests
```

> 💡 Testy UI trzymamy w **osobnym projekcie**, oddzielnie od testów API.

---

## 2. Dodanie Playwrighta do projektu

```bash
dotnet add package Microsoft.Playwright
dotnet restore
```

---

## 3. Instalacja Playwright CLI (jednorazowo na maszynę)

### Windows / macOS

```bash
dotnet tool install --global Microsoft.Playwright.CLI
```

Sprawdzenie instalacji:

```bash
playwright --version
```

---

### ⚠️ macOS – jeśli polecenie `playwright` nie jest widoczne

Dodaj katalog z narzędziami .NET do `PATH`.

Edytuj plik konfiguracyjny powłoki:

```bash
nano ~/.zshrc
```

Dodaj na końcu pliku:

```bash
export PATH="$PATH:$HOME/.dotnet/tools"
```

Zapisz i przeładuj konfigurację:

```bash
source ~/.zshrc
```

Ponownie sprawdź:

```bash
playwright --version
```

---

## 4. Instalacja przeglądarek

Z katalogu projektu testowego:

### Windows / macOS

```bash
playwright install
```

Lub tylko Chromium (szybciej):

```bash
playwright install chromium
```

> 💡 Playwright używa **prawdziwych przeglądarek**, nie emulatorów.

---

## 5. Uruchomienie testów

```bash
dotnet test
```

---

## Rekomendacje

- Pierwszy test powinien być **smoke testem**  
  (np. otwarcie `https://example.com`)
- Instalację Playwright CLI wykonuje się **raz na maszynę**
- Testy UI są wolniejsze — nie mieszaj ich z testami jednostkowymi
- Testy UI testują **zachowanie użytkownika**, nie HTML

---

## Smoke test – czym jest?

Smoke test odpowiada na pytanie:

> **Czy system w ogóle działa i da się go uruchomić?**

Nie sprawdza pełnej funkcjonalności —  
daje jedynie „zielone światło” do dalszych testów.
