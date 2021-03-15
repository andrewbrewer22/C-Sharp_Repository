using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BookLibrarySQL
{
    class Program
    {
        public static bool UserInput = true;

        static void Main()
        {
            do
            {
                CreateNewBook();

            }
            while (UserInput);
        }

        public static void CreateNewBook()
        {
            BookContext context = new BookContext();
            context.Database.EnsureCreated();

            string userInput = "";
            string[] bookArray = new string[] { "", "" };

            //BOOK TITLE
            Console.WriteLine("Type \'Done\' to finish at anytime");
            Console.WriteLine("Input Book Title");
            userInput = Console.ReadLine();
            if (userInput == "Done")
            {
                UserInput = false;
            }
            else
            {
                bookArray[0] = userInput;
            }

            //AUTHOR NAME
            if (UserInput)
            {
                Console.WriteLine("Input Author Name");
                userInput = Console.ReadLine();
            }
            if (userInput == "Done")
            {
                UserInput = false;
            }
            else
            {
                bookArray[1] = userInput;
            }

            if(!UserInput)
            {
                foreach(Books b in context.books)
                {
                    Console.WriteLine(b.ID + " Title: " + b.Title + " BY: " + b.Author);
                }
            }
            else
            {
                Books newBook = new Books(bookArray[0], bookArray[1]);
                context.books.Add(newBook);
                context.SaveChanges();
            }
        }
    }

    class Books
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Books(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }

    class BookContext : DbContext
    {
        public DbSet<Books> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "LibraryAssignment.db");

            // to check what the path of the file is, uncomment the file below
            Console.WriteLine("using database file :" + DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}