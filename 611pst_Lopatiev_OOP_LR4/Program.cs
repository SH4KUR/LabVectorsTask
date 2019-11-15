using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _611pst_Lopatiev_OOP_LR4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            do
            {
                Vector vectorA = new Vector(SetLengthVector("A"));
                Vector vectorB = new Vector(SetLengthVector("B"));

                Vector vectorX = null;

                if (vectorA.GetLengthVector() == vectorB.GetLengthVector())
                {
#if DEBUG
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"X = -10");
    Console.ForegroundColor = ConsoleColor.White;
#endif
                    vectorX = -10;
                }
                else
                {
                    try
                    {
                        if (vectorA.GetLengthVector() > vectorB.GetLengthVector())
                        {
#if DEBUG
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"X = 1 - A / B");
    Console.ForegroundColor = ConsoleColor.White;
#endif
                            vectorX = 1 - vectorB / vectorA;

                        }
                        else
                        {
#if DEBUG
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"X = (A - 52) / B");
    Console.ForegroundColor = ConsoleColor.White;
#endif
                            vectorX = (vectorA - 52) / vectorB;

                        }
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Деление на ноль запрещенно!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("\n\tРезультаты:\n");

                Console.WriteLine($"A: {vectorA.GetVectorString()}");
                Console.WriteLine($"B: {vectorB.GetVectorString()}");
                Console.WriteLine($"\nX: {vectorX?.GetVectorString() ?? "не задано"}");

                exit = ExitProgram();

            } while (exit == false);

            Console.Write("\nНажмите ENTER: ");
            Console.ReadLine();
        }

        private static int SetLengthVector(string nameVector)
        {
            int lengthVector;
            do
            {
                do
                {
                    Console.Write($"Введите размер вектора {nameVector}: ");
                } while (!int.TryParse(Console.ReadLine(), out lengthVector));
            } while (lengthVector <= 0);

            return lengthVector;
        }

        public static bool ExitProgram()
        {
            Console.WriteLine("\n" + new string('*', 13));
            Console.WriteLine("Посчитать еще раз? (y / n)");

            string answer;

            do
            {
                Console.Write("Ответ: ");
                answer = Console.ReadLine();
            }
            while (!(answer.Equals("y") || answer.Equals("n")));

            return answer.Equals("n");
        }
    }
}