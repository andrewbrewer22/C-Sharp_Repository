using System;
using System.Collections.Generic;

/*
1.Create an interface that is called IRentable.
2. Your interface should have 2 methods:
    GetDailyRate()
    GetDescription()
3. Create 3 classes that extend IRentable interface
    Boat
    House
    Car
4. The Car class should internally store a daily rate.
5. The Boat class should internally store an hourly rate
6. The House class should internally store a weekly rate.
7. In your Main Method, you should instantiate some Cars, Houses, and Boats, and add them to a single list.
8. Then loop through the list and print the description, 
type and daily rate out to the console for each element in the list.*/

namespace Inventory
{
    public class Program
    {
        static List<IRentable> RentList = new List<IRentable>();
        static void Main()
        {
            Car car1 = new Car("$200", "2 door Sedan");
            RentList.Add(car1);
            House house1 = new House("$500", "1600 sq ft");
            RentList.Add(house1);
            Boat boat1 = new Boat("$30", "2 stroke");
            RentList.Add(boat1);
            House house2 = new House("$20", "Card board box");
            RentList.Add(house2);
            Car car2 = new Car("$1000", "Vroom xl 500");
            RentList.Add(car2);
            Boat boat2 = new Boat("$220", "Big tubby");
            RentList.Add(boat2);

            for(int i = 0; i < RentList.Count; i++)
            {
                Console.WriteLine(RentList[i].GetRateAndDescription());
            }
        }
    }
    public interface IRentable
    {
        string GetDailyRate();
        string GetDescription();
        string GetRateAndDescription();
    }
    public class Boat : IRentable
    {
        string Rate { get; set; }
        string FinalDes { get; set; }
        //Hourly Rate
        public Boat(string rate, string description)
        {
            this.Rate = rate;
            this.FinalDes = description;
        }
        public string GetDailyRate()
        {
            return Rate;
        }
        public string GetDescription()
        {
            return FinalDes;
        }
        public string GetRateAndDescription()
        {
            return FinalDes + " at a rate of: " + Rate + " an hour";
        }
    }
    public class House : IRentable
    {
        string Rate { get; set; }
        string FinalDes { get; set; }
        //Weekly Rate
        public House(string rate, string description)
        {
            this.Rate = rate;
            this.FinalDes = description;
        }
        public string GetDailyRate()
        {
            return Rate;
        }
        public string GetDescription()
        {
            return FinalDes;
        }
        public string GetRateAndDescription()
        {
            return FinalDes + " at a rate of: " + Rate + " a week";
        }
    }
    public class Car : IRentable
    {
        string Rate { get; set; }
        string FinalDes { get; set; }
        //Daily Rate
        public Car(string rate, string description)
        {
            this.Rate = rate;
            this.FinalDes = description;
        }
        public string GetDailyRate()
        {
            return Rate;
        }
        public string GetDescription()
        {
            return FinalDes;
        }
        public string GetRateAndDescription()
        {
            return FinalDes + " at a rate of: " + Rate + " daily";
        }
    }

}
