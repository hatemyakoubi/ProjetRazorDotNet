using System;
using System.Collections.Generic;

namespace Projet1.Models;

public partial class User
{
    public int Id { get; set; }

    public int? StructureId { get; set; }

    public string Username { get; set; } = null!;

    public string Roles { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int Cin { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual Structure? Structure { get; set; }

    public virtual ICollection<Contrat> Contrats { get; set; } = new List<Contrat>();
}
