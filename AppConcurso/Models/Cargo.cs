using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models;

[Table("Cargo")]
public class Cargo
{
    public int Id { get; set; }
    public string Nome { get; set; }
}