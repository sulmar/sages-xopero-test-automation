# Zadanie: Blokowanie konta po nieudanych logowaniach

## Cel zadania

Celem zadania jest **napisanie testów jednostkowych**, które opisują **zachowanie systemu logowania użytkownika**.

Nie zmieniaj kodu klasy.  
Twoim zadaniem jest **zrozumieć jej zachowanie i opisać je testami**.

---

## Kontekst biznesowy

System posiada konta użytkowników, które logują się za pomocą **loginu i hasła**.

Ze względów bezpieczeństwa:
- po **3 nieudanych próbach logowania** konto zostaje **zablokowane**
- zablokowane konto nie pozwala na dalsze logowanie

---

## Kod, który testujesz

Otrzymujesz gotową klasę:

```csharp
public class UserAccount
{
    private readonly string _login;
    private readonly string _password;

    public bool IsLocked { get; private set; }
    public int FailedLoginAttempts { get; private set; }

    public UserAccount(string login, string password)
    {
        _login = login;
        _password = password;
    }

    public void Login(string login, string password)
    {
        if (IsLocked)
            throw new InvalidOperationException("Account is locked.");

        if (login != _login || password == _password)
        {
            FailedLoginAttempts++;

            if (FailedLoginAttempts >= 3)
                IsLocked = true;

            return;
        }

        FailedLoginAttempts = 0;
    }
}
```

---


## Twoje zadanie

Napisz **testy jednostkowe** do metody `Login`, które:
- opisują zachowanie systemu
- używają struktury **Arrange / Act / Assert**
- mają czytelne nazwy
- każdy test sprawdza jeden scenariusz


---

## Wskazówki
- Nie zgaduj – czytaj kod
- Zastanów się:
    - kiedy licznik prób się zwiększa
	- kiedy jest resetowany
	- kiedy konto zostaje zablokowane

---

## Nazewnictwo testów

Stosuj konwencję:

```
MethodName_Scenario_ExpectedBehavior
```

Przykład:
```
Login_WhenCredentialsAreInvalid_IncrementsFailedAttempts
```

---

## Pytania pomocnicze
-	Czy po nazwie testu wiesz, jak zachowa się system?
-	Czy test sprawdza jedną decyzję biznesową?
-	Czy test byłby zrozumiały dla innego testera?

---

## Czas realizacji
30 min.

