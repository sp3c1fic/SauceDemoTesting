// <copyright file="MainPageTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemoTests
{
    using OpenQA.Selenium;
    using SauceDemo;
    using SauceDemo.Constants;
    using SauceDemo.Pages;

    /// <summary>
    /// Test class which holds all the test methods which ensure that the functionality responsible for adding products to the shopping cart that's being tested work flawlessly.
    /// </summary>
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class MainPageTests
    {
        private readonly string browser = "chrome";
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
        /// Test method to check if add to cart functionality works flawlessly.
        /// </summary>
        /// <param name="username">Login username.</param>
        /// <param name="password">Login password.</param>
        [Test]
        [TestCase("error_user", "secret_sauce")]
        [TestCase("visual_user", "secret_sauce")]
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        public void AddItemsToShoppingCartShouldSucceed(string username, string password)
        {
            var mainPage = this.loginPage.LoginWithPassword(username, password);
            var isAllAdded = mainPage.AddItemsToShoppingCart();
            Assert.That(isAllAdded, Has.Exactly(6).EqualTo(true), "Not all items have been successfully added to the cart.");
            TestContext.Out.WriteLine($"Adding items to the cart result succeeded: {isAllAdded.All(v => v.Equals(true))}");
        }

        /// <summary>
        /// This test function tests adding products to the shopping cart with user which is intentionally broken and assures that the functionality doesn't work right and throws and exception.
        /// </summary>
        /// <param name="username">Login username.</param>
        /// <param name="password">Login password.</param>
        [Test]
        [TestCase("problem_user", "secret_sauce")]
        public void AddItemsToShoppingCartAsProblemUserShouldThrowException(string username, string password)
        {
            var mainPage = this.loginPage.LoginWithPassword(username, password);
            Assert.Throws<NoSuchElementException>(() => mainPage.AddItemsToShoppingCart(), "Shopping cart badge couldn't be found.");
            TestContext.Out.WriteLine($"Adding items as '{username}' should result in a '{typeof(NoSuchElementException)}' since the shopping cart badge cannot be located. ");
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
