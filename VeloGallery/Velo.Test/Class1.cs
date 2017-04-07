using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Velo.Test
{
    [TestFixture]
    public class Class1
    {
        public void Authorize()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:59311/Angular/Gallery");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("emailAddress")).SendKeys("admin@mail.ru");
            driver.FindElement(By.Id("password")).SendKeys("admin");
            driver.FindElement(By.Id("login")).Click();

            Assert.Pass();
            driver.Quit();
        }
    }
}

