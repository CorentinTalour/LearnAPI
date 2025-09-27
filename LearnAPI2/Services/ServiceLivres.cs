using LearnAPI2.Data;
using LearnAPI2.DTO;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI2.Services;

public interface IServiceLivres
{
    Task<List<LivreDto>> RecupererTousLesLivres();
}

public class ServiceLivres : IServiceLivres
{
    private readonly Contexte _context;

    public ServiceLivres(Contexte context)
    {
        _context = context;
    }
    
    public async Task<List<LivreDto>> RecupererTousLesLivres()
    {
        return await _context.Livres
            .AsNoTracking()
            .Select(l => new LivreDto
            {
                Id = l.Id,
                Titre = l.Titre,
                Auteur = l.Auteur,
                AnneePublication = l.AnneePublication,
                Disponible = l.Disponible
            })
            .ToListAsync();
    }
}