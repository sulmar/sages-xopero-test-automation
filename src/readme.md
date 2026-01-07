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





