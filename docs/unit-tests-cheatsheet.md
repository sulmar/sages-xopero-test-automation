# Unit Tests – ściąga
## Podstawy testów jednostkowych (xUnit)

Ten dokument to **praktyczna ściąga** do pisania
czytelnych i użytecznych testów jednostkowych.

---

## Struktura testu: AAA

Każdy test powinien składać się z trzech części:

### Arrange  
Przygotowanie danych i obiektów

### Act  
Wykonanie akcji, którą testujemy

### Assert  
Sprawdzenie rezultatu

```csharp
// Arrange
var fileBackup = new FileBackup("report.pdf");

// Act
fileBackup.Backup();

// Assert
Assert.True(fileBackup.IsBackedUp);
```


---

## Nazewnictwo testów

Stosuj konwencję:

```
MethodName_Scenario_ExpectedBehavior
```

Przykład
```cs
public void Backup_WhenFileNameIsValid_MarksFileAsBackedUp()
```


Dobra nazwa testu:
-	opisuje zachowanie
-	jest dokumentacją
-	nie wymaga komentarzy


---

## [Fact] vs [Theory]


### [Fact]

Gdy test ma jeden scenariusz
```cs
[Fact]
public void Backup_WhenCalled_MarksFileAsBackedUp()
```

---

### [Theory]

Gdy ta sama logika jest testowana dla różnych danych


```cs
[Theory]
[InlineData(0)]
[InlineData(7)]
[InlineData(10)]
public void Evaluate_WhenDaysProvided_ReturnsExpectedResult(int days)
{
    // ...
}
```

➡️ Theory = mniej duplikacji

---

## Testowanie wyjątków

Gdy błąd jest oczekiwanym zachowaniem

```cs
Assert.Throws<InvalidOperationException>(() => fileBackup.Backup());
```

Dla metod asynchronicznych:
```cs
await Assert.ThrowsAsync<InvalidOperationException>(() =>
    service.BackupAsync());
```

---

## Testy asynchroniczne
- test też musi być `async`
- test musi zwracać `Task`
- zawsze używaj `await`


❌ Nie używaj .Wait() ani .Result

---

## Czego NIE testujemy
- metod prywatnych
- szczegółów implementacji
- logiki frameworków

---

## Dobre praktyki

- jeden test = jedno zachowanie
- test powinien być krótki
- test musi być czytelny bez komentarzy
- test nie powinien zależeć od innych testów


## Podsumowanie

> Dobry test mówi „co system robi”.
>
> Zły test mówi „jak został napisany”.
