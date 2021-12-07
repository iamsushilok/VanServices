using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace VanServices
{
    [Binding]
    public class UsedVanPriceSteps:Hooks
    {
        [Given(@"I can see InSync Homepage")]
        public void GivenICanSeeInSyncHomepage()
        {
            //ScenarioContext.Current.Pending();
            driver.Navigate().GoToUrl("https://insyncgroup.co.uk/");
        }
        
        [When(@"I am on Used van page I want to see cheapest van")]
        public void WhenIAmOnUsedVanPageIWantToSeeCheapestVan()
        {
            //Click on Services Tab
            driver.FindElement(By.XPath("/html/body/header/div/nav[2]/ul/li[2]/a")).Click();

            //Click on Van Finance
            driver.FindElement(By.XPath("/html/body/header/div/nav[2]/ul/li[2]/ul/li/div/div/div/div[3]/div/p/a[1]")).Click();

            //Click on ViewDeals to see Used vans
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div/div/a")).Click();

            IList<IWebElement> pricesOfVehicles = driver.FindElements(By.ClassName("van-feature-price2"));

            int[] valArray = new int[3];
            int i = 0;
            foreach (IWebElement e in pricesOfVehicles) {
                string  priceVal = e.GetAttribute("value");

                 valArray[i] = Convert.ToInt32(priceVal);
                i++;
            }

            int lowestPrice = valArray[0];
            for (int j=0; j < valArray.Length; j++) {
                if (lowestPrice > valArray[j]) {
                    lowestPrice = valArray[j];
                }
            
            }

            driver.FindElement(By.XPath("div[contains@(class='price2')]")).Click();

            int detailPagePrice = Convert.ToInt32(driver.FindElement(By.
                XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div[2]/div/div[2]/span/strong")).GetAttribute("value"));

            Assert.AreEqual(lowestPrice, detailPagePrice);
        }

        [Then(@"I am about to book cheapest van")]
        public void ThenIAmAboutToBookCheapestVan()
        {
            
            
        }
    }
}
