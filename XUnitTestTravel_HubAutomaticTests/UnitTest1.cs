using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace XUnitTestTravel_HubAutomaticTests
{
    public class UnitTest1:IDisposable
    {
        private readonly IWebDriver driver;

        public UnitTest1()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44372/Wycieczkas");
        }
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        // ca³y proces od wybrania wycieczki do rezerwacji
        // test logowania

        [Fact]
        public void Login_ValidData_ReturnsIndexView()
        {
            driver.Navigate().GoToUrl("https://localhost:44372/Identity/Account/Login");
            driver.FindElement(By.Id("Input_Email")).SendKeys("normaluser@localhost");
            driver.FindElement(By.Id("Input_Password")).SendKeys("Qwerty1!");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.Equal("Travel_Hub home page - Travel_Hub", driver.Title);
        }

        [Fact]
        public void Login_InvalidData_ReturnsIndexView()
        {
            driver.Navigate().GoToUrl("https://localhost:44372/Identity/Account/Login");
            driver.FindElement(By.Id("Input_Email")).SendKeys("test@test");
            driver.FindElement(By.Id("Input_Password")).SendKeys("1!PassWord");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.Equal("Log in - Travel_Hub", driver.Title);
        }

        [Fact]
        public void Annonymus_Rserwation_ReturnsLoginView()
        {
            driver.Navigate().GoToUrl("https://localhost:44372/Wycieczkas/Details/1");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.Equal("Log in - Travel_Hub", driver.Title);
        }
        [Fact]
        public void Client_Rserwation_PotwierdzRezerwacjeView()
        {
            driver.Navigate().GoToUrl("https://localhost:44372/Identity/Account/Login");
            driver.FindElement(By.Id("Input_Email")).SendKeys("normaluser@localhost");
            driver.FindElement(By.Id("Input_Password")).SendKeys("Qwerty1!");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            driver.Navigate().GoToUrl("https://localhost:44372/Wycieczkas/Details/1");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Assert.Equal("Potwierdz Rezerwacje - Travel_Hub", driver.Title);
        }
    }
}
