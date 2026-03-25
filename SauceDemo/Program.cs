using SauceDemo;
using SauceDemo.Pages;

try
{
    var loginPage = new LoginPage();

    loginPage
        .OpenUrl()
        .LoginWithoutPassword();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Driver.QuitDriver();
}