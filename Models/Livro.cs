namespace ExemploApi.Models {
    public class Livro {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Autor Autor { get; set; }

        public Livro() {}
    }
}