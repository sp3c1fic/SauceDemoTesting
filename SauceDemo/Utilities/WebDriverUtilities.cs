// <copyright file="WebDriverUtilities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Utilities
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
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
        public static void InteractWithButton(Actions actions, IWebElement submitButton)
        {
            actions
                .Pause(TimeSpan.FromSeconds(3))
                .Click(submitButton)
                .Pause(TimeSpan.FromSeconds(3))
                .Perform();
        }

        /// <summary>
        /// Helper method which picks a random user agent from a pre-defined list to avoid website restrictions if any are present.
        /// </summary>
        /// <returns>The user agent as string.</returns>
        public static string RandomizeUserAgent()
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, DataConstants.WebDriver.UserAgents.Length - 1);
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

        /// <summary>
        /// Method responsible for clearing out the password field simulating a user action.
        /// </summary>
        /// <param name="actions">The actions object which provides a mechanism to interact with the browser.</param>
        /// <param name="passwordInputElement">The password input field element where the password text has to be filled in.</param>
        public static void ClearOutPasswordField(Actions actions, IWebElement passwordInputElement)
        {
            actions
                .Click(passwordInputElement)
                .KeyDown(Keys.LeftControl)
                .KeyDown("a")
                .KeyUp("a")
                .KeyUp(Keys.LeftControl)
                .Pause(TimeSpan.FromMilliseconds(300))
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Pause(TimeSpan.FromMilliseconds(300))
                .Perform();
        }
    }
}
