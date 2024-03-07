using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projet1.Models;

public partial class GedContext : DbContext
{
    public GedContext()
    {
    }

    public GedContext(DbContextOptions<GedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acteur> Acteurs { get; set; }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Contrat> Contrats { get; set; }

    public virtual DbSet<Gouvernorat> Gouvernorats { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Recette> Recettes { get; set; }

    public virtual DbSet<Structure> Structures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GED; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acteur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__acteur__3213E83F1230A175");

            entity.ToTable("acteur");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Identifiant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("identifiant");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("prenom");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasMany(d => d.Contrats).WithMany(p => p.Acteurs)
                .UsingEntity<Dictionary<string, object>>(
                    "ActeurContrat",
                    r => r.HasOne<Contrat>().WithMany()
                        .HasForeignKey("ContratId")
                        .HasConstraintName("FK_acteur_contrat_contrat_id"),
                    l => l.HasOne<Acteur>().WithMany()
                        .HasForeignKey("ActeurId")
                        .HasConstraintName("FK_acteur_contrat_acteur_id"),
                    j =>
                    {
                        j.HasKey("ActeurId", "ContratId").HasName("PK__acteur_c__8BD775DD2E1E2010");
                        j.ToTable("acteur_contrat");
                        j.IndexerProperty<int>("ActeurId").HasColumnName("acteur_id");
                        j.IndexerProperty<int>("ContratId").HasColumnName("contrat_id");
                    });
        });

        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__actions__3213E83FE23FEEB5");

            entity.ToTable("actions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateAction)
                .HasColumnType("datetime")
                .HasColumnName("date_action");
            entity.Property(e => e.TypeAction)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_action");
            entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Actions)
                .HasForeignKey(d => d.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_actions_utilisateur_id");
        });

        modelBuilder.Entity<Contrat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contrat__3213E83F75C7F9A0");

            entity.ToTable("contrat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdresseEmp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("adresse_emp");
            entity.Property(e => e.CodeCentre).HasColumnName("code_centre");
            entity.Property(e => e.CodeRecette).HasColumnName("code_recette");
            entity.Property(e => e.DateContrat)
                .HasColumnType("date")
                .HasColumnName("date_contrat");
            entity.Property(e => e.DateModification)
                .HasColumnType("date")
                .HasColumnName("date_modification");
            entity.Property(e => e.DateSauvegarde)
                .HasColumnType("date")
                .HasColumnName("date_sauvegarde");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_name");
            entity.Property(e => e.Montant).HasColumnName("montant");
            entity.Property(e => e.Redacteur)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("redacteur");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.TypeContrat)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_contrat");
            entity.Property(e => e.TypeOperation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_operation");

            entity.HasMany(d => d.Users).WithMany(p => p.Contrats)
                .UsingEntity<Dictionary<string, object>>(
                    "ContratUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_contrat_user_user_id"),
                    l => l.HasOne<Contrat>().WithMany()
                        .HasForeignKey("ContratId")
                        .HasConstraintName("FK_contrat_user_contrat_id"),
                    j =>
                    {
                        j.HasKey("ContratId", "UserId").HasName("PK__contrat___1F5EF6313A3BA7E8");
                        j.ToTable("contrat_user");
                        j.IndexerProperty<int>("ContratId").HasColumnName("contrat_id");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<Gouvernorat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gouverno__3213E83F7B7C9582");

            entity.ToTable("gouvernorat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Identifiant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("identifiant");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__operatio__3213E83F899938CC");

            entity.ToTable("operation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContratsId).HasColumnName("contrats_id");
            entity.Property(e => e.DateOperation)
                .HasColumnType("datetime")
                .HasColumnName("date_operation");
            entity.Property(e => e.TypeOperation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_operation");
            entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");

            entity.HasOne(d => d.Contrats).WithMany(p => p.Operations)
                .HasForeignKey(d => d.ContratsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_operation_contrats_id");

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Operations)
                .HasForeignKey(d => d.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_operation_utilisateur_id");
        });

        modelBuilder.Entity<Recette>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recette__3213E83FB10A8428");

            entity.ToTable("recette");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CodeCentreId).HasColumnName("code_centre_id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("libelle");

            entity.HasOne(d => d.CodeCentre).WithMany(p => p.Recettes)
                .HasForeignKey(d => d.CodeCentreId)
                .HasConstraintName("FK_recette_code_centre_id");
        });

        modelBuilder.Entity<Structure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__structur__3213E83FD9FDA80B");

            entity.ToTable("structure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeCentre).HasColumnName("code_centre");
            entity.Property(e => e.CodeStructure)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code_structure");
            entity.Property(e => e.Etat).HasColumnName("etat");
            entity.Property(e => e.Lib)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lib");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F75626AF7");

            entity.ToTable("user");

            entity.HasIndex(e => e.Username, "UQ__user__F3DBC572C799356B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Cin).HasColumnName("cin");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("prenom");
            entity.Property(e => e.Roles).HasColumnName("roles");
            entity.Property(e => e.StructureId).HasColumnName("structure_id");
            entity.Property(e => e.Username)
                .HasMaxLength(180)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Structure).WithMany(p => p.Users)
                .HasForeignKey(d => d.StructureId)
                .HasConstraintName("FK_user_structure_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
