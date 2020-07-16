using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        public delegate void CarDelegate(List<Car> cars);

        public void CarRollCall(List<Car> cars)
        {
            Console.WriteLine("There are " + cars.Count + " cars in total.");
            foreach (var car in cars)
            {
                Console.WriteLine("Car with order number " + car.OrderNumber + " is goin in the direciton " + car.Direction + ".");
            }
        }

        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>();
            List<Thread> Threads = new List<Thread>();
            Program p = new Program();
            Random rnd = new Random();

            CarDelegate cd = new CarDelegate(p.CarRollCall);

            int numberOfCars = rnd.Next(1, 16);

            for (int i = 1; i <= numberOfCars; i++)
            {
                if (rnd.Next(1, 3) == 1)
                {
                    Car c = new Car(i, "North");
                    Cars.Add(c);
                }

                else
                {
                    Car c = new Car(i, "South");
                    Cars.Add(c);
                }

            }
            cd(Cars);

            Console.ReadLine();
        }

        public void BridgeCrossing(object o)
        {
            Car c = (Car)o;
            Thread.Sleep(500);
            Console.WriteLine("Car " + c.OrderNumber + " has safely passed over the bridge in direction " + c.Direction + ".");
        }
    }

    class Car
    {
        internal int OrderNumber;
        internal string Direction;
        internal Thread T;
        Program p = new Program();
        public Car(int order, string dir)
        {
            OrderNumber = order;
            Direction = dir;
            T = new Thread(p.BridgeCrossing);
        }
    }
}
