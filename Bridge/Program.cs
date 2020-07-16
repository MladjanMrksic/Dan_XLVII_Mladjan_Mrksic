using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> Cars = new Dictionary<int, string>();

            Random rnd = new Random();
            int numberOfCars = rnd.Next(1, 16);

            for (int i = 1; i <= numberOfCars; i++)
            {
                if (rnd.Next(1,3) == 1)
                    Cars.Add(i, "North");
                else
                    Cars.Add(i, "South");
            }
        }
    }
}
