// <copyright file="LoginPageTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemoTests
{
    using OpenQA.Selenium;
    using SauceDemo;
    using SauceDemo.Constants;
    using SauceDemo.Pages;

    /// <summary>
    /// Test class which holds all the test methods which ensure that the login functionality on the website that's being tested work flawlessly.
    /// </summary>
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class LoginPageTests
    {
        private readonly string browser = "edge";
        private IWebDriver webDriver;
        private LoginPage loginPage;

        /// <summary>
        /// Main SetUp Method which is responsible for initializing all the neccessary objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.webDriver = Driver.Initialize(this.browser);
            this.webDriver.Navigate().GoToUrl(DataConstants.WebDriver.Url);
            this.loginPage = new LoginPage(this.webDriver);
            TestContext.Out.WriteLine($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        /// <summary>
        /// Test method which ensures that when login attempt without a password is made, it should fail.
        /// </summary>
        /// <param name="username">Username to test the login functionality with.</param>
        /// <param name="password">Password to test the login functionality with.</param>
        [Test]
        [TestCase("error_user", "secret_sauce")]
        [TestCase("visual_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        public void LoginWithoutPasswordShouldFail(string username, string password)
        {
            TestContext.Out.WriteLine($"Testing with user: {username} on browser: {this.browser}");
            var loginResult = this.loginPage.LoginWithoutPassword(username, password);
            Assert.That(loginResult.GetPasswordRequiredErrorMessage(), Is.EqualTo("Epic sadface: Password is required"), "Password is required.");
            TestContext.Out.WriteLine($"Login result: {loginResult.GetPasswordRequiredErrorMessage().Split(": ")[1]}");
        }

        /// <summary>
        /// Test method which ensures that when login attempt with entirely correct credentials is made, it should succeed.
        /// </summary>
        /// <param name="username">Username to test the login functionality with.</param>
        /// <param name="password">Password to test the login functionality with.</param>
        [Test]
        [TestCase("error_user", "secret_sauce")]
        [TestCase("visual_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        public void LoginWithCorrectCredentialsShouldSucceed(string username, string password)
        {
            TestContext.Out.WriteLine($"Testing with user: {username} on browser: {this.browser}");
            var mainPage = this.loginPage.LoginWithPassword(username, password);

            Assert.Multiple(() =>
            {
                TestContext.Out.WriteLine($"Burger menu present: {mainPage.IsBurgerMenuButtonPresent()}");
                Assert.That(mainPage.IsBurgerMenuButtonPresent(), Is.True, "Burger menu button not found.");

                TestContext.Out.WriteLine($"Heading lable present: {mainPage.IsHeadingLablePresent()}");
                Assert.That(mainPage.IsHeadingLablePresent(), Is.True, "Heading lable not found.");

                TestContext.Out.WriteLine($"Shopping cart icon present: {mainPage.IsShoppingCartIconPresent()}");
                Assert.That(mainPage.IsShoppingCartIconPresent(), Is.True, "Shopping cart icon not found.");

                TestContext.Out.WriteLine($"Product sort container present: {mainPage.IsProductSortContainerPresent()}");
                Assert.That(mainPage.IsProductSortContainerPresent(), Is.True, "Product sort container not found.");

                TestContext.Out.WriteLine($"Inventory list present: {mainPage.IsInventoryListPresent()}");
                Assert.That(mainPage.IsInventoryListPresent(), Is.True, "Inventory list not found");
            });
        }

        /// <summary>
        /// Tear down method which is responsible for destroying i.e closing and quitting from the current active WebDriver instance.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            TestContext.Out.WriteLine($"Test finished with status: {TestContext.CurrentContext.Result.Outcome}");
            this.webDriver?.Quit();
            this.webDriver?.Dispose();
        }
    }
}
