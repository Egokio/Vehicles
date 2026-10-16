# Vehicles – Two Garages

## Description

This project is a C# application that demonstrates object-oriented programming through different types of vehicles and two separate garages: Car Garage and Boat Garage.

Vehicles can be added to, selected in, and removed from their respective garages. The application also demonstrates how vehicles interact with each other through signals and flashing lights.

## Features

- Add and remove cars in Car Garage.
- Add and remove boats in Boat Garage.
- Select vehicles and perform driving or swimming actions.
- Existing vehicles signal when a new vehicle is added to the same garage.
- Remaining vehicles flash their lights when a vehicle is removed.
- Support for amphibious cars in both garages.
- Independent removal of an amphibious car from either garage.
- Shared odometer for an amphibious car, since the same object is used in both garages.
- Activity Log displaying vehicle actions and garage interactions.
- Input validation for vehicle information and travel distance.

## Project Structure

- **Vehicles.Core** – Contains the vehicle classes, interfaces, garage logic, and vehicle-related behavior.
- **WPF application** – Provides the graphical user interface for managing garages and interacting with vehicles.

## Object-Oriented Programming

The project demonstrates:

- **Inheritance** – Different vehicle types share common functionality through a base class.
- **Interfaces** – Interfaces define vehicle capabilities and garage-specific behavior.
- **Polymorphism** – Different vehicle types respond differently to signals and light-flashing actions.
- **Encapsulation** – Vehicle state is managed through the class structure.
- **Collections** – `ObservableCollection` stores vehicles and updates the interface when the collection changes.
- **Type checking** – The application checks vehicle capabilities before performing actions.

## Technologies

- C#
- .NET
- WPF (Windows Presentation Foundation)
- Visual Studio

## How to Run

1. Clone or download this repository.
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the WPF application.
5. Add vehicles to the garages and test the available actions.

## Testing

The application was tested for:

- Adding, selecting, and removing cars and boats.
- Signaling when a vehicle is added.
- Flashing lights when a vehicle is removed.
- Adding an amphibious car to both garages.
- Removing an amphibious car independently from each garage.
- Sharing the odometer between both garage entries.
- Driving, swimming, and displaying activity messages.

All tested features worked as expected.
