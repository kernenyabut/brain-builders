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
    class SubscriptionTest
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
        /// Confirm successful subscription purchase
        /// </summary>
        [Test]
        public void TestSubscription_SuccessfulSubscriptionPurchase()
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

            //Checks if btnManageUser is found - can only exist if user successfully logs in
            wait.Until(ExpectedConditions.ElementExists(By.Id("btnProfile")));

            //Part 2
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAcceptCookiePolicy")));
            IWebElement btnAcceptCookiePolicy = driver.FindElement(By.Id("btnAcceptCookiePolicy"));
            btnAcceptCookiePolicy.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnManageUser")));
            IWebElement btnManageUser = driver.FindElement(By.Id("btnManageUser"));
            btnManageUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lstCreditCard")));
            //The select list just WASN'T responding to anything that was done. This is a compromise.
            //During debugging, the previous code would work and the nav item would be clicked,
            //but it refused to be clicked during any actual run of the unit tests.
            driver.Navigate().GoToUrl("https://localhost:44338/Identity/Account/Manage/CreditCard");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement txtCardNumber = driver.FindElement(By.Id("txtCardNumber"));
            txtCardNumber.SendKeys("341256781234567");

            IWebElement txtSecurityCode = driver.FindElement(By.Id("txtSecurityCode"));
            txtSecurityCode.SendKeys("123");

            IWebElement YearDropDown = driver.FindElement(By.Id("optExpiryYear"));
            var selectedYear = new SelectElement(YearDropDown);
            selectedYear.SelectByIndex(4);

            IWebElement txtFirstName = driver.FindElement(By.Id("txtFirstName"));
            txtFirstName.SendKeys("John");

            IWebElement txtLastName = driver.FindElement(By.Id("txtLastName"));
            txtLastName.SendKeys("Doe");

            IWebElement txtAddress = driver.FindElement(By.Id("txtAddress"));
            txtAddress.SendKeys("10 Somewhere Ave.");

            IWebElement txtCity = driver.FindElement(By.Id("txtCity"));
            txtCity.SendKeys("Anywhere");

            IWebElement txtPhoneNumber = driver.FindElement(By.Id("txtPhoneNumber"));
            txtPhoneNumber.SendKeys("519-519-5195");

            IWebElement txtPostalCode = driver.FindElement(By.Id("txtPostalCode"));
            txtPostalCode.SendKeys("N3C 0B8");

            IWebElement btnSubmitCard = driver.FindElement(By.Id("btnSubmitCard"));
            btnSubmitCard.Click();

            wait.Until(ExpectedConditions.ElementExists(By.Id("optCardCode")));

            IWebElement debugMessage = driver.FindElement(By.Id("debugMessage"));

            //Part 3
            IWebElement btnSubscriptions = driver.FindElement(By.Id("btnSubscriptions"));
            btnSubscriptions.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSubscribe-PurchaseMembershipMonthly")));

            IWebElement btnSubscribe = driver.FindElement(By.Id("btnSubscribe-PurchaseMembershipMonthly"));
            btnSubscribe.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtSecurityCode")));

            IWebElement txtSecurityCodePurchase = driver.FindElement(By.Id("txtSecurityCode"));
            txtSecurityCodePurchase.SendKeys("123");

            IWebElement btnPurchase = driver.FindElement(By.Id("btnPurchase"));
            btnPurchase.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSubscribe-DeactivateMonthly")));

            IWebElement deactivate = driver.FindElement(By.Id("btnSubscribe-DeactivateMonthly"));

            Assert.AreEqual("Deactivate", deactivate.GetAttribute("innerHTML"));
        }

        /// <summary>
        /// Confirm successful subscription deactivation
        /// </summary>
        [Test]
        public void TestSubscription_SuccessfulDeactivation()
        {
            SetUpMethod();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement btnSubscriptions = driver.FindElement(By.Id("btnSubscriptions"));
            btnSubscriptions.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSubscribe-DeactivateMonthly")));

            IWebElement deactivate = driver.FindElement(By.Id("btnSubscribe-DeactivateMonthly"));
            deactivate.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnDeactivate")));

            IWebElement btnDeactivate = driver.FindElement(By.Id("btnDeactivate"));
            btnDeactivate.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSubscribe-ReactivateMonthly")));

            IWebElement reactivate = driver.FindElement(By.Id("btnSubscribe-ReactivateMonthly"));

            Assert.AreEqual("Reactivate", reactivate.GetAttribute("innerHTML"));
        }

        /// <summary>
        /// Confirm successful subscription reactivation
        /// </summary>
        [Test]
        public void TestSubscription_SuccessfulReactivation()
        {
            SetUpMethod();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement btnSubscriptions = driver.FindElement(By.Id("btnSubscriptions"));
            btnSubscriptions.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSubscribe-ReactivateMonthly")));

            IWebElement reactivate = driver.FindElement(By.Id("btnSubscribe-ReactivateMonthly"));
            reactivate.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtSecurityCode")));

            IWebElement txtSecurityCodePurchase = driver.FindElement(By.Id("txtSecurityCode"));
            txtSecurityCodePurchase.SendKeys("415");

            IWebElement btnReactivate = driver.FindElement(By.Id("btnReactivate"));
            btnReactivate.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSubscribe-DeactivateMonthly")));

            IWebElement deactivate = driver.FindElement(By.Id("btnSubscribe-DeactivateMonthly"));

            Assert.AreEqual("Deactivate", deactivate.GetAttribute("innerHTML"));
        }
    }
}
