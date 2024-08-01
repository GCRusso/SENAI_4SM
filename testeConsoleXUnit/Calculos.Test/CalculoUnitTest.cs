using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        // AAA : Act, Arrange, Assert
        // AAA : Agir, Organizar, Assertir(Provar)

        [Fact]//Indica que este metodo e um metodo que ira rodar um teste

        public void TestarMetodoSomar() 
        {
            //Arrange : Organizar
            var x1 = 4.1;
            var x2 = 5.9;
            var valorEsperado = 10;

            //Act : Agir
            var soma = Calculo.Somar(x1, x2);

            //Assert: Assertir(Provar)
            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void TestarMetodoSubtrair()
        {
            var x1 = 7;
            var x2 = 5;
            var valorEsperado = 2;
            
            var subtrair = Calculo.Subtrair(x1, x2);

            Assert.Equal(valorEsperado, subtrair);
        }

        [Fact]
        public void TestarMetodoMultiplicar()
        {
            var x1 = 5;
            var x2 = 5;

            var valorEsperado = 25;

            var multiplicar = Calculo.Multiplicar(x1, x2);

            Assert.Equal(valorEsperado, multiplicar);
        }

        [Fact]
        public void TestarMetodoDividir()
        {
            var x1 = 10;
            var x2 = 2;
            var valorEsperado = 5;

            var dividir = Calculo.Dividir(x1, x2);

            Assert.Equal(valorEsperado, dividir);
        }

       

    }
}
