using System;
using System.Collections.Generic;
using System.IO;

namespace SingleResponsibility
{
    /// <summary>
    /// Step1: initialize a class
    /// </summary>
    public partial class Journal
    {
        private readonly List<string> entries = new List<string>();
    }

    /// <summary>
    /// Step2: boss needs a "add" function
    /// </summary>
    public partial class Journal
    {
        public void AddEntry(string text)
        {
            this.entries.Add(text);
        }
    }

    /// <summary>
    /// Step3: boss needs a "remove" function
    /// </summary>
    public partial class Journal
    {
        //It's still good here. We follow Single responsibility principle
        public void RemoveEntry(int index)
        {
            this.entries.RemoveAt(index);
        }
    }

    /// <summary>
    /// Step4: boss needs a "save to file" function
    /// </summary>
    public partial class Journal
    {
        //This approach is problematic
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, this.ToString());
        }
    }

    /// <summary>
    /// Step5: We need another class to do that job
    /// </summary>
    public class PersistenceManager
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}