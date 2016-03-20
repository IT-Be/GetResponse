using GetResponseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace GetResponse.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private IWebDriver _driver;

        [TestInitialize()]
        public void BeforeTests()
        {
            _driver = SeleniumMethods.ConfigureDriver(_driver, "ie", SeleniumParameters.IeDriverPath);
        }

        [TestMethod]
        public void LoginNegativeToGetResponse_EmptyFields()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            var errorMessageLabel = _driver.FindElement(By.XPath("//div[@class='error' or @class='error with-captcha']"));
            Assert.AreEqual("Invalid login details", errorMessageLabel.Text, "Błędny komunikat o niepoprawnym logowaniu.");
        }

        [TestMethod]
        public void LoginNegativeToGetResponse_EmptyField_Password()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();
            usernameInput.SendKeys("zosia.nieznalska@gmail.com");

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            var errorMessageLabel = _driver.FindElement(By.XPath("//div[@class='error' or @class='error with-captcha']"));
            Assert.AreEqual("Invalid login details", errorMessageLabel.Text, "Błędny komunikat o niepoprawnym logowaniu.");
        }

        [TestMethod]
        public void LoginNegativeToGetResponse_EmptyField_Login()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();
            passwordInput.SendKeys("wpisz hasło");

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            var errorMessageLabel = _driver.FindElement(By.XPath("//div[@class='error' or @class='error with-captcha']"));
            Assert.AreEqual("Invalid login details", errorMessageLabel.Text, "Błędny komunikat o niepoprawnym logowaniu.");
        }

        [TestMethod]
        public void LoginNegativeToGetResponse_WrongLogin()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();
            usernameInput.SendKeys("wronglogin@gmail.com");

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();
            passwordInput.SendKeys("wpisz hasło");

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            var errorMessageLabel = _driver.FindElement(By.XPath("//div[@class='error' or @class='error with-captcha']"));
            Assert.AreEqual("Invalid login details", errorMessageLabel.Text, "Błędny komunikat o niepoprawnym logowaniu.");
        }

        [TestMethod]
        public void LoginNegativeToGetResponse_WrongPassword()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();
            usernameInput.SendKeys("zosia.nieznalska@gmail.com");

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();
            passwordInput.SendKeys("wrongpassword");

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            var errorMessageLabel = _driver.FindElement(By.XPath("//div[@class='error' or @class='error with-captcha']"));
            Assert.AreEqual("Invalid login details", errorMessageLabel.Text, "Błędny komunikat o niepoprawnym logowaniu.");
        }
        [TestMethod]
        public void LoginPositiveToGetResponse()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();
            usernameInput.SendKeys("zosia.nieznalska@gmail.com");

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();
            passwordInput.SendKeys("wpisz hasło");

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            Assert.AreEqual("https://app.getresponse.com/main.html", _driver.Url, "Nie udało się poprawnie zalogować.");
        }

        [TestMethod]
        public void LogOut()
        {
            _driver = SeleniumMethods.GoToWebsite(_driver, SeleniumParameters.GetResponseURL);

            var usernameInput = _driver.FindElement(By.Id("login"));
            usernameInput.Clear();
            usernameInput.SendKeys("zosia.nieznalska@gmail.com");

            var passwordInput = _driver.FindElement(By.Id("passwdInp2"));
            passwordInput.Clear();
            passwordInput.SendKeys("wpisz hasło");

            var submitButton = _driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Submit();

            Thread.Sleep(1000);

            var logout = _driver.FindElement(By.XPath("//a[@href='https://app.getresponse.com/logout.html']"));
            logout.Click();

            Thread.Sleep(1000);

            Assert.AreEqual("https://app.getresponse.com/loggedout.html", _driver.Url, "Nie udało się poprawnie zalogować.");
        }

        [TestCleanup]
        public void AfterTest()
        {
            Thread.Sleep(3000);
            _driver.Dispose();
        }
    }
}