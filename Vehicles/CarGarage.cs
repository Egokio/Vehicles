using System;
using System.Collections.ObjectModel;

namespace Vehicles.Core
{
    public class CarGarage
    {
        public ObservableCollection<ICarGarageVehicle> Cars { get; } = new();

        public string AddCar(ICarGarageVehicle car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            string message = "";

            foreach (ICarGarageVehicle otherCar in Cars)
            {
                message += otherCar.SignalAsCar()
                    + Environment.NewLine;
            }

            Cars.Add(car);

            return message;
        }


        public string RemoveCar(ICarGarageVehicle car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            if (!Cars.Contains(car))
                return "Vehicle was not found in the car garage.";

            Cars.Remove(car);

            string message = "";

            foreach (ICarGarageVehicle remainingCar in Cars)
            {
                message += remainingCar.FlashLightsAsCar()
                    + Environment.NewLine;
            }

            return message;
        }

    }
}
