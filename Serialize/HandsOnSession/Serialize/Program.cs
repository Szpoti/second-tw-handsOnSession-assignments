using System;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Laci", DateTime.Parse("2000-05-06"));
            Console.WriteLine(person.Age);
            Console.WriteLine("Do you want to serialize?");
            Console.ReadKey();
            person.Serialize();
            Console.WriteLine("Serialization finished");
            Console.WriteLine(person);
            Console.WriteLine(Person.Deserialize("Laci").ToString());
        }
    }
}
