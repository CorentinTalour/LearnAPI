namespace LearnAPI2.Entities;

public class Livre
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public int? AnneePublication { get; set; }
    public bool Disponible { get; set; } = true;
    
    public virtual ICollection<Avis> Avis{ get; set;} = new List<Avis>();
}