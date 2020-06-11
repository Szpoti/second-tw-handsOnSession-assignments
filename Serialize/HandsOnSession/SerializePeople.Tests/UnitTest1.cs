using NUnit.Framework;
using SerializePeople;
using System;
using System.IO;

namespace SerializePeople.Tests
{
    public class Tests
    {
        Person Person;

        [SetUp]
        public void Setup()
        {
            Person = new Person("Laci", DateTime.Parse("2000-04-12"));
        }

        [Test]
        public void NameProperty_ShouldReturn_Laci()
        {
            var expected = "Laci";
            Assert.AreEqual(expected, Person.Name);
        }

        [Test]
        public void Serialize_OutputToLaciDotDatFile()
        {
            Person.Serialize();
            Assert.IsTrue(File.Exists("Laci.dat"));
        }

        [Test]
        public void AgeProperty_GivenAPersonBornIn2000_ShouldReturn20()
        {
            var expected = 20;
            Assert.AreEqual(expected, Person.Age);
        }

        [Test]
        public void Deserialize_GivenAPerson_ShouldReturnAllCorrectProperties()
        {
            Person newPerson = Person.Deserialize("Laci");
            Assert.AreEqual("Laci", newPerson.Name);
        }
    }
}