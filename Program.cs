using System;
using System.Collections.Generic;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandList commandList = new CommandList();
            ParkingLot parkingLot = null;

            while (true)
            {
                Console.Write("$ ");
                string? input = Console.ReadLine()?.Trim();
                if (input == null)
                    continue;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                string[] commandParts = input.Split(' ');
                string command = commandParts[0].ToLower();
                switch (command)
                {
                    case "create_parking_lot":
                        int totalSlots = int.Parse(commandParts[1]);
                        parkingLot = new ParkingLot(totalSlots);
                        break;

                    case "park":
                        if (parkingLot != null)
                        {
                            string regNumber = commandParts[1];
                            string color = commandParts[2];
                            string type = commandParts[3];
                            parkingLot.ParkVehicle(regNumber, color, type);
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;

                    case "leave":
                        if (parkingLot != null)
                        {
                            int slotNumber = int.Parse(commandParts[1]);
                            parkingLot.Leave(slotNumber);
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;

                    case "status":
                        if (parkingLot != null)
                        {
                            parkingLot.GetStatus();
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;

                    case "type_of_vehicles":
                        if (parkingLot != null)
                        {
                            string type = commandParts[1];
                            int count = parkingLot.GetVehicleCountByType(type);
                            Console.WriteLine(count);
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_odd_plate":
                    case "registration_numbers_for_vehicles_with_even_plate":
                        string plateType =
                            (command == "registration_numbers_for_vehicles_with_odd_plate")
                                ? "odd"
                                : "even";
                        if (parkingLot != null)
                        {
                            List<string> regNumbers = new List<string>();
                            if (plateType == "odd")
                            {
                                regNumbers = parkingLot.GetRegistrationNumbersForOddPlate();
                            }
                            else
                            {
                                regNumbers = parkingLot.GetRegistrationNumbersForEvenPlate();
                            }
                            Console.WriteLine(string.Join(", ", regNumbers));
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                        string[] tokens = input.Split(' ');
                        if (tokens.Length == 2)
                        {
                            string color = tokens[1];
                            List<string> regNumbers = parkingLot.GetRegistrationNumbersForColor(
                                color
                            );
                            Console.WriteLine(string.Join(", ", regNumbers));
                        }
                        else
                        {
                            Console.WriteLine("Invalid command");
                        }
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        if (parkingLot != null)
                        {
                            string color = commandParts[1];
                            var slotNumbers = parkingLot.GetSlotNumbersByColor(color);
                            Console.WriteLine(string.Join(", ", slotNumbers));
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;

                    case "slot_number_for_registration_number":
                        if (parkingLot != null)
                        {
                            string regNumber = commandParts[1];
                            int slotNumber = parkingLot.GetSlotNumberByRegistrationNumber(
                                regNumber
                            );
                            if (slotNumber != -1)
                            {
                                Console.WriteLine(slotNumber);
                            }
                            else
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Parking lot is not created yet");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
