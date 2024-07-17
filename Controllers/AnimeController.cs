using GeekWebAPI.Context;
using GeekWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekWebAPI.Controllers
{
    [ApiController]
    [Route("api/animes")]
    public class AnimesController : ControllerBase
    {
        private readonly ILogger<AnimesController> _logger;
        private readonly GeekWebApiContext _context;

        public AnimesController(ILogger<AnimesController> logger, GeekWebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Obtém todos os animes.
        /// </summary>
        /// <returns>Uma lista de animes.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Anime>> GetAllAnimes()
        {
            var allAnimes = _context.Animes.ToList();
            if (allAnimes.Count == 0)
            {
                _logger.LogInformation("GET /api/animes - Nenhum anime encontrado.");
                return NotFound("Nenhum anime encontrado.");
            }
            _logger.LogInformation("GET /api/animes - Animes encontrados com sucesso.");
            return Ok(allAnimes);
        }

        /// <summary>
        /// Obtém animes pelo nome.
        /// </summary>
        /// <param name="name">Nome do anime.</param>
        /// <returns>Uma lista de animes que correspondem ao nome.</returns>
        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Anime>> GetAnimesByName(string name)
        {
            var animes = _context.Animes
                .Where(m => m.Nome.ToLower().Contains(name.ToLower()))
                .ToList();

            if (animes.Count == 0)
            {
                _logger.LogInformation($"GET /api/animes/name/{name} - Nenhum anime encontrado.");
                return NotFound("Nenhum anime encontrado.");
            }
            _logger.LogInformation($"GET /api/animes/name/{name} - Animes encontrados com sucesso.");
            return Ok(animes);
        }

        /// <summary>
        /// Obtém animes pelo gênero.
        /// </summary>
        /// <param name="gender">Gênero do anime.</param>
        /// <returns>Uma lista de animes que correspondem ao gênero.</returns>
        [HttpGet("genre/{gender}")]
        public ActionResult<IEnumerable<Anime>> GetAnimesByGenre(string gender)
        {
            var animes = _context.Animes
                .Where(m => m.Genero.ToLower().Contains(gender.ToLower()))
                .ToList();

            if (animes.Count == 0)
            {
                _logger.LogInformation($"GET /api/animes/genre/{gender} - Nenhum anime encontrado.");
                return NotFound("Nenhum anime encontrado.");
            }
            _logger.LogInformation($"GET /api/animes/genre/{gender} - Animes encontrados com sucesso.");
            return Ok(animes);
        }

        /// <summary>
        /// Adiciona uma lista de animes.
        /// </summary>
        /// <param name="animes">Lista de animes a serem adicionados.</param>
        /// <returns>Os animes adicionados.</returns>
        [Authorize]
        [HttpPost]
        public ActionResult<IEnumerable<Anime>> PostAnimes(List<Anime> animes)
        {
            if (animes == null || animes.Count == 0)
            {
                _logger.LogInformation("POST /api/animes - Nenhum anime para adicionar.");
                return BadRequest("Nenhum anime para adicionar.");
            }

            try
            {
                var allAnimes = _context.Animes.ToList();
                foreach (var anime in animes)
                {
                    if (!allAnimes.Any(a => a.Nome == anime.Nome && a.Genero == anime.Genero))
                    {
                        _context.Animes.Add(anime);
                    }
                }

                _context.SaveChanges();
                _logger.LogInformation("POST /api/animes - Animes adicionados com sucesso.");
                return CreatedAtAction(nameof(GetAllAnimes), new { }, animes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST /api/animes - Ocorreu um erro ao adicionar animes.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
