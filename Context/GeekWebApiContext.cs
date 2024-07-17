using GeekWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekWebAPI.Context;

public class GeekWebApiContext : DbContext
{
    public GeekWebApiContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Anime> Animes { get; set; }

}