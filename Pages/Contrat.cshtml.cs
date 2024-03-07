using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet1.Models;
using System.Linq;

namespace Projet1.Pages
{
    public class ContratModel : PageModel
    {
        private readonly GedContext? gedContext;

        public ContratModel(GedContext? gedContext)
        {
            this.gedContext = gedContext;
        }

        public List<Contrat> Contrat { get; set; }
        
        public void OnGet(string search)
        {
            IQueryable<Contrat> Querry = gedContext.Contrats
                .Include(c=>c.Operations)
                .Include(c=>c.Acteurs)   
                .Include(c => c.Users);
            if (search != null)
            {
                Querry = Querry.Where(c => (c.Reference == search) 
                                        ||(c.TypeContrat == search)
                                        || (c.TypeContrat == search)
                                        || (c.Redacteur == search)                
                                        );

            }
            Contrat = Querry.ToList();

        }
    }
}
