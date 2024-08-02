using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Temperatura;

namespace TemperaturaTest
{
    public class TemperaturaTestUnit
    {

        [Fact]
        public void ConverterCelsiusParaFahrenheit()
        {
            // Test cases
            var testando = new[]
            {
            new { Celsius = 0.0, FahrenheitEsperado = 32.0 }
        };

            foreach (var teste in testando)
            {
                // Act
                var resultado = ConversorTemperatura.Converter(teste.Celsius);

                // Assert
                Assert.Equal(teste.FahrenheitEsperado, resultado, 1);
            }
        }

    }
}
