using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros
{
   public class Livro
    {
        //Crie um teste unitário para o método AdicionarLivro que verifica
        //se um livro é adicionado corretamente a uma lista de livros.
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Livro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
    }

    public class Biblioteca
    {
        private List<Livro> livros;

        public Biblioteca()
        {
            livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public List<Livro> ObterLivros()
        {
            return livros;
        }
    }
}
