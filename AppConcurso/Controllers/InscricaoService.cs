using AppConcurso.Models;
using AppConcurso.Contexto;
using Microsoft.EntityFrameworkCore;
using AppConcurso.Contexto;
using AppConcurso.Models;

public class InscricaoService
{
    private readonly ConcursoContext _context;

    public InscricaoService(ConcursoContext context)
    {
        _context = context;
    }

    public async Task<List<AppConcurso.Models.Inscricao>> ListarAsync()
    {
        return await _context.Inscricoes
            .Include(i => i.Candidato)
            .Include(i => i.Cargo)
            .ToListAsync();
    }

    public async Task AdicionarAsync(AppConcurso.Models.Inscricao inscricao)
    {
        _context.Inscricoes.Add(inscricao);
        await _context.SaveChangesAsync();
    }

    public async Task<AppConcurso.Models.Inscricao?> BuscarPorIdAsync(int id)
    {
        return await _context.Inscricoes
            .Include(i => i.Candidato)
            .Include(i => i.Cargo)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task RemoverAsync(int id)
    {
        var inscricao = await _context.Inscricoes.FindAsync(id);
        if (inscricao != null)
        {
            _context.Inscricoes.Remove(inscricao);
            await _context.SaveChangesAsync();
        }
    }
    public async Task AdicionarCandidatoComInscricaoAsync(Candidato candidato, int cargoId)
    {
        _context.Candidatos.Add(candidato);
        await _context.SaveChangesAsync();

        var inscricao = new Inscricao
        {
            CandidatoId = candidato.Id,
            CargoId = cargoId
        };
        _context.Inscricoes.Add(inscricao);
        await _context.SaveChangesAsync();
    }
}