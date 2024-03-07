using System;
using System.Collections.Generic;

namespace Projet1.Models;

public partial class Structure
{
    public int Id { get; set; }

    public string CodeStructure { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Lib { get; set; } = null!;

    public int Etat { get; set; }

    public int CodeCentre { get; set; }

    public virtual ICollection<Recette> Recettes { get; set; } = new List<Recette>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
