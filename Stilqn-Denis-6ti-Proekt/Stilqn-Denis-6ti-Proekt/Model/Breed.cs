using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilqn_Denis_6ti_Proekt.Model
{
    public class Breed
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        //1:M

            public ICollection<Animal> Animals { get; set; }

    }
}
