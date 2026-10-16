using System;
using System.Collections.ObjectModel;

namespace Vehicles.Core
{
    public class BoatGarage
    {
        public ObservableCollection<IBoatGarageVehicle> Boats { get; } = new();

        public string AddBoat(IBoatGarageVehicle boat)
        {
            if (boat == null)
                throw new ArgumentNullException(nameof(boat));

            string message = "";

            foreach (IBoatGarageVehicle otherBoat in Boats)
            {
                message += otherBoat.SignalAsBoat()
                    + Environment.NewLine;
            }

            Boats.Add(boat);

            return message;
        }

        public string RemoveBoat(IBoatGarageVehicle boat)
        {
            if (boat == null)
                throw new ArgumentNullException(nameof(boat));

            if (!Boats.Contains(boat))
                return "Vehicle was not found in the boat garage.";

            Boats.Remove(boat);

            string message = "";

            foreach (IBoatGarageVehicle remainingBoat in Boats)
            {
                message += remainingBoat.FlashLightsAsBoat()
                    + Environment.NewLine;
            }

            return message;
        }
    }
}

