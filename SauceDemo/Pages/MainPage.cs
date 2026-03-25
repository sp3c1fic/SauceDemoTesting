// <copyright file="MainPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class MainPage
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver webDriver;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.webDriver = Driver.Initialize("chrome");
            this.wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(20));
        }
    }
}
