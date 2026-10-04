# Vehicles

A WPF application for managing different types of vehicles.

## Project structure

The solution consists of two projects:

- **Vehicles.Core** — contains the vehicle classes, interfaces, validation and business logic.
- **Vehicles.WpfApp** — contains the WPF user interface and handles user interaction.

## Vehicle types

The application supports three vehicle types:

- **Car** — can be driven.
- **Boat** — can swim.
- **AmphibiousCar** — can both drive and swim.

All vehicles are stored in one `ObservableCollection<Vehicle>`.

## Main features

- Add a vehicle.
- Select a vehicle from the DataGrid.
- Drive a vehicle.
- Swim with a supported vehicle.
- Display the current odometer.
- Delete a selected vehicle.
- Validate vehicle data and distance.
- Display errors and operation messages.

## OOP concepts

The project demonstrates:

- Abstract classes.
- Inheritance.
- Polymorphism.
- Interfaces.
- `ObservableCollection`.
- Encapsulation.
- Separation of Core logic and WPF presentation.

The `Vehicle` class contains common vehicle functionality. `Car`, `Boat` and `AmphibiousCar` inherit from it and implement the required interfaces.

## Validation

The Core project validates:

- Make cannot be empty.
- Model cannot be empty.
- Distance must be a positive and finite number.
- A vehicle must support the selected action.

The WPF application catches validation errors and displays understandable messages to the user.

## How to run

1. Open the solution in Visual Studio.
2. Make sure `Vehicles.WpfApp` is set as the startup project.
3. Build the solution.
4. Run the application.
5. Add vehicles and use the Drive or Swim actions.

## Technologies

- C#
- .NET
- WPF
- Visual Studio
- `ObservableCollection`
- Object-Oriented Programming