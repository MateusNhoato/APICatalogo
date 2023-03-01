using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

public class Produto
{
    public delegate void MeuDelegate();
    public int Id { get; set; }
    [StringLength(80)]
    [Required]
    public string? Nome { get; set; }
    [StringLength(250)]
    [Required]
    public string? Descricao { get; set; }
    [Column(TypeName ="decimal(10,2)")]
    [Required]
    public decimal Preco { get; set; }
    [StringLength(300)]
    [Required]
    public string? ImagemUrl { get; set; }
    public int Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }
}
