using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public class ParkingLot
    {
        private List<Vehicle?> _parkedVehicles;
        private int _totalSlots;

        public ParkingLot(int totalSlots)
        {
            _totalSlots = totalSlots;
            _parkedVehicles = new List<Vehicle?>(_totalSlots);
            for (int i = 0; i < _totalSlots; i++)
            {
                _parkedVehicles.Add(null);
            }
            Console.WriteLine($"Created a parking lot with {_totalSlots} slots");
        }

        public void ParkVehicle(string registrationNumber, string color, string type)
        {
            int emptySlotIndex = _parkedVehicles.FindIndex(vehicle => vehicle == null);
            if (emptySlotIndex != -1)
            {
                var vehicle = new Vehicle
                {
                    RegistrationNumber = registrationNumber,
                    Color = color,
                    Type = type
                };
                _parkedVehicles[emptySlotIndex] = vehicle;
                Console.WriteLine($"Allocated slot number: {emptySlotIndex + 1}");
            }
            else
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
        }

        public void Leave(int slotNumber)
        {
            if (slotNumber > 0 && slotNumber <= _totalSlots)
            {
                _parkedVehicles[slotNumber - 1] = null;
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
            else
            {
                Console.WriteLine("Invalid slot number");
            }
        }

        public void GetStatus()
        {
            Console.WriteLine("Slot\tStatus\tRegistration No.\tType\tColour");
            for (int i = 0; i < _parkedVehicles.Count; i++)
            {
                var vehicle = _parkedVehicles[i];
                string status = (vehicle != null) ? "Occupied" : "Empty";
                string regNumber = vehicle?.RegistrationNumber ?? "-";
                string type = vehicle?.Type ?? "-";
                string color = vehicle?.Color ?? "-";
                Console.WriteLine($"{i + 1}\t{status}\t{regNumber}\t{type}\t{color}");
            }
        }

        public int GetAvailableSlotsCount()
        {
            return _parkedVehicles.Count(vehicle => vehicle == null);
        }

        public int GetOccupiedSlotsCount()
        {
            return _parkedVehicles.Count(vehicle => vehicle != null);
        }

        public int GetVehicleCountByType(string type)
        {
            return _parkedVehicles.Count(vehicle => vehicle?.Type == type);
        }

        public int GetVehicleCountByColor(string color)
        {
            return _parkedVehicles.Count(vehicle => vehicle?.Color == color);
        }

        public List<int> GetSlotNumbersByPlateType(string plateType)
        {
            var slotNumbers = new List<int>();
            for (int i = 0; i < _parkedVehicles.Count; i++)
            {
                if (
                    _parkedVehicles[i] != null
                    && IsPlateTypeMatch(_parkedVehicles[i].RegistrationNumber, plateType)
                )
                {
                    slotNumbers.Add(i + 1);
                }
            }
            return slotNumbers;
        }

        public int GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            for (int i = 0; i < _parkedVehicles.Count; i++)
            {
                if (_parkedVehicles[i]?.RegistrationNumber == registrationNumber)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public List<int> GetSlotNumbersByColor(string color)
        {
            var slotNumbers = new List<int>();
            for (int i = 0; i < _parkedVehicles.Count; i++)
            {
                var vehicle = _parkedVehicles[i];
                if (vehicle != null && vehicle.Color.ToLower() == color.ToLower())
                {
                    slotNumbers.Add(i + 1);
                }
            }
            return slotNumbers;
        }

        private bool IsPlateTypeMatch(string registrationNumber, string plateType)
        {
            if (registrationNumber.Length > 0 && char.IsDigit(registrationNumber[^5]))
            {
                return plateType.ToLower() switch
                {
                    "odd" => int.Parse(registrationNumber[^5].ToString()) % 2 != 0,
                    "even" => int.Parse(registrationNumber[^5].ToString()) % 2 == 0,
                    _ => false,
                };
            }
            else
            {
                return false;
            }
        }

        public List<string> GetRegistrationNumbersForOddPlate()
        {
            List<string> oddPlateNumbers = new List<string>();
            foreach (var vehicle in _parkedVehicles)
            {
                if (vehicle != null)
                {
                    string regNumber = vehicle.RegistrationNumber;
                    if (IsOddPlate(regNumber))
                    {
                        oddPlateNumbers.Add(regNumber);
                    }
                }
            }
            return oddPlateNumbers;
        }

        public List<string> GetRegistrationNumbersForEvenPlate()
        {
            List<string> evenPlateNumbers = new List<string>();
            foreach (var vehicle in _parkedVehicles)
            {
                if (vehicle != null)
                {
                    string regNumber = vehicle.RegistrationNumber;
                    if (IsEvenPlate(regNumber))
                    {
                        evenPlateNumbers.Add(regNumber);
                    }
                }
            }
            return evenPlateNumbers;
        }

        public List<string> GetRegistrationNumbersForColor(string color)
        {
            List<string> regNumbers = new List<string>();
            foreach (var vehicle in _parkedVehicles)
            {
                if (vehicle != null && vehicle.Color.ToLower() == color.ToLower())
                {
                    regNumbers.Add(vehicle.RegistrationNumber);
                }
            }
            return regNumbers;
        }

        private bool IsOddPlate(string regNumber)
        {
            regNumber = regNumber.Replace("-", "");
            regNumber = new string(regNumber.Where(char.IsDigit).ToArray());

            if (regNumber.Length > 0 && int.TryParse(regNumber[^1].ToString(), out int lastDigit))
            {
                return lastDigit % 2 != 0;
            }

            return false;
        }

        private bool IsEvenPlate(string regNumber)
        {
            regNumber = regNumber.Replace("-", "");
            regNumber = new string(regNumber.Where(char.IsDigit).ToArray());

            if (regNumber.Length > 0 && int.TryParse(regNumber[^1].ToString(), out int lastDigit))
            {
                return lastDigit % 2 == 0;
            }

            return false;
        }
    }
}
