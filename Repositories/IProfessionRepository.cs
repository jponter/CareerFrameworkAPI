using CareerFrameworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerFrameworkAPI.Repositories
{
    public interface IProfessionRepository
    {
        List<Professions> SelectAll();
        Professions SelectByID(int professionId);

        void Insert(Professions profession);
        void Update(Professions profession);
        void Delete(int professionId);

    }
}
