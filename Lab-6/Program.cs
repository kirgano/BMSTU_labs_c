using System;

namespace LAB_6
{
    class Program
    {

        delegate double Oper(double a, int b);
        static void neMain(string[] args)
        {

            double Plus(double a, int b)
            {
                return a + b;
            }
            void PlusMinus(string str, double a, int b, Oper param)
            {
                double Result = param(a, b);
                Console.WriteLine(str + ' ' + '=' + ' ' + Result.ToString());
            }
            Console.WriteLine("Вызов через метод");
            //Вызов через метод
            PlusMinus("Плюс", 7.8, 4, Plus);
            Console.WriteLine("Вызов через лямбда");
            // вызов через лямбда
            PlusMinus("Плюс", 7.8, 4, (a, b) => a + b);
            //Func
            Console.WriteLine("Вызов через Function");
            void PlusMinus1(string str, double a, int b, Func<double, int, double> param)
            {
                double Result = param(a, b);
                Console.WriteLine(str + ' ' + '=' + ' ' + Result.ToString());
            }
            PlusMinus1("Плюс", 7.8, 4, Plus);
        }
    }
}
