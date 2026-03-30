// <copyright file="WebDriverUtilities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Utilities
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    /// <summary>
    /// Helper class that will keep repetitive functions necessary for all kinds of operations such as interacting with web elements and so on.
    /// </summary>
    public static class WebDriverUtilities
    {
        private static readonly string[] UserAgents = { "windows|Mozilla/5.0 (compatible; MSIE 11.0; Windows NT 6.3; Win64; x64 Trident/7.0)", "explorer|Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.1; x64; en-US Trident/4.0)", "iphone|Mozilla/5.0 (iPhone; CPU iPhone OS 8_4_7; like Mac OS X) AppleWebKit/537.9 (KHTML, like Gecko)  Chrome/53.0.1226.146 Mobile Safari/603.6", "edge|Mozilla/5.0 (Windows; U; Windows NT 10.0;) AppleWebKit/601.27 (KHTML, like Gecko) Chrome/55.0.2947.247 Safari/600.1 Edge/10.72103", "mac|Mozilla/5.0 (Macintosh; U; Intel Mac OS X 9_1_2) AppleWebKit/600.16 (KHTML, like Gecko) Chrome/48.0.3501.370 Safari/602", "linux|Mozilla/5.0 (Linux x86_64; en-US) AppleWebKit/537.12 (KHTML, like Gecko) Chrome/53.0.2590.164 Safari/603", "windows|Mozilla/5.0 (compatible; MSIE 11.0; Windows; U; Windows NT 6.2; x64 Trident/7.0)", "windows|Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64 Trident/5.0)", "windows|Mozilla/5.0 (compatible; MSIE 8.0; Windows; Windows NT 6.2; Win64; x64; en-US Trident/4.0)", "mobile|Mozilla/5.0 (iPad; CPU iPad OS 11_9_1 like Mac OS X) AppleWebKit/603.18 (KHTML, like Gecko)  Chrome/48.0.3597.172 Mobile Safari/534.9" };

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
            var randomIndex = rand.Next(0, UserAgents.Length - 1);
            var userAgent = UserAgents[randomIndex];
            return userAgent;
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
