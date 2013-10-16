using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharpKatas
{
    public class PersonConverter
    {
        public IEnumerable<Person> ConvertFromJson(string salariedPeople, string hourlyPeople)
        {
            // todo #1: Add a reference to Json.NET (Newtonsoft.Json) using NuGet
            // todo #2: Remove the Ignore attribute and make the tests pass
            // todo #3: Refactor so there is only one call to the Json.NET library and no loops
            return null;
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class SalariedEmployee : Person
    {
        public decimal Salary { get; set; }
    }

    public class HourlyEmployee : Person
    {
        public decimal RatePerHour { get; set; }
    }

    [TestFixture]
    [Ignore]
    public class TestGenerics
    {
        [Test]
        public void ConvertFromJson_EmptyString_ReturnsZeroResults()
        {
            var convert = new PersonConverter();
            var people = convert.ConvertFromJson("", "");
            Assert.AreEqual(0, people.Count());
        }

        [Test]
        public void ConvertFromJson_NullParameters_ReturnsZeroResults()
        {
            var convert = new PersonConverter();
            var people = convert.ConvertFromJson(null, null);
            Assert.AreEqual(0, people.Count());
        }

        [Test]
        public void ConvertFromJson_SalariedEmployee_ReturnsStronglyTypedEmployee()
        {
            var convert = new PersonConverter();
            var people = convert.ConvertFromJson("[ { Name: 'Bob', Salary: 10 } ]", null).ToList();
            Assert.AreEqual(1, people.Count());
            var bob = people[0] as SalariedEmployee;
            Assert.IsNotNull(bob, "Expected a SalariedEmployee, but got some other type (Person?)");
            Assert.AreEqual("Bob", bob.Name);
            Assert.AreEqual(10, bob.Salary);
        }

        [Test]
        public void ConvertFromJson_HourlyEmployee_ReturnsStronglyTypedHourlyEmployee()
        {
            var convert = new PersonConverter();
            var people = convert.ConvertFromJson(null, "[ { Name: 'Bob', RatePerHour: 5.50 } ]").ToList();
            Assert.AreEqual(1, people.Count());
            var bob = people[0] as HourlyEmployee;
            Assert.IsNotNull(bob, "Expected a SalariedEmployee, but got a Person");
            Assert.AreEqual("Bob", bob.Name);
            Assert.AreEqual(5.5M, bob.RatePerHour);
        }

        [Test]
        public void ConvertFromJson_HourlyAndSalariedEmployees_GetMerged()
        {
            var convert = new PersonConverter();
            var people = convert.ConvertFromJson("[ { Name: 'Sam', Salary: 15 } ]", "[ { Name: 'Bob', RatePerHour: 5.50 } ]").ToList();
            Assert.AreEqual(2, people.Count());
            Assert.AreEqual(1, people.Count(i => i is SalariedEmployee));
            Assert.AreEqual(1, people.Count(i => i is HourlyEmployee));
        }
    }
}
