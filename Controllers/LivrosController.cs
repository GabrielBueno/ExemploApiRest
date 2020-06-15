using System.Collections.Generic;
using System.Linq;
using ExemploApi.Models;
using ExemploApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExemploApi.Controllers {
    [Route("api/v1/livros")]
    [ApiController]
    public class LivrosController : ControllerBase {
        private readonly LivroRepository _livros;

        public LivrosController(LivroRepository livroRepository) {
            _livros = livroRepository;
        }

        /// <summary>
        /// Obtém todos os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ObterTodos() {
            var livros = _livros.Get();

            return Ok(livros);
        }

        /// <summary>
        /// Obtém um livro por Id
        /// </summary>
        /// <param name="id">O Id do livro buscado</param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public IActionResult ObterPorId(long id) {
            var livro = _livros.Get(id);

            if (livro == null)
                return NotFound("Livro não encontrado");

            return Ok(livro);
        }

        /// <summary>
        /// Cria um novo livro
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     { 
        /// 	    "titulo": "string",
        ///         "descricao": "string",
        /// 	    "autor": {
        /// 		    "nome": "string",
        /// 		    "pais": "string"
        /// 	    }
        ///     }
        /// </remarks>
        /// <param name="livro">O objeto que representa o livro que será criado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Criar(Livro livro) {
           var livroCriado = _livros.Add(livro);

            return CreatedAtAction(nameof(ObterPorId), new { id = livroCriado.Id }, livroCriado);
        }

        /// <summary>
        /// Edita os dados de um livro
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     { 
        /// 	    "titulo": "string",
        ///         "descricao": "string",
        /// 	    "autor": {
        /// 		    "nome": "string",
        /// 		    "pais": "string"
        /// 	    }
        ///     }
        /// </remarks>
        /// <param name="id">O Id do livro que será editado</param>
        /// <param name="livro">Objeto contendo os novos dados do livro</param>
        /// <returns></returns>
        [HttpPut("{id:long}")]
        public IActionResult Editar(long id, Livro livro) {
            if (_livros.Get(id) == null) // Antes de editar, verifica se existe um livro com o Id passado
                return NotFound("Livro não encontrado");

            var livroEditado = _livros.Update(id, livro);

            return Ok(livroEditado);
        }

        /// <summary>
        /// Remove um livro
        /// </summary>
        /// <param name="id">O Id do livro que será removido</param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        public IActionResult Remover(long id) {
            if (_livros.Get(id) == null) // Antes de remover, verifica se existe um livro com o Id passado
                return NotFound("Livro não encontrado");

            _livros.Remove(id);

            return NoContent();
        }
    }
}