using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models;

public class Categoria
{
    public int Id { get; set; }
    [StringLength(80)]
    [Required]
    public string? Nome { get; set; }
    [StringLength(300)]
    [Required]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
}
