using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Laci", DateTime.Parse("2000-05-06"));
            /*
            Console.WriteLine(person.Age);
            Console.WriteLine("Do you want to serialize?");
            Console.ReadKey();
            person.Serialize();
            Console.WriteLine("Serialization finished");
            Console.WriteLine(person);
            Console.WriteLine(Person.Deserialize("Laci").ToString());
            */

            string fileName = "dataStuff.myData";

            // Use a BinaryFormatter or SoapFormatter.
            IFormatter formatter = new BinaryFormatter();
            //IFormatter formatter = new SoapFormatter();

            SerializeItem(fileName, formatter, person); // Serialize an instance of the class.
            DeserializeItem(fileName, formatter); // Deserialize the instance.
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void SerializeItem(string fileName, IFormatter formatter, Person person)
        {
            // Create an instance of the type and serialize it.

            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, person);
            s.Close();
        }

        public static void DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            Person person = (Person)formatter.Deserialize(s);
            Console.WriteLine(person.Name);
        }
    }
}
