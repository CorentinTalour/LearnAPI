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
        List<LivreDto> livreDto = await _serviceLiv.RecupererTousLesLivres();
        return Ok(livreDto);
    }
}