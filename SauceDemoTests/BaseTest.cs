// <copyright file="BaseTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemoTests
{
    using Microsoft.Extensions.Configuration;
    using OpenQA.Selenium;
    using SauceDemo;
    using SauceDemo.Pages;

    /// <summary>
    /// Base class for all test classes in the SauceDemo test suite.
    /// Provides shared configuration, WebDriver initialization, and setup/teardown logic
    /// to avoid duplication across test classes.
    /// All test classes should inherit from this class.
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// Provides the configuration instance built from appsettings.json.
        /// Used to retrieve external settings such as browser type and application URL.
        /// </summary>
        protected static readonly IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        /// <summary>
        /// The WebDriver instance used to control the browser during each test.
        /// Initialized in SetUp and disposed in TearDown.
        /// </summary>
        private IWebDriver webDriver;

        /// <summary>
        /// The LoginPage page object used to interact with the login page.
        /// Initialized in SetUp after the WebDriver navigates to the application URL.
        /// </summary>
        private LoginPage loginPage;

        /// <summary>
        /// Gets the WebDriver instance used to control the browser during each test.
        /// Initialized in SetUp and disposed in TearDown.
        /// </summary>
        protected IWebDriver WebDriver => this.webDriver;

        /// <summary>
        /// Gets the LoginPage page object used to interact with the login page.
        /// Initialized in SetUp after the WebDriver navigates to the application URL.
        /// </summary>
        protected LoginPage LoginPage => this.loginPage;

        /// <summary>
        /// Main SetUp Method which is responsible for initializing all the neccessary objects.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.webDriver = Driver.Initialize(Configuration["WebDriver:Browser"] !);
            this.webDriver.Navigate().GoToUrl(Configuration["WebDriver:Url"] !);
            this.loginPage = new LoginPage(this.webDriver);
            TestContext.Out.WriteLine($"Starting test: {TestContext.CurrentContext.Test.Name}");
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
