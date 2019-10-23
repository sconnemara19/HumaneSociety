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
            Animal Dawg = Query.GetAnimalByID(6);
            Query.RemoveAnimal(Dawg);
        }
    }
}
