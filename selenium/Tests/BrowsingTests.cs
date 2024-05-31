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
    public class BrowsingTests
    {
        [Test]
        public void KeywordSearch()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/");

            var keyword_to_search = "laptop";
            var search_bar = driver.FindElement(By.Id("small-searchterms"));
            search_bar.SendKeys(keyword_to_search);

            var search_button = driver.FindElement(By.XPath("//*[@id=\"small-search-box-form\"]/button"));
            search_button.Click();

            var search_results_count = driver.FindElement(By.Id("search-total-hits-count"));
            Assert.That(search_results_count.Displayed, Is.True);
            Assert.That(int.Parse(search_results_count.Text), Is.Not.EqualTo(0));

            var search_result_keyword = driver.FindElement(By.XPath("/html/body/main/div[2]/div/section/div/div/div[2]/div/div[1]/span/span[2]"));
            Assert.That(search_result_keyword.Displayed, Is.True);
            Assert.That(TextHelper.CleanUpQuotes(search_result_keyword.Text), Is.EqualTo(keyword_to_search));

            driver.Quit();
        }

        [Test]
        public void BrowseCategory()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://gjirafa50.com/");

            var category_link = driver.FindElement(By.XPath("/html/body/nav/ul[2]/li[1]/a"));
            var category_name = category_link.Text;
            category_link.Click();

            var expected_page_title = $"{category_name} ne shitje - Blej Online | Gjirafa50";
            Assert.That(driver.Title, Is.EqualTo(expected_page_title));

            var breadcrumb = driver.FindElement(By.XPath("/html/body/main/div[2]/div/nav/ul/li[2]/h1"));
            Assert.That(breadcrumb.Displayed, Is.True);

            driver.Quit();
        }
    }
}
