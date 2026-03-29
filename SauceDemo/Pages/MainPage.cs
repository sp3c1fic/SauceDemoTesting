// <copyright file="MainPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SauceDemo.Pages
{
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Constants;
    using SauceDemo.Utilities;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// The Main Page Class which is responsible for automating the whole process of loggining into an account and encapsulating the logic for that.
    /// </summary>
    public class MainPage
    {
        private readonly WebDriverWait wait;
        private readonly Actions actions;
        private readonly IWebDriver webDriver;
        private readonly By burgerMenuLocator = By.CssSelector(DataConstants.MainPageConstants.BurgerMenuButtonWrapperCssSelector);
        private readonly By mainPageHeadingLableLocator = By.CssSelector(DataConstants.MainPageConstants.MainPageHeadingLable);
        private readonly By shoppingCartIconLocator = By.CssSelector(DataConstants.MainPageConstants.ShoppingCartIconCssSelector);
        private readonly By productSortContainerLocator = By.CssSelector(DataConstants.MainPageConstants.ProductSortContainerCssSelector);
        private readonly By inventoryListLocator = By.CssSelector(DataConstants.MainPageConstants.InventoryListContainerCssSelector);
        private readonly By inventoryItemLocator = By.CssSelector(DataConstants.MainPageConstants.InventoryItemCssSelector);
        private readonly By backToProductsLinkLocator = By.CssSelector(DataConstants.MainPageConstants.BackToProductsLinkCssSelector);
        private readonly By addToCartButtonLocator = By.CssSelector(DataConstants.MainPageConstants.AddToCartButtonCssSelector);
        private readonly By shoppingCartBadgeLocator = By.CssSelector(DataConstants.MainPageConstants.ShoppingCartBadgeCssSelector);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="webDriver">The WebDriver instances passed down to the main page constructor.</param>
        public MainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(35))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            this.actions = new Actions(this.webDriver);
        }

        /// <summary>
        /// Method responsible for testing the add product to shopping cart functionality and its behaviour.
        /// </summary>
        /// <returns>A boolean array indicating whether all products were added successfuly.</returns>
        public bool[] AddItemsToShoppingCart()
        {
            if (!this.IsInventoryListPresent())
            {
                return Array.Empty<bool>();
            }

            var itemIds = this.GetInventoryItemsIds();
            var isAllAdded = new bool[itemIds.Count];

            for (int i = 0; i < itemIds.Count; i++) // Iterate over the ids
            {
                isAllAdded[i] = this.AddItemToCart(itemIds[i] !);
            }

            return isAllAdded;
        }

        /// <summary>
        /// Method which looks for a burger menu element in order to ensure a successful login.
        /// </summary>
        /// <returns>Boolean indicating whether the burger menu was present on the page.</returns>
        public bool IsBurgerMenuButtonPresent() => this.IsElementPresent(this.burgerMenuLocator);

        /// <summary>
        /// Method that attempts to find the heading lable element in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>The application logo element's text indicating that it's present and making it easier for testing.</returns>
        public bool IsHeadingLablePresent() => this.IsElementPresent(this.mainPageHeadingLableLocator);

        /// <summary>
        /// Method that attempts to find the shopping cart icon element in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>Boolean value indicating that the shopping cart icon element is present indicating if a login failed or not making it easier for testing.</returns>
        public bool IsShoppingCartIconPresent() => this.IsElementPresent(this.shoppingCartIconLocator);

        /// <summary>
        /// Method that attempts to find the product sort container in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>Boolean value indicating that the product sort container is and making it easier for testing.</returns>
        public bool IsProductSortContainerPresent() => this.IsElementPresent(this.productSortContainerLocator);

        /// <summary>
        /// Method that attempts to find the inventory list element in order to determine whether its present or not indicating if login failed or not.
        /// </summary>
        /// <returns>Boolean value indicating that the inventory list is present and making it easier for testing.</returns>
        public bool IsInventoryListPresent()
        {
            var inventoryList = this.webDriver!.FindElement(this.inventoryListLocator);
            return this.wait.Until(driver => inventoryList.Displayed);
        }

        private bool AddItemToCart(string targetId)
        {
            var currentItems = this.webDriver.FindElements(this.inventoryItemLocator); // Relocate the items again to avoid StaleReferenceException

            var targetItem = currentItems
                            .FirstOrDefault(item =>
                                item.FindElement(By.TagName("a")).GetAttribute("id") == targetId); // Get the target element.

            if (targetItem == null)
            {
                return false;
            }

            targetItem.FindElement(By.TagName("a")).Click(); // Get the target element's <a> link

            // Rest of the functionality below is responsible for adding each product to the shopping cart. And repeating the process all over again.
            var addToCartButton = this.webDriver.FindElement(this.addToCartButtonLocator);
            this.wait.Until(ExpectedConditions.ElementToBeClickable(this.addToCartButtonLocator));

            WebDriverUtilities.InteractWithButton(this.actions, addToCartButton);
            var shoppingCartBadge = this.webDriver.FindElement(this.shoppingCartBadgeLocator);
            this.wait.Until(d => shoppingCartBadge.Displayed);

            var backToProductsButton = this.webDriver.FindElement(this.backToProductsLinkLocator);
            WebDriverUtilities.InteractWithButton(this.actions, backToProductsButton);

            // Wait for the list to be back before the next iteration
            this.wait.Until(d => this.IsInventoryListPresent());

            return true;
        }

        private List<string?> GetInventoryItemsIds()
        {
            var allItems = this.webDriver.FindElements(this.inventoryItemLocator); // Locate each item element
            return allItems
                .Select(item => item.FindElement(By.TagName("a")).GetAttribute("id")) // Get each item element's id.
                .ToList();
        }

        private bool IsElementPresent(By locator)
        {
            try
            {
                var element = this.webDriver!.FindElement(locator);
                return this.wait.Until(d => element.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
