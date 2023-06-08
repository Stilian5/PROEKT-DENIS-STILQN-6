using Stilqn_Denis_6ti_Proekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilqn_Denis_6ti_Proekt.Controller
{
    public class AnimalLogic
    {
        private PriutKuchetaDbContext priutContext = new PriutKuchetaDbContext();

        public Animal Get(int id) 
        {
            Animal findAnml = priutContext.Animals.Find(id);
            if (findAnml != null)
            {
                priutContext.Entry(findAnml).Reference(x => x.Breeds).Load();
            }
            return findAnml;
        }

        public List<Animal> GetAll() 
        { 
            return priutContext.Animals.Include("Breeds").ToList();
        }
        public void Create(Animal anml) 
        {
            priutContext.Animals.Add(anml);
            priutContext.SaveChanges();
        }

        public void Updates(int id, Animal anml)
        {
            Animal findAnml = priutContext.Animals.Find(id);
            if (findAnml == null) 
            {
                return;
            }
            findAnml.Name = anml.Name;
            findAnml.Age = anml.Age;
            findAnml.BreedId = anml.BreedId;
            findAnml.Description = anml.Description;
            priutContext.SaveChanges();

        }
        public void Delete(int id)
        {
            Animal findAnml = priutContext.Animals.Find(id);
            priutContext.Animals.Remove(findAnml);
            priutContext.SaveChanges();
        }

    }
}
