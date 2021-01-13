using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerFrameworkAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CareerFrameworkAPI.Pages
{

#if AUTHON

    [Authorize(Policy = "CFAdmin")]

#endif

    public class ListProfModel : PageModel
    {
        private readonly AppDbContext db = null;
        public List<Professions> Professions { get; set; }
        public ListProfModel(AppDbContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            //_ = User;

            this.Professions = (from p in db.Professions orderby p.ProfessionId select p).ToList();

        }
    }
}
