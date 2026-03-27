// <copyright file="MainPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Constants;
    using SauceDemo.Interfaces;

    /// <summary>
    /// The Main Page Class which is responsible for automating the whole process of loggining into an account and encapsulating the logic for that.
    /// </summary>
    public class MainPage : IPage
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver webDriver;
        private readonly By headerContainerLocator = By.CssSelector(DataConstants.MainPageConstants.HeaderContainerCssSelector);
        private readonly By primaryHeaderContainerLocator = By.CssSelector(DataConstants.MainPageConstants.PrimaryHeaderContainerCssSelector);
        private readonly By menuButtonContainer = By.CssSelector(DataConstants.MainPageConstants.MenuButtonContainerCssSelector);
        private readonly By burgerMenuLocator = By.CssSelector(DataConstants.MainPageConstants.BurgerMenuButtonWrapperCssSelector);
        private readonly By mainPageHeadingLableLocator= By.CssSelector(DataConstants.MainPageConstants.MainPageHeadingLable);
        private readonly By shoppingCartIconLocator = By.CssSelector(DataConstants.MainPageConstants.ShoppingCartIconCssSelector);
        private readonly By productSortContainerLocator = By.CssSelector(DataConstants.MainPageConstants.ProductSortContainerCssSelector);
        private readonly By inventoryListLocator = By.CssSelector(DataConstants.MainPageConstants.InventoryListContainerCssSelector);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="webDriver">The WebDriver instances passed down to the main page constructor.</param>
        public MainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(35));
        }

        /// <summary>
        /// Method which looks for a burger menu element in order to ensure a successful login.
        /// </summary>
        /// <returns>Boolean indicating whether the burger menu was present on the page.</returns>
        public bool IsBurgerMenuButtonPresent()
        {
            var headerContainer = this.webDriver!.FindElement(this.headerContainerLocator);
            this.wait.Until(d => headerContainer.Displayed);

            var primaryHeader = headerContainer.FindElement(this.primaryHeaderContainerLocator);
            var burgerMenuButtonContainer = primaryHeader.FindElement(this.menuButtonContainer);
            var innerMenuButtonDivContainer = burgerMenuButtonContainer.FindElement(By.CssSelector("div"));
            var burgerMenu = innerMenuButtonDivContainer.FindElement(this.burgerMenuLocator);
            return this.wait.Until(d => burgerMenu.Displayed);
        }

        /// <summary>
        /// Method that attempts to find the heading lable element in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>The application logo element's text indicating that it's present and making it easier for testing.</returns>
        public string IsHeadingLablePresent()
        {
            var appLogo = this.webDriver!.FindElement(this.mainPageHeadingLableLocator);
            this.wait.Until(d => appLogo.Displayed);
            return appLogo.Text;
        }

        /// <summary>
        /// Method that attempts to find the shopping cart icon element in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>Boolean value indicating that the shopping cart icon element is present indicating if a login failed or not making it easier for testing.</returns>
        public bool IsShoppingCartIconPresent()
        {
            var shoppingCartIcon = this.webDriver!.FindElement(this.shoppingCartIconLocator);
            return this.wait.Until(d => shoppingCartIcon.Displayed);
        }

        /// <summary>
        /// Method that attempts to find the product sort container in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>Boolean value indicating that the product sort container is and making it easier for testing.</returns>
        public bool IsProductSortContainerPresent()
        {
            var productSortContainer = this.webDriver!.FindElement(this.productSortContainerLocator);
            return this.wait.Until(d => productSortContainer.Displayed);
        }

        /// <summary>
        /// Method that attempts to find the inventory list element in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>Boolean value indicating that the inventory list is present and making it easier for testing.</returns>
        public bool IsInventoryListPresent()
        {
            var inventoryList = this.webDriver!.FindElement(this.inventoryListLocator);
            return this.wait.Until(driver => inventoryList.Displayed);
        }
    }
}
