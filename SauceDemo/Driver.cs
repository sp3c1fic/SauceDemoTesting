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
        private static volatile IWebDriver? webDriver;

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
            if (webDriver == null)
            {
                if (webDriverName == DataConstants.WebDriver.ChromeDriverBrowserName)
                {
                    webDriver = new ChromeDriver();
                }
                else if (webDriverName == DataConstants.WebDriver.FirefoxDriverBrowserName)
                {
                    webDriver = new FirefoxDriver();
                }
                else if (webDriverName == DataConstants.WebDriver.SafariDriverBrowserName)
                {
                    webDriver = new SafariDriver();
                }
                else if (webDriverName == DataConstants.WebDriver.EdgeDriverBrowserName)
                {
                    webDriver = new EdgeDriver();
                }
            }

            return webDriver!;
        }

        /// <summary>
        /// Method that is responsible for quitting from and destroying the WebDriver instance.
        /// </summary>
        public static void QuitDriver()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver = null;
            }
        }
    }
}
