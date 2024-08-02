using Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Livros
{
    public class LivrosTestUnit
    {
        [Fact]
        public void AdicionarLivro_DeveAdicionarLivroNaLista()
        {
            // Arrange
            var biblioteca = new Biblioteca();
            var livro = new Livros("O Senhor dos Anéis", "J.R.R. Tolkien");

            // Act
            biblioteca.AdicionarLivro(livro);

            // Assert
            var livros = biblioteca.ObterLivros();
            Assert.Contains(livro, livros);
            Assert.Equal(1, livros.Count);
        }
    }

}
