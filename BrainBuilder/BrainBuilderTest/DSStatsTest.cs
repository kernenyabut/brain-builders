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
    class StatsTest
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

            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));
            IWebElement txtUserName = driver.FindElement(By.Id("txtUserName"));
            txtUserName.SendKeys("Admin");
            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("Admin1!");
            IWebElement btnConfirmLogIn = driver.FindElement(By.Id("btnConfirmLogIn"));
            btnConfirmLogIn.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnProfile")));
            IWebElement btnProfile = driver.FindElement(By.Id("btnProfile"));
            btnProfile.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lblName")));

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
        /// Confirm stat page is present if user has a record of completing a game
        /// </summary>
        [Test]
        public void TestStats_NoStatsForNewUser()
        {
            //Part 1
            driver = new ChromeDriver("../../../bin/Debug/netcoreapp2.2/");
            driver.Navigate().GoToUrl("https://localhost:44338/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnRegister")));

            IWebElement btnRegister = driver.FindElement(By.Id("btnRegister"));
            btnRegister.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement btnSubmitUser;
            IWebElement txtPassword;
            IWebElement txtConfirmPassword;

            string userName = "";
            //allows for repeat testing
            for (int i = 0; i < 100; i++)
            {
                IWebElement txtUserName = driver.FindElement(By.Id("txtUserName"));
                txtUserName.SendKeys(Keys.Control + "a");
                txtUserName.SendKeys(Keys.Delete);
                txtUserName.SendKeys("Test" + i.ToString());

                IWebElement txtEmail = driver.FindElement(By.Id("txtEmail"));
                txtEmail.SendKeys(Keys.Control + "a");
                txtEmail.SendKeys(Keys.Delete);
                txtEmail.SendKeys("test" + i.ToString() + "@gmail.com");

                txtPassword = driver.FindElement(By.Id("txtPassword"));
                txtPassword.SendKeys("Test1!");
                txtConfirmPassword = driver.FindElement(By.Id("txtConfirmPassword"));
                txtConfirmPassword.SendKeys("Test1!");

                btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
                btnSubmitUser.Click();

                //If element is found (if register fails because of duplication)
                if (IsElementPresent(By.Id("txtUserName")))
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

                    IWebElement error = driver.FindElement(By.Id("txtUserName-error"));

                    //If name is duplicated - add another number
                    if (error.Text == "")
                    {
                        userName = "Test" + i.ToString();
                        break;
                    }
                }
                //If element is not found = register passes
                else
                {
                    break;
                }
            }

            //Checks if btnStats is found
            wait.Until(ExpectedConditions.ElementExists(By.Id("btnStats")));

            //Part 2
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAcceptCookiePolicy")));
            IWebElement btnAcceptCookiePolicy = driver.FindElement(By.Id("btnAcceptCookiePolicy"));
            btnAcceptCookiePolicy.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnStats")));
            IWebElement btnStats = driver.FindElement(By.Id("btnStats"));
            btnStats.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtNoStats")));

            IWebElement noStats = driver.FindElement(By.Id("txtNoStats"));

            Assert.AreEqual("You have not played any games to see any stats", noStats.GetAttribute("innerHTML"));
        }

        /// <summary>
        /// Confirm stat page is present if user has a record of completing a game
        /// </summary>
        [Test]
        public void TestStats_UserHasStats()
        {
            //Part 1
            SetUpMethod();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Checks if btnStats is found
            wait.Until(ExpectedConditions.ElementExists(By.Id("btnStats")));

            //Part 2
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAcceptCookiePolicy")));
            IWebElement btnAcceptCookiePolicy = driver.FindElement(By.Id("btnAcceptCookiePolicy"));
            btnAcceptCookiePolicy.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnStats")));
            IWebElement btnStats = driver.FindElement(By.Id("btnStats"));
            btnStats.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtOverallStats")));

            IWebElement overallStats = driver.FindElement(By.Id("txtOverallStats"));

            Assert.AreEqual("Overall Stats", overallStats.GetAttribute("innerHTML"));
        }
    }
}
