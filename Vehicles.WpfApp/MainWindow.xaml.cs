using System.Text;
using System.Windows;
using Vehicles.Core;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vehicles.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CarGarage carGarage = new();
        private readonly BoatGarage boatGarage = new();
        private readonly VehicleManager vehicleManager = new();


        public MainWindow()
        {
            InitializeComponent();

            VehicleTypeBox.Items.Add("Car");
            VehicleTypeBox.Items.Add("Boat");
            VehicleTypeBox.Items.Add("AmphibiousCar");

            CarsListBox.ItemsSource = carGarage.Cars;
            BoatsListBox.ItemsSource = boatGarage.Boats;

            CarsListBox.DisplayMemberPath = "Model";
            BoatsListBox.DisplayMemberPath = "Model";

            DriveButton.IsEnabled = false;
            SwimButton.IsEnabled = false;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string make = MakeBox.Text.Trim();
                string model = ModelBox.Text.Trim();

                switch (VehicleTypeBox.SelectedItem?.ToString())
                {
                    case "Car":
                        {
                            Car car = new Car(make, model);
                            string message = carGarage.AddCar(car);

                            AddLogMessages(message);

                            LogListBox.Items.Add(
                                $"Added car: {car.Make} {car.Model}.");

                            break;
                        }

                    case "Boat":
                        {
                            Boat boat = new Boat(make, model);
                            string message = boatGarage.AddBoat(boat);

                            AddLogMessages(message);

                            LogListBox.Items.Add(
                                $"Added boat: {boat.Make} {boat.Model}.");

                            break;
                        }


                    case "AmphibiousCar":
                        {
                            AmphibiousCar amphibiousCar =
                                new AmphibiousCar(make, model);

                            AddLogMessages(carGarage.AddCar(amphibiousCar));
                            AddLogMessages(boatGarage.AddBoat(amphibiousCar));

                            LogListBox.Items.Add(
                                $"Added amphibious car to both garages: " +
                                $"{amphibiousCar.Make} {amphibiousCar.Model}.");

                            break;
                        }


                    default:
                        MessageBox.Show("Please select a vehicle type.");
                        return;
                }

                MakeBox.Clear();
                ModelBox.Clear();
                VehicleTypeBox.SelectedIndex = -1;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CarsListBox.SelectedItem is not Vehicle vehicle ||
                    vehicle is not IDriveable driveable)
                {
                    MessageBox.Show("Please select a vehicle that can drive.");
                    return;
                }

                if (!double.TryParse(DistanceBox.Text, out double km))
                {
                    MessageBox.Show("Please enter a valid distance.");
                    return;
                }

                string message = driveable.Drive(km);

                LogListBox.Items.Add(message);
                CarsListBox.Items.Refresh();
                BoatsListBox.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }



        private void SwimButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BoatsListBox.SelectedItem is not Vehicle vehicle ||
                    vehicle is not ISwimmable swimmable)
                {
                    MessageBox.Show("Please select a vehicle that can swim.");
                    return;
                }

                if (!double.TryParse(DistanceBox.Text, out double km))
                {
                    MessageBox.Show("Please enter a valid distance.");
                    return;
                }

                string message = swimmable.Swim(km);

                LogListBox.Items.Add(message);
                CarsListBox.Items.Refresh();
                BoatsListBox.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }



        private void CarsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarsListBox.SelectedItem is ICarGarageVehicle car)
            {
                BoatsListBox.SelectedItem = null;

                if (car is Vehicle vehicle)
                {
                    LogListBox.Items.Add(
                        $"Selected car: {vehicle.Make} {vehicle.Model}, " +
                        $"Odometer: {vehicle.Odometer} km.");
                }

                DriveButton.IsEnabled = true;
                SwimButton.IsEnabled = false;
            }
            else if (BoatsListBox.SelectedItem == null)
            {
                DriveButton.IsEnabled = false;
                SwimButton.IsEnabled = false;
            }
        }




        private void BoatsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BoatsListBox.SelectedItem is IBoatGarageVehicle boat)
            {
                CarsListBox.SelectedItem = null;

                if (boat is Vehicle vehicle)
                {
                    LogListBox.Items.Add(
                        $"Selected boat: {vehicle.Make} {vehicle.Model}, " +
                        $"Odometer: {vehicle.Odometer} km.");
                }

                DriveButton.IsEnabled = false;
                SwimButton.IsEnabled = true;
            }
            else if (CarsListBox.SelectedItem == null)
            {
                DriveButton.IsEnabled = false;
                SwimButton.IsEnabled = false;
            }
        }



        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is not ICarGarageVehicle car)
            {
                MessageBox.Show("Please select a car to remove.");
                return;
            }

            string message = carGarage.RemoveCar(car);
            AddLogMessages(message);

            if (car is Vehicle vehicle)
            {
                LogListBox.Items.Add(
                    $"Removed from Car Garage: {vehicle.Make} {vehicle.Model}.");
            }

            DriveButton.IsEnabled = false;
            SwimButton.IsEnabled = false;
        }




        private void DeleteBoatButton_Click(object sender, RoutedEventArgs e)
        {
            if (BoatsListBox.SelectedItem is not IBoatGarageVehicle boat)
            {
                MessageBox.Show("Please select a boat to remove.");
                return;
            }

            string message = boatGarage.RemoveBoat(boat);
            AddLogMessages(message);

            if (boat is Vehicle vehicle)
            {
                LogListBox.Items.Add(
                    $"Removed from Boat Garage: {vehicle.Make} {vehicle.Model}.");
            }

            DriveButton.IsEnabled = false;
            SwimButton.IsEnabled = false;
        }




        private void AddLogMessages(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            foreach (string line in message.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                LogListBox.Items.Add(line);
            }
        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MakeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LogListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}