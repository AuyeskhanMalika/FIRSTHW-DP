using System;

namespace RefactoringGuru.DesignPatterns.FactoryMethod.Conceptual
{
    abstract class Logistic
    {
        public abstract IPrint GetPrint(); //Vtnjl
        public string Print() //Базовый класс
        {
            IPrint print = GetPrint(); //Результат какой то продукт
            string result = "Creator: The same creator's code has just worked with "
            + print.Printing();
            return result;
        }
    }

    class Canon : Logistic
    {
        public override IPrint GetPrint()
        {
            return new Perl();
        }
    }

    class HP : Logistic
    {
        public override IPrint GetPrint()
        {
            return new OffSet ();
        }
    }

    public interface IPrint
    {
        string Printing();
    }

    class Perl : IPrint
    {
        public string Printing()
        {
            return "{Result of Canon}";
        }
    }

    class OffSet  : IPrint
    {
        public string Printing()
        {
            return "{Result of HP}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Canon: Печатает бумагой Perl.");
            ClientCode(new Canon());

            Console.WriteLine("HP: Печатает бумагой OffSet.");

            Console.WriteLine("");
            ClientCode(new HP());
        }
        public void ClientCode(Logistic creator)
        {
            Console.WriteLine(creator.Print());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}