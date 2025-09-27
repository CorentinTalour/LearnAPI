using LearnAPI2.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI2.Data;

public class Contexte : DbContext
{
    public Contexte(DbContextOptions<Contexte> options)
        : base(options)
    {
    }

    public virtual DbSet<Livre> Livres { get; set; }
    public virtual DbSet<Avis> Avis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livre>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Titre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Auteur).HasMaxLength(100).IsRequired();
            entity.Property(e => e.AnneePublication).IsRequired(false);
            entity.Property(e => e.Disponible).HasDefaultValue(true);

            // Relation Livre - Avis (un livre a plusieurs avis)
            entity.HasMany(e => e.Avis)
                .WithOne(a => a.Livre)
                .HasForeignKey(a => a.LivreId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Avis>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Note).IsRequired();
            entity.Property(e => e.Commentaire).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("timezone('utc', now())")
                .ValueGeneratedOnAdd();
        });
    }
}