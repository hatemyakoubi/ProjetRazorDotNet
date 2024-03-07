using System;
using System.Collections.Generic;

namespace Projet1.Models;

public partial class Acteur
{
    public int Id { get; set; }

    public string Identifiant { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public virtual ICollection<Contrat> Contrats { get; set; } = new List<Contrat>();
}
