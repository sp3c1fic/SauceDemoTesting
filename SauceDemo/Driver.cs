// <copyright file="Driver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Safari;
    using SauceDemo.Constants;

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
                return webDriverName switch
                {
                        DataConstants.WebDriver.ChromeDriverBrowserName => new ChromeDriver(GetChromeOptions()),
                        DataConstants.WebDriver.FirefoxDriverBrowserName => new FirefoxDriver(GetFirefoxOptions()),
                        DataConstants.WebDriver.SafariDriverBrowserName => new SafariDriver(),
                        DataConstants.WebDriver.EdgeDriverBrowserName => new EdgeDriver(GetEdgeOptions()),
                        _ => throw new ArgumentException($"Unsupported browser: {webDriverName}"),
                };
        }

        private static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            return chromeOptions;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            return firefoxOptions;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--headless");
            return edgeOptions;
        }
    }
}
