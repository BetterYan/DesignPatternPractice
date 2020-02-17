using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Singleton.IoC
{
    //IoC stands for Inversion of Control container
    //We use Microsoft.DI here.
    public class Database
    {
        //Normal Ctor
        public Database()
        {
        }

        public int TotalPopulation()
        {
            return 100;
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Database>();
            var serviceProvider = services.BuildServiceProvider();
            var db1 = serviceProvider.GetService<Database>();
            var db2 = serviceProvider.GetService<Database>();
            Console.WriteLine(db1 == db2);
        }
    }
}