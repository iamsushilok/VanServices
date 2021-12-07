using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace VanServices
{
    [Binding]
    public class Hooks
    {
        public IWebDriver driver;
        [BeforeScenario]
        public void InitilizeBrowser() {
            driver = new ChromeDriver();
        }

        [AfterScenario]
        public void CleanUp() {
            driver.Quit();
        }
    }
}
