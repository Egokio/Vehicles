using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class Car : Vehicle, IDriveable, ICarGarageVehicle
    {
        public Car(string make, string model)
            : base(make, model)
        {
        }

        public override string Move(double km)
        {
            return Drive(km);
        }

        public string Drive(double km)
        {
            return base.Move(km);
        }
        public string Signal()
        {
            return $"{Make} {Model} honks the horn! Beep beep!";
        }

        public string FlashLights()
        {
            return $"{Make} {Model} flashes its headlights!";
        }

        public string SignalAsCar()
        {
            return Signal();
        }

        public string FlashLightsAsCar()
        {
            return FlashLights();
        }


    }
}