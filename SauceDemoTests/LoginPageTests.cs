// <copyright file="LoginPageTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemoTests
{
    using OpenQA.Selenium;
    using SauceDemo;
    using SauceDemo.Constants;
    using SauceDemo.Pages;
    using SauceDemo.Utilities;

    /// <summary>
    /// Test class which holds all the test methods which ensure that the login functionality on the website that's being tested work flawlessly.
    /// </summary>
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    public class LoginPageTests
    {
        private readonly string browser = "chrome";
        private IWebDriver webDriver;

        /// <summary>
        /// Main SetUp Method which is responsible for initializing all the neccessary objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.webDriver = Driver.Initialize(this.browser);
            this.webDriver.Navigate().GoToUrl(DataConstants.WebDriver.Url);
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
            // Arrange
            var loginPage = new LoginPage(this.webDriver);

            // Act
            var loginResult = loginPage.LoginWithoutPassword(username, password);

            // Assert
            Assert.That(loginResult.GetPasswordRequiredErrorMessage(), Is.EqualTo("Epic sadface: Password is required"));
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
            // Arrange
            var loginPage = new LoginPage(this.webDriver);

            // Act
            var mainPage = loginPage.LoginWithPassword(username, password);

            Assert.Multiple(() =>
            {
                Assert.That(mainPage.IsBurgerMenuButtonPresent(), Is.True);
                Assert.That(mainPage.IsHeadingLablePresent(), Is.EqualTo("Swag Labs"));
                Assert.That(mainPage.IsShoppingCartIconPresent(), Is.True);
                Assert.That(mainPage.IsProductSortContainerPresent(), Is.True);
                Assert.That(mainPage.IsInventoryListPresent(), Is.True);
            });
        }

        /// <summary>
        /// Tear down method which is responsible for destroying i.e closing and quitting from the current active WebDriver instance.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.webDriver?.Quit();
            this.webDriver?.Dispose();
            WebDriverUtilities.Kill();
        }
    }
}
