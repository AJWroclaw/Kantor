using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace LiderWalut.Tests
{

    public class MainPage
    {
        public readonly IWebDriver driver = new ChromeDriver();
        public readonly string url = @"http://www.liderwalut.pl/";

        public static By actionBuy = By.Id("action-buy");
        public static By actionSell = By.Id("action-sell");
        public static By actionChange = By.Id("action-change");
        public static By destinationAmount = By.Id("destination_amount");

        public void Teardown()
        {
            this.driver.Quit();
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void MaximizeWindow()
        {
            this.driver.Manage().Window.Maximize();
        }

        public void Wait()
        {
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public List<string> GetTitles()
        {
            var titlesList = new List<string>();
            var elements = this.driver.FindElements(By.CssSelector("div.title"));
            foreach (IWebElement e in elements)
            {
                titlesList.Add(e.Text);
            }
            return titlesList;
        }

        public string GetDestinationAmount()
        {
            var destAmount = this.driver.FindElement(destinationAmount).Text;
            return destAmount;
        }

        public void ClickButton(By action)
        {
            this.driver.FindElement(action).Click();
        }
    }
}
