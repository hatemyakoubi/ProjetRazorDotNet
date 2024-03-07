using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet1.Models;

namespace Projet1.Pages
{
    public class StructureModel : PageModel
    {
        private readonly GedContext? gedContext;

        public StructureModel(GedContext? gedContext)
        {
            this.gedContext = gedContext;
        }

        public List<Structure> Structures { get; set; }
        public void OnGet()
        {
            IQueryable<Structure> Querry = gedContext.Structures
            .Include(c => c.Users)
            .Include(c => c.Recettes);
            Structures = Querry.ToList();

        }
    }
}
