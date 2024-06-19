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

/*
 ********
 * DSRegisterTest
 * Test unit used for testing register
 * Date Created: 02/25/2021
 * Desert Sands 
 *********
*/


/// <summary>
/// NOTE: TO RUN TESTS, YOU NEED ANOTHER VERSION OF THIS PROJECT OPEN AND RUNNING TO ALLOW THESE TESTS
/// TO ACCESS LOCALHOST PROPERLY
/// </summary>
/// 
namespace DesertSandsTests
{
    [TestFixture]
    public class RegisterTests
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
        /// Create starting points of tests with a logged in user on profile page
        /// </summary>
        [SetUp]
        public void SetUpMethod()
        {
            driver = new ChromeDriver("../../../bin/Debug/netcoreapp2.2/");
            driver.Navigate().GoToUrl("https://localhost:44338/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnRegister")));

            IWebElement btnRegister = driver.FindElement(By.Id("btnRegister"));
            btnRegister.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));
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
        /// Confirm password requirement validation
        /// </summary>
        [Test]
        public void TestRegister_PasswordRequired()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
            btnSubmitUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement error = driver.FindElement(By.Id("txtPassword-error"));

            Assert.AreEqual("The Password field is required.", error.Text);
        }

        /// <summary>
        /// Confirm strong password validation
        /// </summary>
        [Test]
        public void TestRegister_PasswordWeak()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("Testing");
            IWebElement txtConfirmPassword = driver.FindElement(By.Id("txtConfirmPassword"));
            txtConfirmPassword.SendKeys("Testing");

            IWebElement btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
            btnSubmitUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement error = driver.FindElement(By.Id("txtPassword-error"));

            Assert.AreEqual("Password must have at least one capital letter, one number, and one symbol(!@#$&*).", error.Text);
        }

        /// <summary>
        /// Confirm password matches confirm password field validation
        /// </summary>
        [Test]
        public void TestRegister_PasswordDifferent()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("Test1!");
            IWebElement txtConfirmPassword = driver.FindElement(By.Id("txtConfirmPassword"));
            txtConfirmPassword.SendKeys("Test!1");

            IWebElement btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
            btnSubmitUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement error = driver.FindElement(By.Id("txtConfirmPassword-error"));

            Assert.AreEqual("The password and confirmation password do not match.", error.Text);
        }

        /// <summary>
        /// Confirm user names can't have duplicate entries
        /// </summary>
        [Test]
        public void TestRegister_UserNameDuplicate()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement txtUserName = driver.FindElement(By.Id("txtUserName"));
            txtUserName.SendKeys("Admin");

            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("Test1!");
            IWebElement txtConfirmPassword = driver.FindElement(By.Id("txtConfirmPassword"));
            txtConfirmPassword.SendKeys("Test1!");

            IWebElement btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
            btnSubmitUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement error = driver.FindElement(By.Id("txtUserName-error"));

            Assert.AreEqual("User Name already in use", error.Text);
        }

        /// <summary>
        /// Confirm emails can't have duplicate entries
        /// </summary>
        [Test]
        public void TestRegister_EmailDuplicate()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement txtEmail = driver.FindElement(By.Id("txtEmail"));
            txtEmail.SendKeys("admin@gmail.com");

            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("Test1!");
            IWebElement txtConfirmPassword = driver.FindElement(By.Id("txtConfirmPassword"));
            txtConfirmPassword.SendKeys("Test1!");

            IWebElement btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
            btnSubmitUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement error = driver.FindElement(By.Id("txtEmail-error"));

            Assert.AreEqual("Email already in use", error.Text);
        }

        /// <summary>
        /// Confirm email validation
        /// </summary>
        [Test]
        public void TestRegister_InvalidEmail()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement txtEmail = driver.FindElement(By.Id("txtEmail"));
            txtEmail.SendKeys("test@gmail");

            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("Test1!");
            IWebElement txtConfirmPassword = driver.FindElement(By.Id("txtConfirmPassword"));
            txtConfirmPassword.SendKeys("Test1!");

            IWebElement btnSubmitUser = driver.FindElement(By.Id("btnSubmitUser"));
            btnSubmitUser.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtUserName")));

            IWebElement error = driver.FindElement(By.Id("txtEmail-error"));

            Assert.AreEqual("Email is not in the right format. EX. test@test.ca", error.Text);
        }

        /// <summary>
        /// Confirm successful user creation
        /// </summary>
        [Test]
        public void TestRegister_SuccessfulUserCreation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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

            IWebElement btnProfile = driver.FindElement(By.Id("btnProfile"));

            Assert.AreEqual("PROFILE", btnProfile.Text);
        }
    }
}
