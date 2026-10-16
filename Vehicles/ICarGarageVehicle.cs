using System;
using System.Collections.Generic;
using System.Text;


namespace Vehicles.Core
{
    public interface ICarGarageVehicle : IGarageVehicle
    {
        string SignalAsCar();
        string FlashLightsAsCar();
    }
}
