using System.Collections.Generic;

namespace ExemploApi.Models {
    public class Autor {
        public string Nome { get; set; }
        public string Pais { get; set; }
        public List<Livro> Livros { get; set; }

        public Autor() {
            Livros = new List<Livro>();
        }
    }
}