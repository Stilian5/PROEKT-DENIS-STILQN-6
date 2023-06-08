using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilqn_Denis_6ti_Proekt.Model
{
    public class PriutKuchetaDbContext:DbContext
    {
        public PriutKuchetaDbContext() : base("PriutKuchetaDbContext")
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
