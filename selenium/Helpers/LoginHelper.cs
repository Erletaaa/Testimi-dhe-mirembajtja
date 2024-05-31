using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gjirafa50SeleniumWebProject.Helpers
{
    public static class LoginHelper
    {
        public static void LoginUser(IWebDriver driver, string username, string password)
        {
            var login_link = driver.FindElement(By.XPath("/html/body/header/div[1]/nav/ul/li[1]/a"));
            login_link.Click();

            var email_field = driver.FindElement(By.Id("email"));
            email_field.SendKeys(username);

            var password_field = driver.FindElement(By.Id("password"));
            password_field.SendKeys(password);

            var login_button = driver.FindElement(By.XPath("//*[@id=\"formexample\"]/fieldset/div[4]/button"));
            login_button.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"header-menu\"]/div[1]/div[2]/a/img")));
        }
    }
}
