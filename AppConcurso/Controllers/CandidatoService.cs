using AppConcurso.Models;
using AppConcurso.Contexto;
using Microsoft.EntityFrameworkCore;
using AppConcurso.Contexto;
using AppConcurso.Models;

public class CandidatoService
{
    private readonly ConcursoContext _context;

    public CandidatoService(ConcursoContext context)
    {
        _context = context;
    }

    public async Task<List<Candidato>> ListarAsync()
    {
        return await _context.Candidatos.ToListAsync();
    }

    public async Task AdicionarAsync(Candidato candidato)
    {
        _context.Candidatos.Add(candidato);
        await _context.SaveChangesAsync();
    }

    public async Task<Candidato?> BuscarPorIdAsync(int id)
    {
        return await _context.Candidatos.FindAsync(id);
    }

    public async Task AtualizarAsync(Candidato candidato)
    {
        _context.Candidatos.Update(candidato);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var candidato = await _context.Candidatos.FindAsync(id);
        if (candidato != null)
        {
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
        }
    }
}