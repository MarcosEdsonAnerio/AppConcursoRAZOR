using AppConcurso.Models;
using AppConcurso.Contexto;
using Microsoft.EntityFrameworkCore;
using AppConcurso.Contexto;

public class CargoService
{
    private readonly ConcursoContext _context;

    public CargoService(ConcursoContext context)
    {
        _context = context;
    }

    public async Task<List<AppConcurso.Models.Cargo>> ListarAsync()
    {
        return await _context.Cargos.ToListAsync();
    }

    public async Task AdicionarAsync(AppConcurso.Models.Cargo cargo)
    {
        _context.Cargos.Add(cargo);
        await _context.SaveChangesAsync();
    }

    public async Task<AppConcurso.Models.Cargo?> BuscarPorIdAsync(int id)
    {
        return await _context.Cargos.FindAsync(id);
    }

    public async Task AtualizarAsync(AppConcurso.Models.Cargo cargo)
    {
        _context.Cargos.Update(cargo);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var cargo = await _context.Cargos.FindAsync(id);
        if (cargo != null)
        {
            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
        }
    }
}