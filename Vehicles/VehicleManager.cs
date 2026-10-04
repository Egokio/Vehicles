using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;

namespace Vehicles.Core
{
    public class VehicleManager
    {
        public ObservableCollection<Vehicle> Vehicles { get; } = new();

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            Vehicles.Remove(vehicle);
        }
    }
}
