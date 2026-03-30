// <copyright file="Driver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using SauceDemo.Utilities;

    /// <summary>
    /// This class is responsible for initializing the Selenium Web Driver making sure to utilize the Singleton Principle approach.
    /// </summary>
    public class Driver
    {
        private Driver()
        {
        }

        /// <summary>
        /// Function responsible for initializing the Selenium Web Driver based on a given name parameter.
        /// </summary>
        /// <param name="webDriverName">This is the name of the web driver which should be initialized.</param>
        /// <returns>Returns the current WebDriver instance.</returns>
        public static IWebDriver Initialize(string webDriverName)
        {
                return webDriverName.ToLower() switch
                {
                        "chrome" => new ChromeDriver(GetDriverOptions<ChromeOptions>()),
                        "firefox" => new FirefoxDriver(GetDriverOptions<FirefoxOptions>()),
                        "edge" => new EdgeDriver(GetDriverOptions<EdgeOptions>()),
                        _ => throw new ArgumentException($"Unsupported browser: {webDriverName}"),
                };
        }

        private static T GetDriverOptions<T>()
            where T : DriverOptions, new()
        {
            var options = new T();
            var arguments = new[]
            {
                "--headless",
                $"user-agent={WebDriverUtilities.RandomizeUserAgent()}",
                "--disable-notifications",
                "--disable-popup-blocking",
                "--no-sandbox",
                "--incognito",
                "--disable-gpu", // harmless to include alongside headless
                "--disable-dev-shm-usage", // Good habbit if this runs in CI
                "--disable-blink-features=AutomationControlled", // Removes the web driver flag
            };

            switch (options)
            {
                case ChromeOptions chrome:
                    chrome.AddArguments(arguments);
                    break;
                case FirefoxOptions firefox:
                    firefox.AddArguments(arguments);
                    break;
                case EdgeOptions edge:
                    edge.AddArguments(arguments);
                    break;
            }

            return options;
        }
    }
}
