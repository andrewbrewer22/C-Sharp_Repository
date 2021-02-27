using System;
using System.Collections.Generic;

namespace SuperHeroMaker
{
    class Program
    {
        static List<string> People = new List<string>();
        static void Main()
        {
            Person myPerson = new Person("Leroy", "Big Chungus");
            People.Add(myPerson.PrintGreeting());
            Superhero myHero = new Superhero("Batman", "Bruce Wayne", "Money");
            People.Add(myHero.PrintGreeting());
            Villian myVillian = new Villian("Joker", "Batman");
            People.Add(myVillian.PrintGreeting());

            Person p2 = new Person("Harry", "Tubman");
            People.Add(p2.PrintGreeting());
            Superhero h2 = new Superhero("Fire Guuy", "Blaze Hiro", "Ice flames");
            People.Add(h2.PrintGreeting());
            Villian v2 = new Villian("Fire Guuy's Wife", "Blaze");
            People.Add(v2.PrintGreeting());

            for (int i = 0; i < People.Count; i++)
            {
                Console.WriteLine(People[i]);
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Person(string name, string nickname)
        {
            this.Name = name;
            this.Nickname = nickname;
        }
        public override string ToString()
        {
            return Name;
        }
        public virtual string PrintGreeting()
        {
            return $"Hi, my name is {Name}. You can call me {Nickname}.";
        }
    }
    public class Superhero : Person
    {
        public string RealName { get; set; }
        public string SuperPower { get; set; }
        public Superhero(string nickname, string realname,
            string superpower) : base (nickname, null)
        {
            this.RealName = realname;
            this.SuperPower = superpower;
            this.Nickname = nickname;
        }
        public override string PrintGreeting()
        {
            return $"I am {RealName}. When I am {Nickname}, my super power is {SuperPower}.";
        }
    }

    public class Villian : Person
    {
        //Change print greeting format
        //Take in new villian name, and get the superheros nickname
        public string VillianName { get; set; }
        public string HeroName { get; set; }
        public Villian(string villianName, string heroName) : base(villianName, null)
        {
            this.VillianName = villianName;
            this.HeroName = heroName;
        }
        public override string PrintGreeting()
        {
            return $"I am the {VillianName}. Have you seen {HeroName}?";
        }
    }
}
