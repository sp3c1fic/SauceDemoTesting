# 🧪 SauceDemo Automated Test Suite

## Overview

Automated end-to-end test suite for the [SauceDemo](https://www.saucedemo.com/) web application, built with **Selenium WebDriver**, **NUnit**, and **C#**, following the **Page Object Model (POM)** design pattern.

---

## 🛠 Tech Stack

| Technology | Purpose |
|---|---|
| C# / .NET | Core language |
| Selenium WebDriver | Browser automation |
| NUnit | Test framework |
| WebDriverManager | Automatic driver management |

---

## ✅ Features

- ✔ Cross-browser support — **Chrome**, **Firefox**, **Edge**
- ✔ Headless execution
- ✔ Randomized user agent per test run
- ✔ Explicit waits throughout — no hardcoded `Thread.Sleep`
- ✔ Structured logging via NUnit `TestContext`
- ✔ Known defect coverage for `problem_user`

---

## 🧾 Test Coverage

| Area | Description |
|---|---|
| Login | Valid credentials across all user accounts |
| Login | Attempt without password |
| Login | Locked out user handling |
| Inventory | Page element verification post-login |
| Shopping Cart | Add all items to cart, verify badge count |
| Defect | `problem_user` broken add-to-cart assertion |

---

## 📁 Project Structure

```
SauceDemo/
├── Constants/
│   └── DataConstants.cs        # CSS selectors and test data
├── Pages/
│   ├── LoginPage.cs            # Login page object
│   └── MainPage.cs             # Inventory/main page object
├── Tests/
│   └── *.cs                    # NUnit test classes
└── Utilities/
    └── WebDriverUtilities.cs   # Driver config and interaction helpers
```

---

## 👤 Test Users

SauceDemo provides several built-in user accounts, each simulating different application behaviors:

| Username | Behavior |
|---|---|
| `standard_user` | Normal functionality |
| `locked_out_user` | Login blocked |
| `problem_user` | Broken UI interactions (intentional defect) |
| `performance_glitch_user` | Artificial delays |
| `error_user` | Specific interactions throw errors |
| `visual_user` | Visual/layout bugs |

> ⚠️ `problem_user` has intentionally broken add-to-cart functionality by design. A dedicated test exists to assert this known defect rather than treat it as a test failure.

---

## ▶️ Running the Tests

```bash
dotnet test
```

To run for a specific browser, configure the driver in the test setup or pass it as a parameter.

---

## 📝 Notes

- All page interactions go through the **Page Object layer** — no direct WebDriver calls in tests.
- Driver lifecycle is managed in `[SetUp]` and `[TearDown]` to ensure clean state per test.
- The `problem_user` broken behavior is a documented defect, not a gap in test coverage.