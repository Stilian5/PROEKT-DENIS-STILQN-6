using Stilqn_Denis_6ti_Proekt.Controller;
using Stilqn_Denis_6ti_Proekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilqn_Denis_6ti_Proekt.View
{
    public class Display
    {
        private int closeOperationId = 6;
        public AnimalLogic anmlLogic = new AnimalLogic();
        public Display()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        public void Input()
        {
            int operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            anmlLogic.Delete(id);
            Console.WriteLine("Done.");
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Animal anml = anmlLogic.Get(id);
            if (anml != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + anml.Id);
                Console.WriteLine("Name: " + anml.Name);
                Console.WriteLine("Age: " + anml.Age);
                Console.WriteLine("BreedID: " + anml.BreedId);
                Console.WriteLine("Description: " + anml.Description);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Animal anml = anmlLogic.Get(id);

            


            if (anml != null)
            {
                Console.WriteLine("Enter name: ");
                anml.Name = Console.ReadLine();
                Console.WriteLine("Enter Age: ");
                anml.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter breed: ");
                anml.BreedId = int.Parse(Console.ReadLine());
                anmlLogic.Updates(id, anml);
            }
            else
            {
                Console.WriteLine("Breed not found!");
            }
        }
        private void Add()
        {
            Animal anml = new Animal();
            Console.WriteLine("Enter name: ");
            anml.Name = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            anml.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter breedID: ");
            anml.BreedId = int.Parse(Console.ReadLine());
            anmlLogic.Create(anml);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "ANIMALS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var anml = anmlLogic.GetAll();
            foreach (var item in anml)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Age, item.BreedId);
            }
        }
    }
}
