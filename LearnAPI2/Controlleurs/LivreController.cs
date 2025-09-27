using LearnAPI2.Data;
using LearnAPI2.DTO;
using LearnAPI2.Entities;
using LearnAPI2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI2.Controlleurs;

[Route("api/[controller]")]
[ApiController]
public class LivreController : ControllerBase
{
    private readonly IServiceLivres _serviceLiv;

    public LivreController(IServiceLivres service)
    {
        _serviceLiv = service;
    }

    // GET -> api/Livre
    // Récupere tout les livres
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivreDto>>> GetLivres()
    {
        try
        {
            List<LivreDto> livreDto = await _serviceLiv.RecupererTousLesLivres();
            return Ok(livreDto);
        }
        catch (Exception e)
        {
            return this.CustomResponseForError(e);
        }
    }

    // GET -> api/Livre/{id}
    // Récupere un livre par son id
    [HttpGet("{id}")]
    public async Task<ActionResult<LivreDto>> GetLivre(int id)
    {
        try
        {
            LivreDto livreDto = await _serviceLiv.RecupererLivreDepuisId(id);
            return Ok(livreDto);
        }
        catch (Exception e)
        {
            return this.CustomResponseForError(e);
        }
    }

    // POST -> api/Livre
    // Ajoute un livre
    [HttpPost]
    public async Task<ActionResult<Livre>> PostLivre(LivrePostDto livre)
    {
        try
        {
            LivrePostDto res = await _serviceLiv.EnvoyerLivre(livre);

            return Ok(res);
        }
        catch (Exception e)
        {
            return this.CustomResponseForError(e);
        }
    }

    // PUT -> api/Livre/{id}
    // Modifie un livre
    [HttpPut("{id}")]
    public async Task<ActionResult<LivreDto>> ModifierLivre(int id, LivrePostDto livre)
    {
        try
        {
            await _serviceLiv.ModifierUnLivre(id, livre);
            return NoContent();
        }
        catch (Exception e)
        {
            return this.CustomResponseForError(e);
        }
    }
    
    // DELETE -> api/Livre/{id}
    // Supprime un livre
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLivre(int id)
    {
        try
        {
            await _serviceLiv.SupprimerUnLivre(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return this.CustomResponseForError(e);
        }
    }
}