using LearnAPI2.Data;
using LearnAPI2.DTO;
using LearnAPI2.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI2.Services;

public interface IServiceLivres
{
    Task<List<LivreDto>> RecupererTousLesLivres();
    Task<LivreDto> RecupererLivreDepuisId(int id);

    Task<LivrePostDto> EnvoyerLivre(LivrePostDto livre);
    Task<int> ModifierUnLivre(int id, LivrePostDto livre);
    Task SupprimerUnLivre(int id);
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

    public async Task<LivreDto> RecupererLivreDepuisId(int id)
    {
        Livre? livre = await _context.Livres.FindAsync(id);

        if (livre != null)
        {
            return new LivreDto
            {
                Id = livre.Id,
                Titre = livre.Titre,
                Auteur = livre.Auteur,
                AnneePublication = livre.AnneePublication,
                Disponible = livre.Disponible
            };
        }
        else
        {
            throw new Exception("Livre non trouvé");
        }
    }

    public async Task<LivrePostDto> EnvoyerLivre(LivrePostDto livre)
    {
        Livre newLivre = new Livre
        {
            Titre = livre.Titre,
            Auteur = livre.Auteur,
            AnneePublication = livre.AnneePublication,
            Disponible = livre.Disponible
        };

        _context.Livres.Add(newLivre);
        await _context.SaveChangesAsync();
        return livre;
    }

    public async Task<int> ModifierUnLivre(int id, LivrePostDto livre)
    {
        Livre newLivre = new Livre
        {
            Id = id,
            Titre = livre.Titre,
            Auteur = livre.Auteur,
            AnneePublication = livre.AnneePublication,
            Disponible = livre.Disponible
        };

        _context.Update(newLivre);

        return await _context.SaveChangesAsync();
    }

    public async Task SupprimerUnLivre(int id)
    {
        Livre livre = new Livre
        {
            Id = id
        };

        _context.Remove(livre);
        await _context.SaveChangesAsync();
    }
}