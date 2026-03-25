namespace SauceDemo.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SauceDemo.Constants;

    public class LoginPage
    {
        private readonly WebDriverWait wait;
        private readonly Driver webDriver;

        public LoginPage()
        {
            this.webDriver = Driver.Initialize("chrome");
            this.wait = new WebDriverWait((IWebDriver)this.webDriver, TimeSpan.FromSeconds(20));
        }

        public void Login()
        {
            this.webDriver.OpenUrl(DataConstants.WebDriver.Url);
        }
    }
}
