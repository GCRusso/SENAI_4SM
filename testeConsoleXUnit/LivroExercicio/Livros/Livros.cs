using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros
{
    public class Livros
    { 
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Livros(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
    }

    public class Biblioteca
    {
        private List<Livros> livros;

        public Biblioteca()
        {
            livros = new List<Livros>();
        }

        public void AdicionarLivro(Livros livro)
        {
            livros.Add(livro);
        }

        public List<Livros> ObterLivros()
        {
            return livros;
        }
    }
}
