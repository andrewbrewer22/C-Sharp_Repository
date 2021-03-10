using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        //Dictionary set of vehicle data
        static Dictionary<int, string> VehicleData = new Dictionary<int, string>();
        //List<int> 
        static void Main()
        {
            //Add Each vehicle info seperately than add to our VehicleData Dictionary

            Truck myTruck1 = new Truck("1", "193503", "Chevy", "Blazer", "$5,000", "10ft");
            VehicleData.Add(1, myTruck1.GiveReportCard());
            Car myCar1 = new Car("2", "49397", "Ford", "Focus", "$8,000", "Sedan", "4");
            VehicleData.Add(2, myCar1.GiveReportCard());
            Truck myTruck2 = new Truck("2", "124053", "GOGO", "Future", "$100,000", "200ft");
            VehicleData.Add(3, myTruck2.GiveReportCard());
            Car myCar2 = new Car("1", "034632", "Ford", "Fusion", "$90,000" , "Hatchback", "2");
            VehicleData.Add(4, myCar2.GiveReportCard());

            for (int i = 1; i <= VehicleData.Count; i++)
            {
                Console.WriteLine(VehicleData[i]);
            }
        }
    }
    class CarLot
    {
        public string Lot { get; set; }

        public CarLot(string lot)
        {
            this.Lot = lot;
        }
    }
    class Vehicle : CarLot
    {
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }

        public Vehicle (string lot, string license, string make, string model, string price) : base(lot)
        {
            this.LicenseNumber = license;
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }
        public override string ToString()
        {
            return LicenseNumber;
        }
        public virtual string GiveReportCard()
        {
            return $"CarLot: " + Lot + " Lisence Number: " + LicenseNumber + " Make: " +
                Make + " Model: " + Model + " Price: " + Price;
        }
    }
    class Truck : Vehicle
    {
        public string BedSize { get; set; }
        public Truck(string lot, string license, string make, string model, string price, string bed) : base(lot, license, make, model, price)
        {
            this.BedSize = bed;
        }
        public override string GiveReportCard()
        {
            return $"CarLot: " + Lot + " Lisence Number: " + LicenseNumber + " Make: " +
                Make + " Model: " + Model + " Price: " + Price + " Bed Size: " + BedSize;
        }
    }
    class Car : Vehicle
    {
        //type(coupe, hatchback, sedan
        public string Type { get; set; }
        public string NumberOfDoors { get; set; }
        public Car(string lot, string license, string make, string model, string price, string type, string numOfDoors) : base(lot, license, make, model, price)
        {
            this.Type = type;
            this.NumberOfDoors = numOfDoors;
        }
        public override string GiveReportCard()
        {
            return $"CarLot: " + Lot + " Lisence Number: " + LicenseNumber + " Make: " +
                Make + " Model: " + Model + " Price: " + Price + " Type: " + Type + " Number of Doors" +
                ": " + NumberOfDoors;
        }
    }
}
