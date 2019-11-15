using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _611pst_Lopatiev_OOP_LR4
{
    class Vector
    {
        private int[] _arr;

        public Vector(int countArr)
        {
            _arr = new int[countArr];

            if (countArr > 10)
                SetRandomArray();
            else
                SetArray();
        }

        private Vector()
        {

        }

        private void SetArray()
        {
            for (var i = 0; i < _arr.Length; i++)
            {
                do
                {
                    Console.Write($"ARR[{i + 1}] = ");
                }
                while (!int.TryParse(Console.ReadLine(), out _arr[i]));
            }
        }

        private void SetRandomArray()
        {
            Random rand = new Random();

            for (var i = 0; i < _arr.Length; i++)
            {
                _arr[i] = rand.Next(0, 100);
            }

#if DEBUG
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("vector = " + String.Join(" ", _arr));
    Console.ForegroundColor = ConsoleColor.White;
#endif
        }

        public int GetLengthVector()
        {
            return _arr.Length;
        }

        public string GetVectorString()
        {
            return String.Join(" ", _arr);
        }

        public static bool operator >(Vector vectorX, Vector vectorY) => vectorX._arr.Max() >= vectorY._arr.Max();

        public static bool operator <(Vector vectorX, Vector vectorY) => vectorX._arr.Max() < vectorY._arr.Max();

        public static Vector operator /(Vector vectorX, Vector vectorY)
        {
            List<int> newArr = new List<int>();

            for (var i = 0; i < vectorX._arr.Length; i++)
            {
                if (i >= vectorY._arr.Length)
                    break;

                newArr.Add(vectorX._arr[i] / vectorY._arr[i]);
#if DEBUG
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{vectorX._arr[i]} / {vectorY._arr[i]} = {vectorX._arr[i] / vectorY._arr[i]}");
    Console.ForegroundColor = ConsoleColor.White;
#endif
            }

            return new Vector()
            {
                _arr = newArr.ToArray()
            };
        }

        public static Vector operator -(int x, Vector vectorX) =>
            new Vector()
            {
                _arr = vectorX._arr.Select(t => x - t).ToArray()
            };

        public static Vector operator -(Vector vectorX, int x) =>
            new Vector()
            {
                _arr = vectorX._arr.Select(t => t - x).ToArray()
            };

        public static implicit operator Vector(int x)
        {
            return new Vector()
            {
                _arr = new[] {x}
            };
        }
    }
}
