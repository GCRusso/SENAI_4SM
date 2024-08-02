using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperatura
{
    public static class ConversorTemperatura
    {
        public static double Converter(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }
}
