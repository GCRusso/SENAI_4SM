using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // Adicione esta diretiva para xUnit
using Email;




namespace EmailTestUnit
{
    public class EmailTest
    {

        [Theory]
        [InlineData("usuario@gmail.com", true)]
        [InlineData("usuario@gmail", false)]
        [InlineData("usuario@.com", false)]
        [InlineData("usuario@gmail.", false)]
        [InlineData("usuario.gmail.com", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ValidarEmail_DeveRetornarCorretamente(string email, bool resultadoEsperado)
        {
            // Act
            var resultado = Validador.ValidarEmail(email);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
