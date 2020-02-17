using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Inheritance
{
    //In case that we want to inheritant the subbuilder class
    //It is complicated but we can implement it if we need it.
    public static class NotWorkVersion
    {
        public class Person
        {
            public string Name;
            public string Position;
        }

        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build() => person;
        }

        public class PersonInfoBuilder : PersonBuilder
        {
            public PersonInfoBuilder Called(string name)
            {
                person.Name = name;
                return this;
            }
        }

        public class PersonJobBuilder : PersonInfoBuilder
        {
            public PersonJobBuilder WorksAt(string position)
            {
                person.Position = position;
                return this;
            }
        }

        public static class TestWithBuilderInheritance
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(TestWithBuilderInheritance));
                var pd = new PersonInfoBuilder();
                var person = pd.Called("James")
                    //.WorksAt("Nokia") //error
                    .Build();
            }
        }
    }

    public static class WorkVersion
    {
        public class Person
        {
            public string Name;
            public string Position;
            public DateTime DateOfBirth;

            public class Builder : PersonBirthDateBuilder<Builder>
            {
                internal Builder()
                {
                }
            }

            public static Builder New => new Builder();

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append($"[Name]: {Name} [Position]: {Position} [DateOfBirth]: {DateOfBirth}");
                return sb.ToString();
            }
        }

        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build() => person;
        }

        public class PersonInfoBuilder<T> : PersonBuilder
            where T : PersonInfoBuilder<T>
        {
            public T Called(string name)
            {
                person.Name = name;
                return (T)this;
            }
        }

        public class PersonJobBuilder<T>
            : PersonInfoBuilder<PersonJobBuilder<T>>
            where T : PersonJobBuilder<T>
        {
            public T WorksAt(string position)
            {
                person.Position = position;
                return (T)this;
            }
        }

        public class PersonBirthDateBuilder<T>
            : PersonJobBuilder<PersonBirthDateBuilder<T>>
            where T : PersonBirthDateBuilder<T>
        {
            public T Born(DateTime time)
            {
                this.person.DateOfBirth = time;
                return (T)this;
            }
        }

        public static class TestWithBuilderInheritance
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(TestWithBuilderInheritance));
                var person = Person.New
                    .Called("James")
                    .WorksAt("Nokia")
                    .Born(DateTime.Now)
                    .Build();
                Console.WriteLine(person);
            }
        }
    }
}