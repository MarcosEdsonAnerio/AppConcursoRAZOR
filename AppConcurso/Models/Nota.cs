using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models;

[Table("Nota")]
public class Nota
{
    public int Id { get; set; }
    public int InscricaoId { get; set; }
    public double ConhecimentosEspecificos { get; set; }
    public double ConhecimentosGerais { get; set; }
    public Inscricao Inscricao { get; set; }
}