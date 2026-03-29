// <copyright file="LoginPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Constants;
    using SauceDemo.Utilities;

    /// <summary>
    /// The Login Page Class which is responsible for automating the whole process of loggining into an account and encapsulating the logic for that.
    /// </summary>
    public class LoginPage
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver webDriver;
        private readonly Actions actions;

        private readonly By usernameInputFieldSelector = By.CssSelector(DataConstants.LoginPageConstants.UsernameInputFieldCssSelector);
        private readonly By passwordInputFieldSelector = By.CssSelector(DataConstants.LoginPageConstants.PasswordInputFieldCssSelector);
        private readonly By loginButtonSelector = By.CssSelector(DataConstants.LoginPageConstants.LoginButtonCssSelector);
        private readonly By passwordRequiredErrorMessageSelector = By.CssSelector(DataConstants.LoginPageConstants.PasswordRequiredErrorLoginMessageCssSelector);

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="webDriver">The WebDriver instances passed down to the login page constructor.</param>
        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(30));
            this.actions = new Actions(this.webDriver);
        }

        /// <summary>
        /// Method responsible for automating the process of logging into an account as part of the given website that needs to be tested.
        /// Specifically tests the funcitonality as it is intended to be used i.e. by providing all the necessary credentials.
        /// </summary>
        /// <param name="username">Username to attempt to login with.</param>
        /// <param name="password">Password to attempt to login with.</param>
        /// <returns>An element present only on the main page to determine whether a redirect upon successful login was actually achieved.</returns>
        public MainPage LoginWithPassword(string username, string password)
        {
            var (usernameInputField, passwordInputField, loginButton) = this.GetLoginFormElements();
            WebDriverUtilities.InteractWithInputElement(this.actions, usernameInputField, username);
            WebDriverUtilities.InteractWithInputElement(this.actions, passwordInputField, password);
            WebDriverUtilities.InteractWithButton(this.actions, loginButton);
            return new MainPage(this.webDriver);
        }

        /// <summary>
        /// Method responsible for automating the process of logging into an account as part of the given website that needs to be tested.
        /// Tests the functionality without providing a password.
        /// </summary>
        /// <returns>IPage Interface to determine whether a login attempt was successful by redirecting to main page or not.</returns>
        /// <param name="username">The username necessary for testing the login functionality.</param>
        /// <param name="password">The password necessary for testing the login functuonality.</param>
        public LoginPage LoginWithoutPassword(string username, string password)
        {
            var (usernameInputField, passwordInputField, loginButton) = this.GetLoginFormElements();
            WebDriverUtilities.InteractWithInputElement(this.actions, usernameInputField, username);
            WebDriverUtilities.InteractWithInputElement(this.actions, passwordInputField, password);
            WebDriverUtilities.ClearOutPasswordField(this.actions, passwordInputField);

            if (passwordInputField.GetAttribute("value") == string.Empty)
            {
                WebDriverUtilities.InteractWithButton(this.actions, loginButton);
            }

            return new LoginPage(this.webDriver);
        }

        /// <summary>
        /// Method which finds the error message element that's displayed upon unsuccessful login.
        /// </summary>
        /// <returns>The text of the password required error element.</returns>
        public string GetPasswordRequiredErrorMessage()
        {
            return this.wait.Until(driver => this.webDriver.FindElement(this.passwordRequiredErrorMessageSelector)).Text;
        }

        private (IWebElement username, IWebElement password, IWebElement loginButton) GetLoginFormElements()
        {
            var usernameInputField = this.webDriver.FindElement(this.usernameInputFieldSelector);
            var passwordInputField = this.webDriver.FindElement(this.passwordInputFieldSelector);
            var loginButton = this.webDriver.FindElement(this.loginButtonSelector);
            this.WaitUntilLoginFormElementsAreDisplayed(usernameInputField, passwordInputField, loginButton);
            return (usernameInputField, passwordInputField, loginButton);
        }

        private void WaitUntilLoginFormElementsAreDisplayed(IWebElement usernameInputField, IWebElement passwordInputField, IWebElement loginButton)
        {
            this.wait.Until(driver => usernameInputField.Displayed ? usernameInputField : null);
            this.wait.Until(driver => passwordInputField.Displayed ? passwordInputField : null);
            this.wait.Until(driver => loginButton.Displayed ? loginButton : null);
        }
    }
}
