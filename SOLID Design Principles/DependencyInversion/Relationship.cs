using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*The orginal definition stats the following:
* A. High-level modules should not depend on low-level modules. Both should depend on abstratctions.
* B. Abstractions should not depend on details. Details should depend on abstractions
* C. If I remember correctly, high-level module owns the interface.
*/

namespace DependencyInversion
{
    // Step1: We have something at first
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    //low-level
    public class Relationships
    {
        public List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }
    }

    // Step2: Boss needs to find all the children of John
    // high-level
    public class Research
    {
        private Relationships relationships;

        public Research(Relationships relationships)
        {
            this.relationships = relationships;
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return this.relationships.relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    //Step3: The high-level module depends on the low-level directly. It will also violate the open-close principle in somedays.
    //We need abstraction
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    //Step4: Take the interface into use
    public class BetterRelationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    //Stpe5: We can inject the interface implementation
    public class BetterResearch
    {
        private IRelationshipBrowser browser;

        public BetterResearch(IRelationshipBrowser browser)
        {
            this.browser = browser;
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return this.browser.FindAllChildrenOf(name);
        }
    }
}