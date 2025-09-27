namespace LearnAPI2.DTO;

public class LivreDto
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public int? AnneePublication { get; set; }
    public bool Disponible { get; set; }
}