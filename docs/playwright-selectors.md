# Playwright – selektory (C#)

## 1️⃣ `data-test` / `data-testid` ✅ Najlepszy wybór
```cs
await page.ClickAsync("[data-test='login-button']");
```
Stabilne, tworzone specjalnie do testów. 

---

## 2️⃣ id 
```cs
await page.FillAsync("#user-name", "standard_user");
```

Czytelne i szybkie

---


## 3️⃣ Atrybuty HTML

```cs
await page.ClickAsync("button[type='submit']");
```

Gdy brak `data-test`

---

## 4️⃣ Klasy CSS

```cs
await page.Locator(".shopping_cart_badge").IsVisibleAsync();
```

Tylko gdy musisz.

*(wygląd strony często się zmienia)*

---

5️⃣ XPath ❌ OSTATECZNOŚĆ

```cs
await page.WaitForSelectorAsync("//h3[@data-test='error']");
```

Mało czytelne, trudne w utrzymaniu

---

## 6️⃣ Po zawartości elementu

```cs
await page.GetByText("Epic sadface").IsVisibleAsync();
```

Dobre to sprawdzanie komunikatów

---


## 7️⃣ Role dostępności (GetByRole)


```cs
await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
```

Zgodne z accessibility ale wymaga poprawnie zrobionego HTML

---



