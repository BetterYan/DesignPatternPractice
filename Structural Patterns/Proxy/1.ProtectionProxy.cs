using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ProtectionProxy
{
    //Step1: We have something
    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car being driven");
        }
    }

    //Step2: We want to check the age of the driver
    public interface ICar
    {
        void Drive();
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }

    public class CarProxy : ICar
    {
        private Car car = new Car();
        private Driver driver;

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
            {
                car.Drive();
            }
            else
            {
                Console.WriteLine("Driver is too young.");
            }
        }
    }

    //Step3: we can replace the new Car instead of new CarProxy. If we use IoC, it will be quite easy.
}