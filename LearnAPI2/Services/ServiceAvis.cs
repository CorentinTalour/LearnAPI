using LearnAPI2.Data;

namespace LearnAPI2.Services;

public interface IServiceAvis
{
    
}

public class ServiceAvis : IServiceAvis
{
    private readonly Contexte _context;

    public ServiceAvis(Contexte context)
    {
        _context = context;
    }
}