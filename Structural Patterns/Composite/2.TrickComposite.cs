using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.TrickComposite
{
    public static class Scenario
    {
        //Scenario: Neural Networks
        public class Neuron
        {
            public List<Neuron> In, Out;

            public void ConnectTo(Neuron other)
            {
                Out.Add(other);
                other.In.Add(this);
            }
        }

        public class NeuronLayer : Collection<Neuron>
        {
            public NeuronLayer(int count)
            {
                while (count-- > 0)
                {
                    Add(new Neuron());
                }
            }
        }

        //Neural Networks usecase
        //var neuron1 = new Neuron();
        //var neuron2 = new Neuron();
        //var layer1 = new NeuronLayer(2);
        //var layer2 = new NeuronLayer(3);
        //neuron1.ConnectTo(neuron2);
        //neuron1.ConnectTo(layer1);
        //layer2.ConnectTo(neuron1);
        //layer1.ConnectTo(layer2);

        //Think about how many methods we should create
        //What about there are more distinct classes.
    }

    //We can make them belong to same interface, and use some tricks to make someone can yield itself for IEnumerable<T>
    public static class Solution
    {
        public class Neuron : IEnumerable<Neuron>
        {
            public List<Neuron> In, Out;

            public IEnumerator<Neuron> GetEnumerator()
            {
                yield return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class NeuronLayer : Collection<Neuron>
        {
            public NeuronLayer(int count)
            {
                while (count-- > 0)
                {
                    Add(new Neuron());
                }
            }
        }
    }

    public static class Extensions
    {
        public static void ConnectTo(this IEnumerable<Solution.Neuron> self, IEnumerable<Solution.Neuron> other)
        {
            if (ReferenceEquals(self, other))
            {
                return;
            }
            foreach (var from in self)
            {
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }
}