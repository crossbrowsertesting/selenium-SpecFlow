using System;
using System.IO;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CBT_Example_2
{
    [Binding]
    public class CBTFeatureSteps
    {
        protected RemoteWebDriver driver;

        // Your username and authkey here
        public string username = "your username";
        public string authkey = "your authkey";

        DesiredCapabilities caps = new DesiredCapabilities();



        [Given(@"I navigate to the page ""(.*)""")]
        public void GivenINavigateToThePage(string p0)
        {
            caps.SetCapability("name", "SpecFlow-CBT");
            caps.SetCapability("record_video", "true");
            caps.SetCapability("build", "1.35");
            caps.SetCapability("browserName", "Firefox");
            caps.SetCapability("version", "53x64");
            caps.SetCapability("platform", "Windows 10");
            caps.SetCapability("screenResolution", "1366x768");
            caps.SetCapability("record_video", "true");
            caps.SetCapability("record_network", "false");

            caps.SetCapability("username", username);
            caps.SetCapability("password", authkey);

            // Start the remote webdriver
            driver = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), caps, TimeSpan.FromSeconds(180));

            // Navigate to site
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(p0);
        }

        [Given(@"I see the page is loaded")]
        public void GivenISeeThePageIsLoaded()
        {
            Assert.AreEqual("Google", driver.Title);
        }

        [When(@"I enter Search Keyword in the Search Text box")]
        public void WhenIEnterSearchKeywordInTheSearchTextBox()
        {
            string searchText = "Specflow";
            driver.FindElement(By.Name("q")).SendKeys(searchText);
        }

        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()
        {
            driver.FindElement(By.Name("btnG")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [Then(@"Search items shows the items related to SpecFlow")]
        public void ThenSearchItemsShowsTheItemsRelatedToSpecFlow()
        {
            Assert.AreEqual("SpecFlow - Binding Business Requirements to .NET Code", driver.FindElement(By.XPath("//h3/a")).Text);
            driver.Quit();
        }
    }
}
