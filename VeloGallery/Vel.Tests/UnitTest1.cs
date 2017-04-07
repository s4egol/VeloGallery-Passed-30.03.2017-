using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Vel.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Authorize()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:9026/Angular/Gallery");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("emailAddress")).SendKeys("admin@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("admin");
            driver.FindElement(By.Id("login")).Click();

            NUnit.Framework.Assert.Pass();
            driver.Quit();
        }
    }
}
