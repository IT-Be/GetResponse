using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace GetResponseTests
{
    public static class SeleniumMethods
    {
        public static IWebDriver ConfigureDriver(IWebDriver driver, string driverType, string driverPath)
        {
            switch (driverType)
            {
                case "ie":
                    {
                        driver = new InternetExplorerDriver(driverPath);
                        driver.Manage().Window.Maximize();
                        return driver;
                    }

                default:
                    throw new Exception("Brak odpowiedniej wtyczki.");
            }
        }

        public static IWebDriver GoToWebsite(IWebDriver driver, string websiteURL)
        {
            driver.Navigate().GoToUrl(websiteURL);
            return driver;
        }
    }
}
