using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class AmphibiousCar : Vehicle, IDriveable, ISwimmable, ICarGarageVehicle, IBoatGarageVehicle
    {
        public AmphibiousCar(string make, string model)
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

        public string Swim(double km)
        {
            return base.Move(km);
        }


        public string Signal()
        {
            return $"{Make} {Model} signals!";
        }

        public string FlashLights()
        {
            return $"{Make} {Model} flashes its lights!";
        }

        public string SignalAsCar()
        {
            return $"{Make} {Model} honks the horn! Beep beep!";
        }

        public string FlashLightsAsCar()
        {
            return $"{Make} {Model} flashes its headlights!";
        }

        public string SignalAsBoat()
        {
            return $"{Make} {Model} sounds its horn! Honk honk!";
        }

        public string FlashLightsAsBoat()
        {
            return $"{Make} {Model} flashes its navigation lights!";
        }

    }
}