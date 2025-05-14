using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace PruebasAutomatizadas
{
    public class PruebaLogin
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void LoginCorrecto()
        {
            // Cambia esta URL por la que uses tú localmente
            driver.Navigate().GoToUrl("https://localhost:44342/Acceso/Login");

            // Localiza los campos por name, id o cualquier selector que estés usando
            driver.FindElement(By.Name("Correo")).SendKeys("usuario@prueba.com");
            driver.FindElement(By.Name("Clave")).SendKeys("clave123");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // Valida redirección a Home/Index
            Assert.That(driver.Url.Contains("/Home/Index"), Is.True);
        }

        [Test]
        public void LoginInvalido()
        {
            driver.Navigate().GoToUrl("https://localhost:44342/Acceso/Login");

            driver.FindElement(By.Name("Correo")).SendKeys("usuario@invalido.com");
            driver.FindElement(By.Name("Clave")).SendKeys("claveIncorrecta");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // Verifica el mensaje de error
            Assert.That(driver.PageSource.Contains("Usuario no encontrado"), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); // Asegura la liberación completa de recursos
            }
        }
    }
}


