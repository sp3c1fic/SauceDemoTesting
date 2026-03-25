// <copyright file="WebDriverUtilities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Utilities
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Constants;

    /// <summary>
    /// Helper class that will keep repetitive functions necessary for all kinds of operations such as interacting with web elements and so on.
    /// </summary>
    public static class WebDriverUtilities
    {
        /// <summary>
        /// Helper method that interacts with an input web element.
        /// </summary>
        /// <param name="actions">The Actions class which provides mechanism for advanced interaction with the browser.</param>
        /// <param name="inputElement">The input element to be interacted with.</param>
        /// <param name="inputElementText">The input element text that should be inserted as value in the input field itself.</param>
        public static void InteractWithInputElement(Actions actions, IWebElement inputElement, string inputElementText)
        {
            actions
                .Click(inputElement)
                .Pause(TimeSpan.FromSeconds(3))
                .SendKeys(inputElementText)
                .Perform();
        }

        /// <summary>
        /// Helper method that interacts with submit buttons on the webpage.
        /// </summary>
        /// <param name="actions">The Actions class which provides mechanism for advanced interaction with the browser.</param>
        /// <param name="submitButton">The button which will be interacted with.</param>
        public static void InteractWithSubmitWithButton(Actions actions, IWebElement submitButton)
        {
            actions
                .Pause(TimeSpan.FromSeconds(3))
                .Click(submitButton)
                .Pause(TimeSpan.FromSeconds(3))
                .Perform();
        }

        public static string RandomizeUserAgent()
        {
            var rand = new Random();

            var randomIndex = rand.Next(0, DataConstants.WebDriver.UserAgents.Length - 1);

            Console.WriteLine(DataConstants.WebDriver.UserAgents[randomIndex]);

            var userAgent = DataConstants.WebDriver.UserAgents[randomIndex];

            return userAgent;
        }

        /// <summary>
        /// Utility method that picks a random username among the available ones.
        /// </summary>
        /// <returns>The chosen random username as string.</returns>
        public static string PickUsername()
        {
            var rand = new Random();

            var randomIndex = rand.Next(0, DataConstants.LoginPageConstants.Usernames.Length - 1);
            var username = DataConstants.LoginPageConstants.Usernames[randomIndex];
            return username;
        }

        public static void ClearOutPasswordField(Actions actions, IWebElement passwordInputElement)
        {
            while (passwordInputElement.GetAttribute("value") != string.Empty)
            {
                actions
                    .Click(passwordInputElement)
                    .KeyDown(Keys.Backspace)
                    .Perform();
            }
        }

    }
}
