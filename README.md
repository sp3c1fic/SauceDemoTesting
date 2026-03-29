SauceDemo Automated Test Suite
Overview
Automated end-to-end test suite for the SauceDemo web application, built with Selenium WebDriver, NUnit, and C# following the Page Object Model design pattern.
Tech Stack

C# / .NET
Selenium WebDriver
NUnit
Page Object Model (POM)

Features

Cross-browser support (Chrome, Firefox, Edge)
Headless execution
Randomized user agent per test run
Explicit waits throughout
Structured logging via NUnit TestContext

Test Coverage

Login functionality across all available user accounts
Inventory page element verification
Add to cart functionality
Known defect handling for problem_user

Project Structure

Pages — Page object classes for Login and Main page
Tests — NUnit test classes
Constants — CSS selectors and test data
Utilities — WebDriver configuration and reusable interaction helpers

Notes
problem_user has intentionally broken add-to-cart functionality by design. A dedicated test exists to assert this known defect.