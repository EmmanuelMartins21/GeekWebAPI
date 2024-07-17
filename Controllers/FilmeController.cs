using GeekWebAPI.Context;
using GeekWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekWebAPI.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class FilmesController : ControllerBase
    {
        private readonly ILogger<FilmesController> _logger;
        private readonly GeekWebApiContext _context;

        public FilmesController(ILogger<FilmesController> logger, GeekWebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Obtém todos os filmes da Marvel.
        /// </summary>
        /// <returns>Uma lista de filmes da Marvel.</returns>
        [HttpGet("marvel")]
        public ActionResult<IEnumerable<Filme>> GetMarvelMovies()
        {
            _logger.LogInformation("GET /api/filmes/marvel - Iniciando busca de todos os filmes da Marvel " + DateTime.Now);
            try
            {
                var marvelMovies = _context.Filmes
                    .Where(f => f.Empresa.ToLower().Contains("marvel"))
                    .ToList();

                if (marvelMovies.Count == 0)
                {
                    _logger.LogInformation("GET /api/filmes/marvel - Nenhum filme encontrado " + DateTime.Now);
                    return NotFound("Nenhum filme da Marvel encontrado.");
                }
                _logger.LogInformation("GET /api/filmes/marvel - Filmes localizados com sucesso " + DateTime.Now);
                return Ok(marvelMovies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET /api/filmes/marvel - Ocorreu um erro ao buscar os filmes");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        /// <summary>
        /// Obtém todos os filmes da DC.
        /// </summary>
        /// <returns>Uma lista de filmes da DC.</returns>
        [HttpGet("dc")]
        public ActionResult<IEnumerable<Filme>> GetDcMovies()
        {
            _logger.LogInformation("GET /api/filmes/dc - Iniciando busca de todos os filmes da DC " + DateTime.Now);
            try
            {
                var dcMovies = _context.Filmes
                    .Where(f => f.Empresa.ToLower().Contains("warner"))
                    .ToList();

                if (dcMovies.Count == 0)
                {
                    _logger.LogInformation("GET /api/filmes/dc - Nenhum filme encontrado " + DateTime.Now);
                    return NotFound("Nenhum filme da DC encontrado.");
                }
                _logger.LogInformation("GET /api/filmes/dc - Filmes localizados com sucesso " + DateTime.Now);
                return Ok(dcMovies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET /api/filmes/dc - Ocorreu um erro ao buscar os filmes");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        /// <summary>
        /// Obtém todos os filmes.
        /// </summary>
        /// <returns>Uma lista de todos os filmes.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Filme>> GetAllMovies()
        {
            _logger.LogInformation("GET /api/filmes - Iniciando busca de todos os filmes " + DateTime.Now);
            var allMovies = _context.Filmes.ToList();

            if (allMovies.Count == 0)
            {
                _logger.LogInformation("GET /api/filmes - Nenhum filme encontrado " + DateTime.Now);
                return NotFound("Nenhum filme encontrado.");
            }
            _logger.LogInformation("GET /api/filmes - Filmes localizados com sucesso " + DateTime.Now);
            return Ok(allMovies);
        }

        /// <summary>
        /// Obtém filmes pelo nome.
        /// </summary>
        /// <param name="name">Nome do filme.</param>
        /// <returns>Uma lista de filmes que correspondem ao nome.</returns>
        [HttpGet("search")]
        public ActionResult<IEnumerable<Filme>> GetMoviesByName(string name)
        {
            _logger.LogInformation($"GET /api/filmes/search - Buscando filmes por nome: {name} " + DateTime.Now);
            try
            {
                var movies = _context.Filmes
                    .Where(f => f.Nome.ToLower().Contains(name.ToLower()))
                    .ToList();

                if (movies.Count == 0)
                {
                    _logger.LogInformation($"GET /api/filmes/search - Nenhum filme encontrado para o nome: {name} " + DateTime.Now);
                    return NotFound("Nenhum filme encontrado.");
                }
                _logger.LogInformation($"GET /api/filmes/search - Filmes localizados com sucesso para o nome: {name} " + DateTime.Now);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GET /api/filmes/search - Ocorreu um erro ao buscar os filmes por nome: {name}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        /// <summary>
        /// Adiciona uma lista de filmes.
        /// </summary>
        /// <param name="movies">Lista de filmes a serem adicionados.</param>
        /// <returns>Os filmes adicionados.</returns>
        [Authorize]
        [HttpPost]
        public ActionResult<IEnumerable<Filme>> PostMovies(List<Filme> movies)
        {
            if (movies == null || movies.Count == 0)
            {
                _logger.LogInformation("POST /api/filmes - Nenhum filme para adicionar " + DateTime.Now);
                return BadRequest("Nenhum filme para adicionar.");
            }

            try
            {
                var allMovies = _context.Filmes.ToList();
                foreach (var movie in movies)
                {
                    if (!allMovies.Any(m => m.Nome == movie.Nome && m.Empresa == movie.Empresa))
                    {
                        _context.Filmes.Add(movie);
                    }
                }

                _context.SaveChanges();
                _logger.LogInformation("POST /api/filmes - Filmes adicionados com sucesso " + DateTime.Now);
                return CreatedAtAction(nameof(GetAllMovies), new { }, movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST /api/filmes - Ocorreu um erro ao adicionar filmes");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
