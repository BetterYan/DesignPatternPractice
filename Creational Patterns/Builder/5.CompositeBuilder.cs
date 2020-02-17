using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Person
    {
        //address
        public string StreetAddress, Postcode, City;

        //employ info
        public string CompanyName, Position;

        public int AnnualIncomde;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Address: {StreetAddress}-{Postcode}-{City}");
            sb.Append(" ### ");
            sb.Append($"Employ info: {CompanyName}-{Position}-{AnnualIncomde}");
            return sb.ToString();
        }
    }

    public class PersonBuilder
    {
        protected Person person; //this is a reference

        public PersonBuilder() => person = new Person();

        protected PersonBuilder(Person person) => this.person = person;

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pd)
        {
            return pd.person;
        }

        public override string ToString()
        {
            return this.person.ToString();
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person) : base(person)
        {
        }

        public PersonJobBuilder At(string name)
        {
            this.person.CompanyName = name;
            return this;
        }

        public PersonJobBuilder AsA(string name)
        {
            this.person.Position = name;
            return this;
        }

        public PersonJobBuilder Earning(int value)
        {
            this.person.AnnualIncomde = value;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person) : base(person)
        {
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public static class TestWithCompositeBuilder
    {
        //There is one fairly obvious downside to this approach: it is not extensible;
        //It is bad idea for a base class to be aware of its own subclasses.
        //That is: the person expose the child builder with the special APIs.
        //If we want to add an additional subbuilder, we have to break the OCP and edit the PersonBuilder directly.
        public static void Execute()
        {
            Console.WriteLine(nameof(TestWithCompositeBuilder));
            var pd = new PersonBuilder();
            var person = pd.Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
                .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);
            Console.WriteLine(person);
        }
    }
}