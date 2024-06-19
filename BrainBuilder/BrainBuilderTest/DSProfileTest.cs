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
    public class ProfileTests
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
        /// Confirm display name validation
        /// </summary>
        [Test]
        public void TestProfile_EditEmptyName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement btnEditProfile = driver.FindElement(By.Id("btnEditProfile"));
            btnEditProfile.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtDisplayName")));

            IWebElement txtDisplayName = driver.FindElement(By.Id("txtDisplayName"));
            txtDisplayName.SendKeys(Keys.Control + "a");
            txtDisplayName.SendKeys(Keys.Delete);

            IWebElement btnSave = driver.FindElement(By.Id("btnSave"));
            btnSave.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtDisplayName")));

            IWebElement error = driver.FindElement(By.Id("txtDisplayName-error"));

            Assert.AreEqual("Display Name cannot be empty", error.Text);
        }

        /// <summary>
        /// Successful display name and motto change
        /// </summary>
        [Test]
        public void TestProfile_SuccessNameAndMotto()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement btnEditProfile = driver.FindElement(By.Id("btnEditProfile"));
            btnEditProfile.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtDisplayName")));

            IWebElement txtDisplayName = driver.FindElement(By.Id("txtDisplayName"));
            txtDisplayName.SendKeys(Keys.Control + "a");
            txtDisplayName.SendKeys(Keys.Delete);
            txtDisplayName.SendKeys("Admin Unit Test");

            IWebElement txtMotto = driver.FindElement(By.Id("txtMotto"));
            txtMotto.SendKeys(Keys.Control + "a");
            txtMotto.SendKeys(Keys.Delete);
            txtMotto.SendKeys("Selenium Unit Test");

            IWebElement btnSave = driver.FindElement(By.Id("btnSave"));
            btnSave.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lblName")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lblMotto")));

            //IWebElement lblName = driver.FindElement(By.Id("lblName"));
            //IWebElement lblMotto = driver.FindElement(By.Id("lblMotto"));

            //Gets inner HTML based on the Xpath - driver.FindElement by Id only brings back the element id
            IWebElement lblName = driver.FindElement(By.XPath(".//h4[contains(@id,'lblName')]"));
            IWebElement lblMotto = driver.FindElement(By.XPath(".//p[contains(@id,'lblMotto')]"));

            var innerHtmlName = lblName.GetAttribute("innerHTML");
            var innerHtmlMotto = lblMotto.GetAttribute("innerHTML");
            var testResult = innerHtmlName + " " + innerHtmlMotto;


            Assert.AreEqual("Admin Unit Test Selenium Unit Test", testResult);
        }
    }
}
