using System;
using System.Collections.Generic;

namespace Projet1.Models;

public partial class Contrat
{
    public int Id { get; set; }

    public int CodeCentre { get; set; }

    public int CodeRecette { get; set; }

    public string TypeContrat { get; set; } = null!;

    public string TypeOperation { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public DateTime DateContrat { get; set; }

    public DateTime DateSauvegarde { get; set; }

    public string Redacteur { get; set; } = null!;

    public int Montant { get; set; }

    public string AdresseEmp { get; set; } = null!;

    public DateTime? DateModification { get; set; }

    public string FileName { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual ICollection<Acteur> Acteurs { get; set; } = new List<Acteur>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
