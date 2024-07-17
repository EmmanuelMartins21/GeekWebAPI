using GeekWebAPI.Context;
using GeekWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekWebAPI.Controllers;

[ApiController]
[Route("api/books")]
public class LivrosController : ControllerBase
{
    private readonly ILogger<LivrosController> _logger;
    private readonly GeekWebApiContext _context;

    public LivrosController(ILogger<LivrosController> logger, GeekWebApiContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Obtém todos os livros.
    /// </summary>
    /// <returns>Uma lista de todos os livros.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Livro>> GetAllBooks()
    {
        _logger.LogInformation("GET /api/livros - Iniciando busca de todos os livros " + DateTime.Now);
        var allBooks = _context.Livros.ToList();

        if (allBooks.Count == 0)
        {
            _logger.LogInformation("GET /api/livros - Nenhum livro encontrado " + DateTime.Now);
            return NotFound("Nenhum livro encontrado.");
        }
        _logger.LogInformation("GET /api/livros - Livros localizados com sucesso " + DateTime.Now);
        return Ok(allBooks);
    }

    /// <summary>
    /// Obtém livros pelo nome.
    /// </summary>
    /// <param name="name">Nome do livro.</param>
    /// <returns>Uma lista de livros que correspondem ao nome.</returns>
    [HttpGet("search")]
    public ActionResult<IEnumerable<Livro>> GetBooksByName(string name)
    {
        _logger.LogInformation($"GET /api/livros/search - Buscando livros por nome: {name} " + DateTime.Now);
        try
        {
            var books = _context.Livros
                .Where(b => b.Nome.ToLower().Contains(name.ToLower()))
                .ToList();

            if (books.Count == 0)
            {
                _logger.LogInformation($"GET /api/livros/search - Nenhum livro encontrado para o nome: {name} " + DateTime.Now);
                return NotFound("Nenhum livro encontrado.");
            }
            _logger.LogInformation($"GET /api/livros/search - Livros localizados com sucesso para o nome: {name} " + DateTime.Now);
            return Ok(books);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"GET /api/livros/search - Ocorreu um erro ao buscar os livros por nome: {name}");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    /// <summary>
    /// Obtém livros pela editora.
    /// </summary>
    /// <param name="editora">Nome da editora.</param>
    /// <returns>Uma lista de livros que correspondem à editora.</returns>
    [HttpGet("editora")]
    public ActionResult<IEnumerable<Livro>> GetBooksByEditora(string editora)
    {
        _logger.LogInformation($"GET /api/livros/editora - Buscando livros por editora: {editora} " + DateTime.Now);
        try
        {
            var books = _context.Livros
                .Where(b => b.Editora.ToLower().Contains(editora.ToLower()))
                .ToList();

            if (books.Count == 0)
            {
                _logger.LogInformation($"GET /api/livros/editora - Nenhum livro encontrado para a editora: {editora} " + DateTime.Now);
                return NotFound("Nenhum livro encontrado.");
            }
            _logger.LogInformation($"GET /api/livros/editora - Livros localizados com sucesso para a editora: {editora} " + DateTime.Now);
            return Ok(books);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"GET /api/livros/editora - Ocorreu um erro ao buscar os livros por editora: {editora}");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    /// <summary>
    /// Adiciona uma lista de livros.
    /// </summary>
    /// <param name="books">Lista de livros a serem adicionados.</param>
    /// <returns>Os livros adicionados.</returns>
    [Authorize]
    [HttpPost]
    public ActionResult<IEnumerable<Livro>> PostBooks(List<Livro> books)
    {
        if (books == null || books.Count == 0)
        {
            _logger.LogInformation("POST /api/livros - Nenhum livro para adicionar " + DateTime.Now);
            return BadRequest("Nenhum livro para adicionar.");
        }

        try
        {
            var allBooks = _context.Livros.ToList();
            foreach (var book in books)
            {
                if (!allBooks.Any(b => b.Nome == book.Nome && b.Editora == book.Editora))
                {
                    _context.Livros.Add(book);
                }
            }

            _context.SaveChanges();
            _logger.LogInformation("POST /api/livros - Livros adicionados com sucesso " + DateTime.Now);
            return CreatedAtAction(nameof(GetAllBooks), new { }, books);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "POST /api/livros - Ocorreu um erro ao adicionar livros");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }
}
