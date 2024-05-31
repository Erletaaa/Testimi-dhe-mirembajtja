using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gjirafa50SeleniumWebProject.Tests
{
    public class AuthenticationTests
    {
        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/");

            var login_link = driver.FindElement(By.XPath("//*[@id=\"header-menu\"]/nav/ul/li[1]/a"));
            login_link.Click();

            var email_field = driver.FindElement(By.Id("email"));
            email_field.SendKeys("pedidaf452@fresec.com");

            var password_field = driver.FindElement(By.Id("password"));
            password_field.SendKeys("Testing1234*");

            var login_button = driver.FindElement(By.XPath("//*[@id=\"formexample\"]/fieldset/div[4]/button"));
            login_button.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv=>drv.FindElement(By.XPath("//*[@id=\"header-menu\"]/div[1]/div[2]/a/img")));

            Assert.That(driver.Title, Is.EqualTo("Dyqani online me i madh per teknologji ne Kosove | Gjirafa50"));

            var username_field = driver.FindElement(By.XPath("//*[@id=\"account__dropdown\"]/span"));
            Assert.That(username_field.Displayed, Is.True);

            driver.Quit();
        }

        [Test]
        public void LogOutTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/");

            var login_link = driver.FindElement(By.XPath("//*[@id=\"header-menu\"]/nav/ul/li[1]/a"));
            login_link.Click();

            var email_field = driver.FindElement(By.Id("email"));
            email_field.SendKeys("pedidaf452@fresec.com");

            var password_field = driver.FindElement(By.Id("password"));
            password_field.SendKeys("Testing1234*");

            var login_button = driver.FindElement(By.XPath("//*[@id=\"formexample\"]/fieldset/div[4]/button"));
            login_button.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"header-menu\"]/div[1]/div[2]/a/img")));

            var username_field = driver.FindElement(By.XPath("//*[@id=\"account__dropdown\"]/span"));
            Assert.That(username_field.Displayed, Is.True);

            var profile_dropdown = driver.FindElement(By.XPath("//*[@id=\"account__dropdown\"]"));
            profile_dropdown.Click();

            var logout_button = driver.FindElement(By.XPath("//*[@id=\"account__card\"]/nav/ul/li[5]/a"));
            logout_button.Click();

            wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"header-menu\"]/div[1]/div[2]/a/img")));

            var login_button_after_logout = driver.FindElement(By.XPath("//*[@id=\"header-menu\"]/nav/ul/li[1]/a"));
            Assert.That(login_button_after_logout.Displayed, Is.True);

            driver.Quit();
        }
    }
}
