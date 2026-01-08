# Zadanie: Ocena stanu backupu (testy jednostkowe)

## Cel zadania

Celem zadania jest **opisanie zachowania systemu backupów za pomocą testów jednostkowych**, a następnie zaimplementowanie prostej logiki, tak aby testy przechodziły.

Skupiamy się na:
- zrozumieniu **zachowania systemu**
- pisaniu **czytelnych testów**
- pracy w schemacie **Arrange / Act / Assert**


## Kontekst biznesowy

System backupów powinien informować, **czy backup jest aktualny**,  
na podstawie **liczby dni od ostatniego backupu**.

Jeśli backup **nigdy nie był wykonany**, system otrzymuje wartość `-1`.

---

## API do zaimplementowania

Na początek otrzymujesz tylko sygnaturę metody:

```csharp
public class BackupHealthChecker
{
    public string Evaluate(int daysSinceLastBackup)
    {
        throw new NotImplementedException();
    }
}
```

Nie zmieniaj sygnatury metody.

---

## Zasady (do opisania testami)
- jeśli `daysSinceLastBackup == -1` → `"Missing"`
- jeśli `daysSinceLastBackup == 0` → `"Healthy"`
- jeśli `daysSinceLastBackup <= 7` → `"Healthy"`
- jeśli `daysSinceLastBackup > 7` → `"Outdated"`

Zwróć uwagę na warunek brzegowy: 7 dni.

---

## Wymagania do testów
- testy jednostkowe w xUnit
- czytelne nazwy testów
- struktura Arrange / Act / Assert
- jeden test = jeden scenariusz

Przykładowy schemat nazwy testu:
```
MethodName_Scenario_ExpectedBehavior
```

---

## Wskazówki
- Zacznij od testów, nie od implementacji
- Nie przejmuj się elegancją kodu – liczy się zachowanie
- Jeśli test jasno tłumaczy, co ma się wydarzyć, jest dobry

---

## Pytania pomocnicze
- Czy po przeczytaniu testu wiesz, jak system się zachowa?
- Czy test sprawdza jedną konkretną decyzję?
- Czy test byłby zrozumiały dla innego testera?

---