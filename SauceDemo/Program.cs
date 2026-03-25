using OpenQA.Selenium;
using SauceDemo;
using SauceDemo.Constants;
using SauceDemo.Pages;

try
{
    var loginPage = new LoginPage();

    loginPage.Login();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Driver.QuitDriver();
}