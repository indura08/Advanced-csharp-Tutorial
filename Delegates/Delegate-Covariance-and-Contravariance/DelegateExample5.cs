using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates.Delegate_Covariance_and_Contravariance
{
    public class DelegateExample5
    {
        public delegate Car CarFactorydelegate(int id, string name);
        public delegate void LogICECarDetailsDelegate(ICECar car);
        public delegate void LogEVCarDetailsDelegate(EVCar car);
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name=name};
        }

        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name}";
        }
    }

    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
            //The base keyword in C# refers to the parent (base) class of the current class.
            //It allows you to call methods, properties, or constructors from the base class.

        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
            //The base keyword in C# refers to the parent (base) class of the current class.
            //It allows you to call methods, properties, or constructors from the base class.

        }
    }

    //SPECIAL-KEEP-THIS-IN-MIND 

    //meke covarience ek enam method parameter type scn ek code kale nha eka note eke thiynwa blgnna 
}
