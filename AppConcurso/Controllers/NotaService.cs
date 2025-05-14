using AppConcurso.Models;
using AppConcurso.Contexto;
using Microsoft.EntityFrameworkCore;
using AppConcurso.Contexto;
using AppConcurso.Models;

public class NotaService
{
    private readonly ConcursoContext _context;

    public NotaService(ConcursoContext context)
    {
        _context = context;
    }

    public async Task<List<Nota>> ListarAsync()
    {
        return await _context.Notas
            .Include(n => n.Inscricao)
            .ThenInclude(i => i.Candidato)
            .Include(n => n.Inscricao)
            .ThenInclude(i => i.Cargo)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Nota nota)
    {
        _context.Notas.Add(nota);
        await _context.SaveChangesAsync();
    }

    public async Task<Nota?> BuscarPorIdAsync(int id)
    {
        return await _context.Notas
            .Include(n => n.Inscricao)
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task AtualizarAsync(Nota nota)
    {
        _context.Notas.Update(nota);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var nota = await _context.Notas.FindAsync(id);
        if (nota != null)
        {
            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();
        }
    }
}