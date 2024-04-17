using System;

namespace ParkingSystem
{
    public class CommandList
    {
        public CommandList()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("==========================================================");
            Console.WriteLine("Type Command List");
            Console.WriteLine("'create_parking_lot <total slots>' : to create parking lot");
            Console.WriteLine("'park <registration number> <color> <type>' : to park vehicle");
            Console.WriteLine("'leave <slot number>' : to leave vehicle");
            Console.WriteLine("'status' : to get status of parking lot");
            Console.WriteLine("'type_of_vehicles <type>' : to get type of vehicles");
            Console.WriteLine(
                "'registration_numbers_for_vehicles_with_odd_plate': to get registration numbers for vehicles with odd plate"
            );
            Console.WriteLine(
                "'registration_numbers_for_vehicles_with_even_plate': to get registration numbers for vehicles with even plate"
            );
            Console.WriteLine(
                "'registration_numbers_for_vehicles_with_colour <colour>': to get registration numbers for vehicles with colour"
            );
            Console.WriteLine(
                "'slot_numbers_for_vehicles_with_colour <colour>' : to get slot numbers for vehicles with colour"
            );
            Console.WriteLine(
                "'slot_number_for_registration_number <registration number>' : to get slot number for registration number"
            );
            Console.WriteLine("'exit' : to close the program");

            Console.WriteLine("==========================================================");
            Console.WriteLine("Type Command :");
        }
    }
}
