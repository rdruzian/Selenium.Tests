using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    class RegistroPO
    {
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;
        private By byBotaoRegistro;
        private By bySpanErroNome;

        public string NomeMsgErro => driver.FindElement(bySpanErroNome).Text;

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void SubmeteForm()
        {
            driver.FindElement(byBotaoRegistro).Click();
        }

        public void PreencheForm(string nome, string email, string senha, string confirmSenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
        }
    }
}
