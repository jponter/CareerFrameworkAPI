using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerFrameworkAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CareerFrameworkAPI.Pages
{
    public class ListSkillsModel : PageModel
    {
        private readonly AppDbContext db = null;

        public List<Skills> Skills { get; set; }
        public int professionID = 0;

        public ListSkillsModel(AppDbContext db)
        {
            this.db = db;
        }


        public void OnGet(int professionID)
        {
           this.Skills = (from s in db.Skills where s.ProfessionId == professionID orderby s.SkillId select s   ).ToList();
            this.professionID = professionID;
        }
    }
}
