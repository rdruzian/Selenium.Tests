using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void CredenciaisValidasVaiDasboard()
        {
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencheForm("fulano@example.org", "123");

            loginPO.SubmeteForm();

            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void CredenciaisInvalidas()
        {
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencheForm("fulano@example.org", "");


            loginPO.SubmeteForm();

            Assert.Contains("Login", driver.PageSource);
        }
    }
}
