using System;

namespace PoCo
{
    #region Main
    class Program
    {
        static void Main()
        {
            DriverLicence Andrew = new DriverLicence(
                "Andrew", "Brewer", "Male", "10101010101");
            Console.WriteLine(Andrew.GetFullName());

            Book HarryPooter = new Book("Harry Pooter",
                "HK Brown", "25", "Whats an SKU?", "Back woods Barber",
                "50 bucks");
            Console.WriteLine(HarryPooter.CreateBook());

            Airplane JumboStriker = new Airplane("Boing",
                "9021", "V16", "13.5", "26");
            Console.WriteLine(JumboStriker.CreateAirplane());
        }
    }
    #endregion

    #region Drivers Licence
    /* 1: Drivers Licence
    FirstName
    LastName
    Gender
    LicenseNumber*/
    class DriverLicence
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Gender { get; set; }
        public string licenceNumber { get; set; }

        public DriverLicence(string first, string last, string
            gender, string licenceNum)
        {
            firstName = first;
            lastName = last;
            Gender = gender;
            licenceNumber = licenceNum;
        }

        public String GetFullName()
        {
            string FullName = firstName + " " + lastName;
            return FullName;
        }
    }
    #endregion

    #region Book
    /* 2: Book
    Title
    Authors; this should allow for multiple authors
    Pages; this should hold the number of pages
    SKU
    Publisher
    Price*/
    class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Pages { get; set; }
        public string SKU { get; set; }
        public string Publisher { get; set; }
        public string Price { get; set; }

        public Book(string title, string authors,
            string pages, string sku, string
            publisher, string price)
        {
            Title = title;
            Authors = authors;
            Pages = pages;
            SKU = sku;
            Publisher = publisher;
            Price = price;
        }

        public String CreateBook()
        {
            string book = Title + " by " + Authors;
            return book;
        }

    }
    #endregion

    #region Airplane
    /* 3: Airplane
    Manufacturer
    Model
    Variant
    Capacity; this should hold the seating capacity
    Engines; this should hold the number of engines*/
    class Airplane
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Capacity { get; set; }
        public string Engines { get; set; }

        public Airplane(string manu, string model, 
            string variant, string capacity,
            string engines)
        {
            Manufacturer = manu;
            Model = model;
            Variant = variant;
            Capacity = capacity;
            Engines = engines;
        }

        public String CreateAirplane()
        {
            string newPlane = Manufacturer + " " +
                Model + " " + Variant + " with a capacity of " + Capacity +
                " with " + Engines + " Engines!" ;
            return newPlane;
        }
    }
    #endregion
}
