using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class Car : Vehicle, IDriveable
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
    }
}