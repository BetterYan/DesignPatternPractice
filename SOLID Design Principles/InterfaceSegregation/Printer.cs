using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    // Step1: We have something
    public class Printer
    {
        public void Print()
        {
            //Do task
        }

        public void Scan()
        {
            //Do task
        }

        public void Fax()
        {
            //Do task
        }
    }

    //Step2: We want to extract the interface with IDE refactor feature or manually
    public interface IMachine
    {
        void Print();

        void Scan();

        void Fax();
    }

    //Step3: take the interface into use
    public class OldPrinter : IMachine
    {
        public void Print()
        {
            //Do task
        }

        public void Fax()
        {
            //The old printer havn't such feature
            // throw exception here, but it cheats the user who use the api
            throw new NotImplementedException();
        }

        //Such kind of obsolete doesn't help the user at all
        [Obsolete("Not support", true)]
        public void Scan()
        {
            //The old printer havn't such feature
            // leave it empty here, but it cheats the user who use the api
        }
    }

    //Step4: We should seperate the interface
    public interface IPrinter
    {
        public void Print();
    }

    public interface IScanner
    {
        public void Scan();
    }

    public interface IFax
    {
        public void Fax();
    }

    //Step5: Take the interface into use
    public class GoodPrinter : IPrinter, IScanner, IFax
    {
        public void Fax()
        {
            //do task
        }

        public void Print()
        {
            //do task
        }

        public void Scan()
        {
            //do task
        }
    }

    public class GoodOldPrinter : IPrinter
    {
        public void Print()
        {
            //do task
        }
    }

    //Step6: We can also define a multi interface
    public interface IMultiFunctionMachine : IPrinter, IScanner, IFax
    {
    }

    public class MultiFunctionPrinter : IMultiFunctionMachine
    {
        public void Fax()
        {
            //do task
        }

        public void Print()
        {
            //do task
        }

        public void Scan()
        {
            //do task
        }
    }

    //Step7: We can also simple delegation
    public class MultiFUntionMachine : IMultiFunctionMachine
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFax fax;

        public MultiFUntionMachine(IPrinter printer, IScanner scanner, IFax fax)
        {
            this.printer = printer;
            this.scanner = scanner;
            this.fax = fax;
        }

        public void Fax()
        {
            this.fax.Fax();
        }

        public void Print()
        {
            this.printer.Print();
        }

        public void Scan()
        {
            this.scanner.Scan();
        }
    }
}