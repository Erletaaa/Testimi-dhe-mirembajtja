using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gjirafa50SeleniumWebProject.Tests
{
    public class CartFunctionalityTests
    {
        [Test]
        public void AddToCartSuccessTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/maus-logitech-g-pro-x-superlight-i-zi");

            var product_container = driver.FindElement(By.XPath("//*[@id=\"product-details-form\"]/div[2]"));
            var product_id = product_container.GetAttribute("data-productid");

            var add_to_cart_button = driver.FindElement(By.XPath($"//*[@id=\"add-to-cart-button-{product_id}\"]"));
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", add_to_cart_button);
            //add_to_cart_button.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"topcartlink\"]/span[1]")));

            var delay = new TimeSpan(0, 0, 0, 0, 1000);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);

            var cart_element = driver.FindElement(By.XPath("/html/body/header/div[1]/nav/aside[2]/article"));
            Assert.That(cart_element.Displayed, Is.True);
            var cart_element_id = cart_element.GetAttribute("id");

            Assert.That(cart_element_id, Is.EqualTo(product_id));

            driver.Quit();
        }

        [Test]
        public void RemoveFromCartTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/maus-logitech-g-pro-x-superlight-i-zi");

            var product_container = driver.FindElement(By.XPath("//*[@id=\"product-details-form\"]/div[2]"));
            var product_id = product_container.GetAttribute("data-productid");

            var add_to_cart_button = driver.FindElement(By.XPath($"//*[@id=\"add-to-cart-button-{product_id}\"]"));
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", add_to_cart_button);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"topcartlink\"]/span[1]")));

            var delay = new TimeSpan(0, 0, 0, 0, 1000);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);

            var cart_element = driver.FindElement(By.XPath("/html/body/header/div[1]/nav/aside[2]/article"));
            Assert.That(cart_element.Displayed, Is.True);

            var delete_from_cart_button = driver.FindElement(By.XPath($"//*[@id=\"{product_id}\"]/div/div[1]/button"));
            delete_from_cart_button.Click();

            timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);

            var cart_items_count = driver.FindElement(By.XPath("//*[@id=\"topcartlink\"]/span[2]"));
            Assert.That(int.Parse(cart_items_count.Text), Is.EqualTo(0));

            driver.Quit();
        }
    }
}
