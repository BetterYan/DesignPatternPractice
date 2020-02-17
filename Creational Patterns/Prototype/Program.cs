using System;

namespace Prototype
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Scenario.Basicknowledge.Test.Execute();
            CopyApproach.ICloneableApproach.Test.Execute();
            CopyApproach.DeepCopyByOurselves.Test.Execute();
            CopyApproach.CopyWithCtor.Test.Execute();
            Serialization.SerializationApproach.Test.Execute();
            PrototypeApproach.Test.Execute();
        }
    }
}