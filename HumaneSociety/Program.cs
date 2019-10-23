using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            //PointOfEntry.Run();
            //Animal animal = new Animal()
            //{
            //    Name = "Dawg",
            //    Weight = 28,
            //    Age = 1,
            //    Demeanor = "Friendly",
            //    KidFriendly = true,
            //    PetFriendly = true,
            //    Gender = "Female",
            //    AdoptionStatus = "Available",
            //    CategoryId = 1,
            //    DietPlanId = 2,
            //    EmployeeId = 2
            //};
            Animal patrice = Query.GetAnimalByID(5);
            Query.RemoveAnimal(patrice);
        }
    }
}
