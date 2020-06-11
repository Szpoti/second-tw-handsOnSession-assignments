using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        private DateTime birthdate = DateTime.Now;
        public string Name { get; private set; }
        public Genders gender { get; set; }

        [NonSerialized]
        public int Age;

        public Person(string name, DateTime birthdate)
        {
            this.Name = name;
            this.birthdate = birthdate;
            OnDeserialization(null);
        }

        public enum Genders {Male, Female};

        public override string ToString()
        {
            return "Name: " + Name +
                ", Birthdate: " + birthdate +
                ", Age: " + Age +
                ", Gender: " + gender;
        }

        public void Serialize()
        {
            FileStream fileStream = new FileStream($"{this.Name}.dat",FileMode.Create);
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
            formater.Serialize(fileStream,this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static Person Deserialize(string name)
        {
            FileStream fileStream = new FileStream($"{name}.dat", FileMode.Open);
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                return (Person) formater.Deserialize(fileStream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to Deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public void OnDeserialization(object sender)
        {
            this.Age = DateTime.Now.Year - birthdate.Year;
        }
    }
}
