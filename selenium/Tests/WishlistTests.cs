using Gjirafa50SeleniumWebProject.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gjirafa50SeleniumWebProject.Tests
{
    public class WishlistTests
    {
        [Test]
        public void AddToWishlistTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/");

            LoginHelper.LoginUser(driver, "pedidaf452@fresec.com", "Testing1234*");

            driver.Navigate().GoToUrl("https://gjirafa50.com/cante-shpine-lenovo-b210-per-laptop-156");

            var product_container = driver.FindElement(By.XPath("//*[@id=\"product-details-form\"]/div[2]"));
            var product_id = product_container.GetAttribute("data-productid");

            var favorite_button = driver.FindElement(By.XPath($"//*[@id=\"add-to-wishlist-button-{product_id}\"]"));
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", favorite_button);
            //favorite_button.Click();

            var wishlist_link = driver.FindElement(By.XPath("//*[@id=\"header-menu\"]/nav/ul/li[2]/a"));
            wishlist_link.Click();

            Assert.That(driver.Url, Is.EqualTo("https://gjirafa50.com/wishlist"));

            var wishlist_contents = driver.FindElements(By.Id("related-products")).Count == 1;

            driver.Quit();
        }

        [Test]
        public void RemoveFromWishlistTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/");

            LoginHelper.LoginUser(driver, "pedidaf452@fresec.com", "Testing1234*");

            driver.Navigate().GoToUrl("https://gjirafa50.com/cante-shpine-lenovo-b210-per-laptop-156");

            var product_container = driver.FindElement(By.XPath("//*[@id=\"product-details-form\"]/div[2]"));
            var product_id = product_container.GetAttribute("data-productid");

            var favorite_button = driver.FindElement(By.XPath($"//*[@id=\"add-to-wishlist-button-{product_id}\"]"));
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", favorite_button);
            //favorite_button.Click();

            var wishlist_link = driver.FindElement(By.XPath("//*[@id=\"header-menu\"]/nav/ul/li[2]/a"));
            wishlist_link.Click();

            Assert.That(driver.Url, Is.EqualTo("https://gjirafa50.com/wishlist"));

            var delete_from_wishlist_button = driver.FindElement(By.XPath("//*[@id=\"related-products\"]/div[3]/div[2]/button[2]"));
            javascriptExecutor.ExecuteScript("arguments[0].click();", delete_from_wishlist_button);

            var wishlist_empty_message = driver.FindElement(By.XPath("/html/body/main/div[2]/div/section/section/section[2]/p"));

            Assert.That(wishlist_empty_message.Displayed, Is.True);

            driver.Quit();
            
        }
    }
}
