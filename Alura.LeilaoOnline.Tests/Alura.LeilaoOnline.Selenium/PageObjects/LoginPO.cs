using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheForm(string login, string senha)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputSenha).SendKeys(senha);
        }

        public void SubmeteForm()
        {
            driver.FindElement(byBotaoLogin).Click(); //nesse caso pode usar a função Submit() ao inves de Click()
        }
    }
}
