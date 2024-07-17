using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeekWebAPI.Models
{
    public class Livro
    {
        public Livro(string nome, string genero, string editora, DateTime dataLancamento, int paginas)
        {
            Nome = nome;
            Genero = genero;
            Editora = editora;
            DataLancamento = dataLancamento;
            Paginas = paginas;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Editora { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }
        public int Paginas { get; set; }
    }
}
