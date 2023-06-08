using Stilqn_Denis_6ti_Proekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilqn_Denis_6ti_Proekt.Controller
{
    public class BreedLogic
    {
        private PriutKuchetaDbContext _kuchetaContext = new PriutKuchetaDbContext();

        public List <Breed> GetAllBreeds()
        {
            return _kuchetaContext.Breeds.ToList();
        }

        public string GetTypeById(int id)
        {
            return _kuchetaContext.Breeds.Find(id).Name;
        }
    }
}
