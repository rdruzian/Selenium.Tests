using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void MostrarLeiloesTitulo()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //assert
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void ProximosLeiloes()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }

        [Fact]
        public void NaoMostraMsgErro()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //assert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach(var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }

        }
    }
}
