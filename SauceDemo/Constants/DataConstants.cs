namespace SauceDemo.Constants
{
    public abstract class DataConstants
    {
        public abstract class WebDriver
        {
            public const string ChromeDriverBrowserName = "chrome";
            public const string FirefoxDriverBrowserName = "firefox";
            public const string SafariDriverBrowserName = "safari";
            public const string EdgeDriverBrowserName = "edge";
            public const string Url = "https://www.saucedemo.com/";

            public static readonly string[] UserAgents = { "windows|Mozilla/5.0 (compatible; MSIE 11.0; Windows NT 6.3; Win64; x64 Trident/7.0)", "explorer|Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.1; x64; en-US Trident/4.0)", "iphone|Mozilla/5.0 (iPhone; CPU iPhone OS 8_4_7; like Mac OS X) AppleWebKit/537.9 (KHTML, like Gecko)  Chrome/53.0.1226.146 Mobile Safari/603.6", "edge|Mozilla/5.0 (Windows; U; Windows NT 10.0;) AppleWebKit/601.27 (KHTML, like Gecko) Chrome/55.0.2947.247 Safari/600.1 Edge/10.72103", "mac|Mozilla/5.0 (Macintosh; U; Intel Mac OS X 9_1_2) AppleWebKit/600.16 (KHTML, like Gecko) Chrome/48.0.3501.370 Safari/602", "linux|Mozilla/5.0 (Linux x86_64; en-US) AppleWebKit/537.12 (KHTML, like Gecko) Chrome/53.0.2590.164 Safari/603", "windows|Mozilla/5.0 (compatible; MSIE 11.0; Windows; U; Windows NT 6.2; x64 Trident/7.0)", "windows|Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64 Trident/5.0)", "windows|Mozilla/5.0 (compatible; MSIE 8.0; Windows; Windows NT 6.2; Win64; x64; en-US Trident/4.0)", "mobile|Mozilla/5.0 (iPad; CPU iPad OS 11_9_1 like Mac OS X) AppleWebKit/603.18 (KHTML, like Gecko)  Chrome/48.0.3597.172 Mobile Safari/534.9" };
        }

        public abstract class LoginPageConstants
        {
            public const string UsernameInputFieldCssSelector = "#user-name";
            public const string PasswordInputFieldCssSelector = "#password";
            public const string LoginButtonCssSelector = "#login-button";
            public const string PasswordRequiredErrorLoginMessageCssSelector = ".error-message-container > h3:nth-child(1)";
            public static readonly string[] Usernames = { "standard_user", "locked_out_user", "problem_user", "performance_glitch_user", "error_user", "visual_user" };
        }

        public abstract class MainPageConstants
        {
            public const string HeaderContainerCssSelector = "#header_container";
            public const string PrimaryHeaderContainerCssSelector = ".primary_header";
            public const string MenuButtonContainerCssSelector = "#menu_button_container";
            public const string BurgerMenuButtonWrapperCssSelector = ".bm-burger-button";
            public const string BurgerMenuButtonCssSelector = "#react-burger-menu-btn";
            public const string MainPageHeadingLable = ".app_logo";
            public const string ShoppingCartIconCssSelector = ".shopping_cart_link";
            public const string ProductSortContainerCssSelector = ".product_sort_container";
            public const string InventoryListContainerCssSelector = ".inventory_list";
            public const string PageWrapperCssSelector = "#page_wrapper";
        }
    }
}
