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
    using SeleniumExtras.PageObjects;

    /// <summary>
    /// The Login Page Class which is responsible for automating the whole process of loggining into an account and encapsulating the logic for that.
    /// </summary>
    public class LoginPage
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver webDriver;
        private readonly Actions actions;

        [FindsBy(How = How.CssSelector, Using = DataConstants.LoginPageConstants.UsernameInputFieldCssSelector)]
        [CacheLookup]
        private readonly IWebElement? usernameInputField;

        [FindsBy(How = How.CssSelector, Using = DataConstants.LoginPageConstants.PasswordInputFieldCssSelector)]
        [CacheLookup]
        private readonly IWebElement? passwordInputField;

        [FindsBy(How = How.CssSelector, Using = DataConstants.LoginPageConstants.LoginButtonCssSelector)]
        [CacheLookup]
        private readonly IWebElement? loginButton;

        [FindsBy(How = How.CssSelector, Using = DataConstants.LoginPageConstants.PasswordRequiredErrorLoginMessageCssSelector)]
        [CacheLookup]
        private readonly IWebElement? passwordRequiredErrorMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.webDriver = Driver.Initialize("edge");
            this.wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(30));
            this.actions = new Actions(this.webDriver);
            PageFactory.InitElements(this.webDriver, this);
        }

        /// <summary>
        /// Method responsible for automating the process of logging into an account as part of the given website that needs to be tested.
        /// Specifically tests the funcitonality as it is intended to be used i.e. by providing all the necessary credentials.
        /// </summary>
        public void LoginWithPassword()
        {
            this.WaitUntilElementsAreDisplayed();

            var username = WebDriverUtilities.PickUsername();

            WebDriverUtilities.InteractWithInputElement(this.actions, this.usernameInputField!, username);
            WebDriverUtilities.InteractWithInputElement(this.actions, this.passwordInputField!, DataConstants.LoginPageConstants.Password);
            WebDriverUtilities.InteractWithSubmitWithButton(this.actions, this.loginButton!);
        }

        /// <summary>
        /// Method responsible for automating the process of logging into an account as part of the given website that needs to be tested.
        /// Tests the functionality without providing a password.
        /// </summary>
        public void LoginWithoutPassword()
        {
            this.WaitUntilElementsAreDisplayed();

            var username = WebDriverUtilities.PickUsername();

            WebDriverUtilities.InteractWithInputElement(this.actions, this.usernameInputField!, username);
            WebDriverUtilities.InteractWithInputElement(this.actions, this.passwordInputField!, DataConstants.LoginPageConstants.Password);

            WebDriverUtilities.ClearOutPasswordField(this.actions, this.passwordInputField!);

            if (this.passwordInputField!.GetAttribute("value") == string.Empty)
            {
                Console.WriteLine("Password field value is empty!");
                WebDriverUtilities.InteractWithSubmitWithButton(this.actions, this.loginButton!);
            }

            try
            {
                this.GetPasswordRequiredErrorMessage();
                Console.WriteLine("Login failed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Login succeeded!");
            }
        }

        /// <summary>
        /// Method responsible for opening a url by utilizing Selenium WebDriver.
        /// </summary>
        /// <returns>The current instance of the class so methods can be chained together.</returns>
        public LoginPage OpenUrl()
        {
            this.webDriver.Url = DataConstants.WebDriver.Url;
            return this;
        }

        private void GetPasswordRequiredErrorMessage()
        {
            this.wait.Until(driver => this.passwordRequiredErrorMessage!.Displayed ? this.passwordRequiredErrorMessage : null);
        }

        private void WaitUntilElementsAreDisplayed()
        {
            this.wait.Until(driver => this.usernameInputField!.Displayed ? this.usernameInputField : null);
            this.wait.Until(driver => this.passwordInputField!.Displayed ? this.passwordInputField : null);
            this.wait.Until(driver => this.loginButton!.Displayed ? this.loginButton : null);
        }
    }
}
