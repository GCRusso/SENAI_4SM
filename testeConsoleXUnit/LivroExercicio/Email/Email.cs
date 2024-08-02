using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Email
{

        public static class Validador
        {
            public static bool ValidarEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

            // Validação básica de email
            //[] : Define um conjunto de caracteres que são permitidos.
            //`^` dentro dos colchetes: Quando usado dentro de colchetes, `^` significa "não".
            //`@` : Exclui o caractere '@'.
            //`\s`: Exclui qualquer espaço em branco (incluindo espaços, tabulações e novas linhas).
            //`+` : Indica que o conjunto de caracteres especificado deve aparecer uma ou mais vezes.
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
        }
    
}
