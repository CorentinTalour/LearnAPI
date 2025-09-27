namespace LearnAPI2.Entities;

public class Avis
{
    public int Id { get; set; }
    public int LivreId { get; set; }
    public int Note { get; set; } // Note sur 5
    public string? Commentaire { get; set; }
    public DateTime DateCreation { get; set; }
    
    public Livre Livre { get; set; } = null!;
}