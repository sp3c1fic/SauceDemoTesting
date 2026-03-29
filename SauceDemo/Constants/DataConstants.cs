// <copyright file="DataConstants.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SauceDemo.Constants
{
    /// <summary>
    /// Contains all constant values used throughout the SauceDemo test suite.
    /// </summary>
    public abstract class DataConstants
    {
        /// <summary>
        /// Contains WebDriver configuration constants including browser names, URLs, and user agents.
        /// </summary>
        public abstract class WebDriver
        {
            /// <summary>The browser name identifier for ChromeDriver.</summary>
            public const string ChromeDriverBrowserName = "chrome";

            /// <summary>The browser name identifier for FirefoxDriver.</summary>
            public const string FirefoxDriverBrowserName = "firefox";

            /// <summary>The browser name identifier for SafariDriver.</summary>
            public const string SafariDriverBrowserName = "safari";

            /// <summary>The browser name identifier for EdgeDriver.</summary>
            public const string EdgeDriverBrowserName = "edge";

            /// <summary>The base URL of the SauceDemo application.</summary>
            public const string Url = "https://www.saucedemo.com/";

            /// <summary>
            /// A pool of user agent strings used for randomization across test runs.
            /// Each entry is prefixed with a platform identifier (e.g. "windows|", "mobile|")
            /// followed by the full user agent string.
            /// </summary>
            public static readonly string[] UserAgents = { "windows|Mozilla/5.0 (compatible; MSIE 11.0; Windows NT 6.3; Win64; x64 Trident/7.0)", "explorer|Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.1; x64; en-US Trident/4.0)", "iphone|Mozilla/5.0 (iPhone; CPU iPhone OS 8_4_7; like Mac OS X) AppleWebKit/537.9 (KHTML, like Gecko)  Chrome/53.0.1226.146 Mobile Safari/603.6", "edge|Mozilla/5.0 (Windows; U; Windows NT 10.0;) AppleWebKit/601.27 (KHTML, like Gecko) Chrome/55.0.2947.247 Safari/600.1 Edge/10.72103", "mac|Mozilla/5.0 (Macintosh; U; Intel Mac OS X 9_1_2) AppleWebKit/600.16 (KHTML, like Gecko) Chrome/48.0.3501.370 Safari/602", "linux|Mozilla/5.0 (Linux x86_64; en-US) AppleWebKit/537.12 (KHTML, like Gecko) Chrome/53.0.2590.164 Safari/603", "windows|Mozilla/5.0 (compatible; MSIE 11.0; Windows; U; Windows NT 6.2; x64 Trident/7.0)", "windows|Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64 Trident/5.0)", "windows|Mozilla/5.0 (compatible; MSIE 8.0; Windows; Windows NT 6.2; Win64; x64; en-US Trident/4.0)", "mobile|Mozilla/5.0 (iPad; CPU iPad OS 11_9_1 like Mac OS X) AppleWebKit/603.18 (KHTML, like Gecko)  Chrome/48.0.3597.172 Mobile Safari/534.9" };
        }

        /// <summary>
        /// Contains CSS selectors and test data constants for the Login page.
        /// </summary>
        public abstract class LoginPageConstants
        {
            /// <summary>CSS selector for the username input field.</summary>
            public const string UsernameInputFieldCssSelector = "#user-name";

            /// <summary>CSS selector for the password input field.</summary>
            public const string PasswordInputFieldCssSelector = "#password";

            /// <summary>CSS selector for the login submit button.</summary>
            public const string LoginButtonCssSelector = "#login-button";

            /// <summary>CSS selector for the error message container displayed on failed login attempts.</summary>
            public const string PasswordRequiredErrorLoginMessageCssSelector = ".error-message-container > h3:nth-child(1)";

            /// <summary>
            /// All available test user accounts on SauceDemo.
            /// Includes standard, locked out, problem, performance glitch, error, and visual users,
            /// each simulating different application behaviors and defects.
            /// </summary>
            public static readonly string[] Usernames = { "standard_user", "locked_out_user", "problem_user", "performance_glitch_user", "error_user", "visual_user" };
        }

        /// <summary>
        /// Contains CSS selectors for elements on the main inventory page and product detail pages.
        /// </summary>
        public abstract class MainPageConstants
        {
            /// <summary>CSS selector for the top-level header container.</summary>
            public const string HeaderContainerCssSelector = "#header_container";

            /// <summary>CSS selector for the primary header section within the header container.</summary>
            public const string PrimaryHeaderContainerCssSelector = ".primary_header";

            /// <summary>CSS selector for the menu button container.</summary>
            public const string MenuButtonContainerCssSelector = "#menu_button_container";

            /// <summary>CSS selector for the burger menu button wrapper element.</summary>
            public const string BurgerMenuButtonWrapperCssSelector = ".bm-burger-button";

            /// <summary>CSS selector for the burger menu toggle button.</summary>
            public const string BurgerMenuButtonCssSelector = "#react-burger-menu-btn";

            /// <summary>CSS selector for the application logo/heading label.</summary>
            public const string MainPageHeadingLable = ".app_logo";

            /// <summary>CSS selector for the shopping cart icon link in the header.</summary>
            public const string ShoppingCartIconCssSelector = ".shopping_cart_link";

            /// <summary>CSS selector for the product sort dropdown container.</summary>
            public const string ProductSortContainerCssSelector = ".product_sort_container";

            /// <summary>CSS selector for the inventory list container holding all products.</summary>
            public const string InventoryListContainerCssSelector = ".inventory_list";

            /// <summary>CSS selector for the full page wrapper element.</summary>
            public const string PageWrapperCssSelector = "#page_wrapper";

            /// <summary>CSS selector for individual inventory item cards within the inventory list.</summary>
            public const string InventoryItemCssSelector = "div.inventory_item";

            /// <summary>CSS selector for the inventory item name label.</summary>
            public const string InventoryItemNameCssSelector = ".inventory_item_name";

            /// <summary>CSS selector for the back to products navigation link on the product detail page.</summary>
            public const string BackToProductsLinkCssSelector = "#back-to-products";

            /// <summary>CSS selector for the add to cart button on the product detail page.</summary>
            public const string AddToCartButtonCssSelector = "#add-to-cart";

            /// <summary>CSS selector for the shopping cart badge displaying the current item count.</summary>
            public const string ShoppingCartBadgeCssSelector = ".shopping_cart_badge";

            /// <summary>CSS selector for the shopping cart container in the header.</summary>
            public const string ShoppingCartContainerSelector = "#shopping_cart_container";

            /// <summary>CSS selector for the shopping cart link element.</summary>
            public const string ShoppingCartLinkSelector = ".shopping_cart_link";

            /// <summary>CSS selector for the product description element on the product detail page.</summary>
            public const string InventoryItemDescriptionCssSelector = ".inventory_details_desc";
        }
    }
}