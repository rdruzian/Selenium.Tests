using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoPageAgradecimento()
        {
            // arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Pega os elementos pelo ID do html
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //Entrada de dados no form
            inputNome.SendKeys("Renato Druzian");
            inputEmail.SendKeys("rendruzian@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            //act
            // ação de click no botão de Registro
            botaoRegistro.Click();

            //assert
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData( "", "rendruzian@gmail.com", "123", "123")]
        [InlineData("Renato Druzian", "rendruzian", "123", "123")]
        [InlineData("Renato Druzian", "rendruzian@gmail.com", "123", "456")]
        [InlineData("Renato Druzian", "rendruzian@gmail.com", "123", "")]
        public void DadoInfoInvalidoPageIndex(string nome, string email, string senha, string confirmSenha)
        {
            // arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Pega os elementos pelo ID do html
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //Entrada de dados no form
            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            //act
            // ação de click no botão de Registro
            botaoRegistro.Click();

            //assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBranco()
        {
            // arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            // ação de click no botão de Registro
            botaoRegistro.Click();

            //assert
            //By.TagName é uma opção, se tivesse apenas uma opção de span
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailInvalido()
        {
            // arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheForm(nome: "", email: "renato", senha: "", confirmSenha: "");

            //act
            // ação de click no botão de Registro
            registroPO.SubmeteForm();

            //assert
            //By.TagName é uma opção, se tivesse apenas uma opção de span
            Assert.Equal("Please enter a valid email address.", registroPO.NomeMsgErro);
        }
    }
}
