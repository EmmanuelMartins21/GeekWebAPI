using GeekWebAPI.Context;
using GeekWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekWebAPI.Controllers;

[ApiController]
[Route("api/series")]
public class SeriesController : ControllerBase
{
    private readonly ILogger<SeriesController> _logger;
    private readonly GeekWebApiContext _context;

    public SeriesController(ILogger<SeriesController> logger, GeekWebApiContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Obtém todas as séries.
    /// </summary>
    /// <returns>Uma lista de todas as séries.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Serie>> GetAllSeries()
    {
        _logger.LogInformation("GET /api/series - Iniciando busca de todas as séries " + DateTime.Now);
        var allSeries = _context.Series.ToList();

        if (allSeries.Count == 0)
        {
            _logger.LogInformation("GET /api/series - Nenhuma série encontrada " + DateTime.Now);
            return NotFound("Nenhuma série encontrada.");
        }
        _logger.LogInformation("GET /api/series - Séries localizadas com sucesso " + DateTime.Now);
        return Ok(allSeries);
    }

    /// <summary>
    /// Obtém séries pelo nome.
    /// </summary>
    /// <param name="name">Nome da série.</param>
    /// <returns>Uma lista de séries que correspondem ao nome.</returns>
    [HttpGet("search")]
    public ActionResult<IEnumerable<Serie>> GetSeriesByName(string name)
    {
        _logger.LogInformation($"GET /api/series/search - Buscando séries por nome: {name} " + DateTime.Now);
        try
        {
            var series = _context.Series
                .Where(s => s.Nome.ToLower().Contains(name.ToLower()))
                .ToList();

            if (series.Count == 0)
            {
                _logger.LogInformation($"GET /api/series/search - Nenhuma série encontrada para o nome: {name} " + DateTime.Now);
                return NotFound("Nenhuma série encontrada.");
            }
            _logger.LogInformation($"GET /api/series/search - Séries localizadas com sucesso para o nome: {name} " + DateTime.Now);
            return Ok(series);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"GET /api/series/search - Ocorreu um erro ao buscar as séries por nome: {name}");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    /// <summary>
    /// Obtém séries pela empresa.
    /// </summary>
    /// <param name="empresa">Nome da empresa.</param>
    /// <returns>Uma lista de séries que correspondem à empresa.</returns>
    [HttpGet("empresa")]
    public ActionResult<IEnumerable<Serie>> GetSeriesByEmpresa(string empresa)
    {
        _logger.LogInformation($"GET /api/series/empresa - Buscando séries por empresa: {empresa} " + DateTime.Now);
        try
        {
            var series = _context.Series
                .Where(s => s.Empresa.ToLower().Contains(empresa.ToLower()))
                .ToList();

            if (series.Count == 0)
            {
                _logger.LogInformation($"GET /api/series/empresa - Nenhuma série encontrada para a empresa: {empresa} " + DateTime.Now);
                return NotFound("Nenhuma série encontrada.");
            }
            _logger.LogInformation($"GET /api/series/empresa - Séries localizadas com sucesso para a empresa: {empresa} " + DateTime.Now);
            return Ok(series);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"GET /api/series/empresa - Ocorreu um erro ao buscar as séries por empresa: {empresa}");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    /// <summary>
    /// Adiciona uma lista de séries.
    /// </summary>
    /// <param name="series">Lista de séries a serem adicionadas.</param>
    /// <returns>As séries adicionadas.</returns>
    [Authorize]
    [HttpPost]
    public ActionResult<IEnumerable<Serie>> PostSeries(List<Serie> series)
    {
        if (series == null || series.Count == 0)
        {
            _logger.LogInformation("POST /api/series - Nenhuma série para adicionar " + DateTime.Now);
            return BadRequest("Nenhuma série para adicionar.");
        }

        try
        {
            var allSeries = _context.Series.ToList();
            foreach (var serie in series)
            {
                if (!allSeries.Any(s => s.Nome == serie.Nome && s.Empresa == serie.Empresa))
                {
                    _context.Series.Add(serie);
                }
            }

            _context.SaveChanges();
            _logger.LogInformation("POST /api/series - Séries adicionadas com sucesso " + DateTime.Now);
            return CreatedAtAction(nameof(GetAllSeries), new { }, series);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "POST /api/series - Ocorreu um erro ao adicionar séries");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }
}
