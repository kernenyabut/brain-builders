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

/// <summary>
/// NOTE: TO RUN TESTS, YOU NEED ANOTHER VERSION OF THIS PROJECT OPEN AND RUNNING TO ALLOW THESE TESTS
/// TO ACCESS LOCALHOST PROPERLY
/// </summary>
/// 
namespace DesertSandsTests
{
    [TestFixture]
    public class CreditCardTests
    {
        IWebDriver driver;

        /// <summary>
        /// Create starting points of tests with a logged in user on profile page
        /// </summary>
        [SetUp]
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
        /// Confirm phone number validation
        /// </summary>
        [Test]
        public void TestAddCard_InvalidPhoneNumber()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement txtPhoneNumber = driver.FindElement(By.Id("txtPhoneNumber"));
            txtPhoneNumber.SendKeys("51951951955");

            IWebElement btnSubmitCard = driver.FindElement(By.Id("btnSubmitCard"));
            btnSubmitCard.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement error = driver.FindElement(By.Id("txtPhoneNumber-error"));

            Assert.AreEqual("Phone number must have a valid format. EX. (###)-###-####", error.Text);
        }

        /// <summary>
        /// Confirm address validation
        /// </summary>
        [Test]
        public void TestAddCard_InvalidAddress()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement txtAddress = driver.FindElement(By.Id("txtAddress"));
            txtAddress.SendKeys("Test");

            IWebElement btnSubmitCard = driver.FindElement(By.Id("btnSubmitCard"));
            btnSubmitCard.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement error = driver.FindElement(By.Id("txtAddress-error"));

            Assert.AreEqual("Street address must be a valid address", error.Text);
        }

        /// <summary>
        /// Confirm card length validation
        /// </summary>
        [Test]
        public void TestAddCard_InvalidCardNumberLength()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement optCardCode = driver.FindElement(By.Id("optCardCode"));
            var selectedCardCode = new SelectElement(optCardCode);
            selectedCardCode.SelectByText("VISA");

            IWebElement txtCardNumber = driver.FindElement(By.Id("txtCardNumber"));
            txtCardNumber.SendKeys("4123");

            IWebElement btnSubmitCard = driver.FindElement(By.Id("btnSubmitCard"));
            btnSubmitCard.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement error = driver.FindElement(By.Id("txtCardNumber-error"));

            Assert.AreEqual("VISA cards must have 16 numbers.", error.Text);
        }

        /// <summary>
        /// Confirm card prefix validation
        /// </summary>
        [Test]
        public void TestAddCard_InvalidCardNumberPrefix()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement optCardCode = driver.FindElement(By.Id("optCardCode"));
            var selectedCardCode = new SelectElement(optCardCode);
            selectedCardCode.SelectByText("VISA");

            IWebElement txtCardNumber = driver.FindElement(By.Id("txtCardNumber"));
            txtCardNumber.SendKeys("1234567812345678");

            IWebElement btnSubmitCard = driver.FindElement(By.Id("btnSubmitCard"));
            btnSubmitCard.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement error = driver.FindElement(By.Id("txtCardNumber-error"));

            Assert.AreEqual("VISA cards must have one of these prefixes: 4", error.Text);
        }

        /// <summary>
        /// Confirm postal code validation
        /// </summary>
        [Test]
        public void TestAddCard_InvalidCanadaPostalCode()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement txtPostalCode = driver.FindElement(By.Id("txtPostalCode"));
            txtPostalCode.SendKeys("74635");

            IWebElement btnSubmitCard = driver.FindElement(By.Id("btnSubmitCard"));
            btnSubmitCard.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optCardCode")));

            IWebElement error = driver.FindElement(By.Id("txtPostalCode-error"));

            Assert.AreEqual("Postal code is in the wrong format", error.Text);
        }

        /// <summary>
        /// Confirm successful card input
        /// </summary>
        [Test]
        public void TestAddCard_SuccessfulCardInput()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

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

            Assert.AreEqual("Credit Card successfully inserted.", debugMessage.GetAttribute("innerHTML"));
        }
    }
}
