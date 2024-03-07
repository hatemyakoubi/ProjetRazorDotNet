using System;
using System.Collections.Generic;

namespace Projet1.Models;

public partial class Operation
{
    public int Id { get; set; }

    public int? ContratsId { get; set; }

    public int? UtilisateurId { get; set; }

    public string TypeOperation { get; set; } = null!;

    public DateTime DateOperation { get; set; }

    public virtual Contrat? Contrats { get; set; }

    public virtual User? Utilisateur { get; set; }
}
