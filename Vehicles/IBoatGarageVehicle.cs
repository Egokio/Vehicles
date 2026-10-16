using System;
using System.Collections.Generic;
using System.Text;


namespace Vehicles.Core
{
    public interface IBoatGarageVehicle : IGarageVehicle
    {
        string SignalAsBoat();
        string FlashLightsAsBoat();
    }
}
