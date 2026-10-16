using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class Boat : Vehicle, ISwimmable, IBoatGarageVehicle
    {
        public Boat(string make, string model)
            : base(make, model)
        {
        }

        public override string Move(double km)
        {
            return Swim(km);
        }

        public string Swim(double km)
        {
            return base.Move(km);
        }
        public string Signal()
        {
            return $"{Make} {Model} sounds its horn! Honk honk!";
        }

        public string FlashLights()
        {
            return $"{Make} {Model} flashes its navigation lights!";
        }

        public string SignalAsBoat()
        {
            return Signal();
        }

        public string FlashLightsAsBoat()
        {
            return FlashLights();
        }

    }
}