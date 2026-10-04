namespace Vehicles.Core
{
    public abstract class Vehicle
    {
        public string Make { get; }
        public string Model { get; }
        public double Odometer { get; private set; }

        protected Vehicle(string make, string model)
        {
            if (string.IsNullOrWhiteSpace(make))
                throw new ArgumentException("Make cannot be empty.");

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be empty.");

            Make = make;
            Model = model;
            Odometer = 0;
        }

        public virtual string Move(double km)
        {
            if (!double.IsFinite(km) || km <= 0)
                throw new ArgumentException(
                    "Distance must be a positive, finite number.");

            Odometer += km;

            return $"{Make} {Model} moved {km} km. " +
                   $"New odometer: {Odometer} km.";
        }
    }
}
