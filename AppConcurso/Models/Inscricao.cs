using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models;

[Table("Inscricao")]
public class Inscricao
{
    public int Id { get; set; }
    public int CandidatoId { get; set; }
    public int CargoId { get; set; }
    public Candidato Candidato { get; set; }
    public Cargo Cargo { get; set; }
}