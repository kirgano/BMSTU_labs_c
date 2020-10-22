using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_биквадратное_уравнение
{
    
    class Program
    {


        static void Main(string[] args)
        {
            int counter = 0;
           double IsNum(double c, int count)
            {
                bool b;
                string s;
                //count = count + 1;
                char[] alph={'A','B','C'};
                b = double.TryParse(args[count], out c);
                

                if (b == true)
                    return c; 
                else
                {
                    Console.WriteLine("Произошла ошибка при считывании начального значения коэффициента {0}, введите значения вручную", alph[count]);
                    s=Console.ReadLine();
                    b = double.TryParse(s, out c);
                    if (b == true)
                        return c;
                    else
                    {
                        Console.WriteLine("Произошла ошибка при вводе значения коэффициента {0} с клавиатуры, введите числовое значение еще раз", alph[count]);
                        s = Console.ReadLine();
                        c = double.Parse(s);
                        return c;
                    }
                    
                }

                
            }

            double A = 0, B = 0, C = 0, D = 0, x1 = 0, x2 = 0, x3 = 0, x4 = 0, t1 = 0, t2 = 0, d=0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Озеров Павел Васильевич. Группа ИУ5-35Б");
            Console.ResetColor();
            //A = Convert.ToInt32(Console.ReadLine());
            // a b c = args (1,2,3) + проверка для каждого на string (если строка, то не подходит)
            A = IsNum(A, counter);
            counter++;
            B = IsNum(B, counter);
            counter++;
            C = IsNum(C, counter);
            //у биквадратного уравнения есть вид ax^4+bx^2+c=0
            bool Bo = false;
            if (A == 0)
            {
                if (B != 0)
                {
                    if (C == 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("X=0");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (C / B < 0)
                        {
                            x1 = Math.Sqrt(-(C / B));
                            x2 = -Math.Sqrt(-(C / B));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("X1={0}; X2={1}", x1, x2);
                            Console.ResetColor();
                        }
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine ("Нет решений");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    if (C != 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Нет решений");
                        Console.ResetColor();
                    }
                    else 
                    {
                        Console.WriteLine("X любое"); 
                    }

                }
            }
            else
            {
                D = (B * B - 4 * A * C);
                if (D < 0) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нет решений");
                    Console.ResetColor();
                }
                else
                {
                    d = Math.Sqrt(D);
                    t1 = (-B + d) / (2*A);
                    t2 = (-B - d) / (2*A);

                    if (t1 > 0)
                    {
                        x1 = Math.Sqrt(t1);
                        x2 = -Math.Sqrt(t1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("X1={0}; X2={1}", x1, x2);
                        Console.ResetColor();
                        Bo = true;
                    }
                    if (t2 > 0)
                    {
                        x3 = Math.Sqrt(t2);
                        x4 = -Math.Sqrt(t2);
                        if (Bo == true) 
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("X3={0}; X4={1}", x3, x4);
                            Console.ResetColor();
                        }
                        if (Bo == false) 
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("X1={0}; X2={1}", x3, x4);
                            Console.ResetColor();
                        }
                    }
                }
            }
            Console.ReadLine();
        }
        
    }
    
 }
