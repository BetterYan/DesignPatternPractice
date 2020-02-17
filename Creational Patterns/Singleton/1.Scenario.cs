using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Scenario
{
    //We know that such kind of document doesn't work.
    public class Database
    {
        /// <summary>
        /// Please do not create more than one instance.
        /// </summary>
        public Database()
        {
            //Do something
        }
    }
}