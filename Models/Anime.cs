using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeekWebAPI.Models
{
    public class Anime
    {

        public Anime(string nome, string genero, DateTime dataLancamento, int temporadas)
        {
            Nome = nome;
            Genero = genero;
            DataLancamento = dataLancamento;
            Temporadas = temporadas;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Genero { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }
        public int Temporadas { get; set; }


    }
}
