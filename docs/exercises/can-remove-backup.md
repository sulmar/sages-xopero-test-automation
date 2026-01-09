# Zadanie: Usuwanie backupu – reguły biznesowe

## Cel zadania
Twoim celem jest napisanie **testów jednostkowych**, które opisują,
kiedy backup **może** zostać usunięty.

Na podstawie testów sprawdzisz, czy aktualna implementacja
zachowuje się zgodnie z oczekiwaniami biznesowymi.

---

## Kod startowy

Poniżej znajduje się fragment kodu, na którym będziesz pracować:


```csharp
public bool CanDelete(DateTime now)
{
    if (!IsBackedUp)
        return false;

     return DaysSinceCreated(now) > 7;
}

private int DaysSinceCreated(DateTime now)
{
    return (now - CreatedOn).Days;
}

```

---

## Reguły biznesowe

Backup **można usunąć tylko wtedy**, gdy:
- backup został utworzony
- od momentu jego utworzenia minęło **więcej niż 7 dni**


--- 

## Twoje zadanie

Napisz testy jednostkowe, które w czytelny sposób opisują powyższe reguły.

Testy powinny jednoznacznie odpowiadać na pytanie:

- *Czy w danym przypadku backup może zostać usunięty?*


---

Wskazówki
- Testy opisują zachowanie, nie implementację
- Czas (DateTime) jest przekazywany jako parametr



---

## Nazewnictwo testów

Stosuj konwencję:

```
MethodName_Scenario_ExpectedBehavior
```


---

## Czas realizacji
45 min.
