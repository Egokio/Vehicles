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
        private readonly VehicleManager vehicleManager = new();

        public MainWindow()
        {
            InitializeComponent();

            VehicleTypeBox.Items.Add("Car");
            VehicleTypeBox.Items.Add("Boat");
            VehicleTypeBox.Items.Add("AmphibiousCar");

            VehiclesGrid.ItemsSource = vehicleManager.Vehicles;

            DriveButton.IsEnabled = false;
            SwimButton.IsEnabled = false;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string make = MakeBox.Text.Trim();
                string model = ModelBox.Text.Trim();

                Vehicle vehicle;

                switch (VehicleTypeBox.SelectedItem?.ToString())
                {
                    case "Car":
                        vehicle = new Car(make, model);
                        break;

                    case "Boat":
                        vehicle = new Boat(make, model);
                        break;

                    case "AmphibiousCar":
                        vehicle = new AmphibiousCar(make, model);
                        break;

                    default:
                        MessageBox.Show("Please select a vehicle type.");
                        return;
                }

                vehicleManager.AddVehicle(vehicle);

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
                if (VehiclesGrid.SelectedItem is not Vehicle vehicle)
                {
                    MessageBox.Show("Please select a vehicle.");
                    return;
                }

                if (!double.TryParse(DistanceBox.Text, out double km))
                {
                    MessageBox.Show("Please enter a valid distance.");
                    return;
                }

                if (vehicle is not IDriveable driveable)
                {
                    MessageBox.Show("This vehicle cannot be driven.");
                    return;
                }

                string message = driveable.Drive(km);

                LogListBox.Items.Add(message);
                VehiclesGrid.Items.Refresh();
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
                if (VehiclesGrid.SelectedItem is not Vehicle vehicle)
                {
                    MessageBox.Show("Please select a vehicle.");
                    return;
                }

                if (!double.TryParse(DistanceBox.Text, out double km))
                {
                    MessageBox.Show("Please enter a valid distance.");
                    return;
                }

                if (vehicle is not ISwimmable swimmable)
                {
                    MessageBox.Show("This vehicle cannot swim.");
                    return;
                }

                string message = swimmable.Swim(km);

                LogListBox.Items.Add(message);
                VehiclesGrid.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void VehiclesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VehiclesGrid.SelectedItem is Vehicle vehicle)
            {
                LogListBox.Items.Add(
                    $"Selected: {vehicle.Make} {vehicle.Model}, " +
                    $"Odometer: {vehicle.Odometer} km.");

                DriveButton.IsEnabled = vehicle is IDriveable;
                SwimButton.IsEnabled = vehicle is ISwimmable;
            }
            else
            {
                DriveButton.IsEnabled = false;
                SwimButton.IsEnabled = false;
            }
        }

        private void DeleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if (VehiclesGrid.SelectedItem is not Vehicle vehicle)
            {
                MessageBox.Show("Please select a vehicle.");
                return;
            }

            vehicleManager.RemoveVehicle(vehicle);

            DriveButton.IsEnabled = false;
            SwimButton.IsEnabled = false;
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