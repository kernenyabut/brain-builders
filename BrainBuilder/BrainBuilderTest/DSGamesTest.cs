using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DesertSandsTests
{
    [TestFixture]
    class GamesTest
    {
        /// <summary>
        /// Used if an element can be found if login is successful
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        IWebDriver driver;

        /// <summary>
        /// Create starting points of tests with a logged in user on profile page - only called when deactivating subscriptions
        /// </summary>
        public void SetUpMethod()
        {
            driver = new ChromeDriver("../../../bin/Debug/netcoreapp2.2/");
            driver.Navigate().GoToUrl("https://localhost:44338/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnLogin")));
        }

        [TearDown]
        public void TearDownMethod()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Confirm if the matching game is avaiable
        /// </summary>
        [Test]
        public void TestGame_MatchingGameAvaiable()
        {
            //Part 1
            SetUpMethod();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Checks if btnGames is found
            wait.Until(ExpectedConditions.ElementExists(By.Id("btnGames")));

            //Part 2
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAcceptCookiePolicy")));
            IWebElement btnAcceptCookiePolicy = driver.FindElement(By.Id("btnAcceptCookiePolicy"));
            btnAcceptCookiePolicy.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnGames")));
            IWebElement btnGames = driver.FindElement(By.Id("btnGames")); 
            btnGames.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnPlayGame")));
            IWebElement btnPlayGame = driver.FindElement(By.Id("btnPlayGame"));
            btnPlayGame.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnStart")));

            IWebElement btnStart = driver.FindElement(By.Id("btnStart"));

            Assert.AreEqual("Start Game", btnStart.GetAttribute("innerHTML"));
        }
    }
}
