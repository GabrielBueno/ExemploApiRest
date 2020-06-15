using System;
using System.Collections.Generic;
using System.Linq;
using ExemploApi.Models;

namespace ExemploApi.Repositories {
    public class LivroRepository {
        private readonly List<Livro> _livros;
        
        public LivroRepository() {
            _livros  = new List<Livro>();

            var tolkien   = new Autor { Nome = "J.R.R. Tolkien",    Pais = "Inglaterra" }; 
            var sapkowski = new Autor { Nome = "Andrzej Sapkowski", Pais = "Polônia" };
            var euripedes = new Autor { Nome = "Eurípedes",         Pais = "Grécia" };
            var campbell  = new Autor { Nome = "Joseph Campbell",   Pais = "EUA" };

            _livros.Add(new Livro { Id = 1, Autor = tolkien,   Titulo = "O Silmarillion",             Descricao = "" });
            _livros.Add(new Livro { Id = 2, Autor = sapkowski, Titulo = "Batismo de Fogo",            Descricao = "" });
            _livros.Add(new Livro { Id = 3, Autor = sapkowski, Titulo = "A Senhora do Lago",          Descricao = "" });
            _livros.Add(new Livro { Id = 4, Autor = euripedes, Titulo = "As Bacantes",                Descricao = "" });
            _livros.Add(new Livro { Id = 5, Autor = tolkien,   Titulo = "A Lenda de Sigurd e Gudrún", Descricao = "" });
            _livros.Add(new Livro { Id = 6, Autor = campbell,  Titulo = "O Herói de Mil Faces",       Descricao = "" });
        }

        /// <summary>
        /// Obtém todos os livros
        /// </summary>
        /// <returns>A lista de livros existente</returns>
        public List<Livro> Get()
            => _livros;

        /// <summary>
        /// Obtém um livro por Id
        /// </summary>
        /// <param name="id">O Id do livro buscado</param>
        /// <returns>O livro com o Id especificado, ou nulo caso não exista</returns>
        public Livro Get(long id)
            => _livros.FirstOrDefault(l => l.Id == id);

        /// <summary>
        /// Adiciona um livro ao fim da lista
        /// </summary>
        /// <param name="livro">O objeto que representa o livro que deve ser adicionado</param>
        /// <returns>O objeto adicionado</returns>
        public Livro Add(Livro livro) {
            var livroParaCriar = new Livro {
                Id        = NextId(),
                Titulo    = livro.Titulo,
                Descricao = livro.Descricao,

                Autor = new Autor {
                    Nome = livro.Autor.Nome,
                    Pais = livro.Autor.Pais
                }
            };

            _livros.Add(livroParaCriar);

            return livroParaCriar;
        }

        /// <summary>
        /// Atualiza um livro
        /// </summary>
        /// <param name="id">O Id do livro que será editado</param>
        /// <param name="livro">Objeto com os dados que serão editados</param>
        /// <returns>O livro editado</returns>
        public Livro Update(long id, Livro livro) {
            var livroParaEditar = Get(id);

            if (livroParaEditar == null)
                throw new KeyNotFoundException("Livro não encontrado");

            livroParaEditar.Titulo     = livro.Titulo;
            livroParaEditar.Descricao  = livro.Descricao;
            livroParaEditar.Autor.Nome = livro.Autor.Nome;
            livroParaEditar.Autor.Pais = livro.Autor.Pais;

            return livroParaEditar;
        }

        /// <summary>
        /// Remove um livro da lista
        /// </summary>
        /// <param name="id">Id do livro que será removido</param>
        public void Remove(long id) {
            var livroParaRemover = Get(id);

            if (livroParaRemover == null)
                throw new KeyNotFoundException("Livro não encontrado");

            _livros.Remove(livroParaRemover);
        }

        /// <summary>
        /// Calcula o Id do próximo elemento a ser inserido na lista
        /// </summary>
        /// <returns>O Id do próximo elemento a ser inserido na lista</returns>
        private long NextId() 
            => (_livros.LastOrDefault()?.Id ?? 0) + 1;
    }
}