using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

// Action<входной тип> название = входной парам => {тело}
// Func<входной тип, тип результата> название = входной парам => возвращаемое выражение

namespace CourseFP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Comparer();
        }
        
        //ПРАКТИЧЕСКИЕ РАБОТЫ 1
        
        // Задание 1. Печать через Action<T>
        private static void PrintWords()
        {
            var message = Console.ReadLine();
            Action<string> print = message =>
            {
                var arr = message.Split(" ");
                foreach (var a in arr)
                {
                    Console.WriteLine(a);
                }
            };
            print(message);
        }
        
        //Задание 2. «Бумажный» релиз
        private static void PrintNums()
        {
            var message = Console.ReadLine();
            Action<string> print = message =>
            {
                var arr = message.Split(" ");
                foreach (var a in arr)
                {
                    Console.WriteLine($"{a} (нет в наличии)");
                }
            };
            print(message);
        }
        
        //Задание 3. Минимальное число 
        private static void PrintMin()
        {
            var message = Console.ReadLine();
            Func<string, int> parser = message =>
            {
                var arr = message.Split(" ");
                var min = int.Parse(arr[0]);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (int.Parse(arr[i]) < min)
                    {
                        min = int.Parse(arr[i]);
                    }
                }
                return min;
            };
            Console.WriteLine(parser(message));
        }

        //Задание 4. Четные/Нечетные из диапазона
        private static void Range()
        {
            //создать массив в диапазоне
            var nums = Console.ReadLine();
            var range = nums.Split(" ");
            var first = int.Parse(range[0]);
            var last = int.Parse(range[1]);
            List<int> array = new List<int>();
            for (int i = first; i <= last; i++)
            {
                array.Add(i);
            }
            
            //вывести чет/нечет
            var type = Console.ReadLine();
            if (type == "even")
            {
                Func<List<int>, List<int>> remove = list =>
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 != 0)
                        {
                            list.RemoveAt(i);
                        }
                    }
                    return list;
                };
                remove(array);
            }
            else if (type == "odd")
            {
                Func<List<int>, List<int>> remove = list =>
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 == 0)
                        {
                            list.RemoveAt(i);
                        }
                    }
                    return list;
                };
                remove(array);
            }
            else
            {
                Console.WriteLine("Введите even/odd");
            }

            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
        }
        
        //ПРАКТИЧЕСКИЕ РАБОТЫ 2
        
        //Задание 1. Арифметические операции 
        // "add" -> добавить 1 к каждому числу;
        // "multiply" -> умножить каждое число на 2;
        // "subtract" -> вычесть 1 из каждого числа;
        // “print” -> распечатать коллекцию.
        // Ввод завершается командой "end". 
        private static void MathOperations()
        {
            //ввод чисел
            var input = Console.ReadLine()!.Split(" ");
            var nums = new int[input.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(input[i]);
            }

            //ввод и запись в лист операций
            var operation = Console.ReadLine();
            List<string> operations = new List<string>();
            while (!operation.Equals("end"))
            {
                operations.Add(operation);
                operation = Console.ReadLine();
            }
            
            Func<int, string, int> operate = (int i, string s) =>
            {
                switch (s)
                {
                    case "add": return i + 1;
                    case "multiply": return i * 2;
                    case "subtract": return i - 1;
                    case "print": return i;
                    default: return 0;
                }
            };

            Func<int[], List<string>, int[]> math = (arr, op) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    foreach (var o in op)
                    {
                        arr[i] = operate(arr[i], o);
                    }
                }

                return arr;
            };
            var arr = math(nums, operations);

            if (operations.Contains("print"))
            {
                foreach (var a in arr)
                {
                    Console.WriteLine(a);
                }
            }
        }
        
        //Задание 2. Реверсирование 
        private static void Reverse()
        {
            //ввод и реверсирование
            var input = Console.ReadLine()!.Split(" ");
            var nums = new int[input.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(input[i]);
            }

            Func<int[], List<int>> reverse = arr =>
            {
                var array = new List<int>();
                for (int i = arr.Length; i > 0; i--)
                {
                    array.Add(arr[i - 1]);
                }

                return array;
            };
            var reversedArr = reverse(nums);

            //ввод числа и ремув тех элементов, которые делятся
            var number = Console.ReadLine();
            var n = int.Parse(number);
            Func<List<int>, int, List<int>> remove = (arr, num) =>
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] % num == 0)
                    {
                        arr.RemoveAt(i);
                    }
                }

                return arr;
            };
            remove(reversedArr, n);
            
            foreach (var r in reversedArr)
            {
                Console.WriteLine(r);
            }
        }
        
        //Задание 3. Фильтрация имен
        private static void Filter()
        {
            var number = Console.ReadLine();
            var n = int.Parse(number);
            
            var names = Console.ReadLine()?.Split(" ");

            Func<string[], int, List<string>> filter = (str, num) =>
            {
                List<string> result = new();
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Length <= num)
                    {
                        result.Add(str[i]);
                    }
                }

                return result;
            };
            var result = filter(names, n);
            
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }
        
        //Задание 4. Компаратор 
        private static void Comparer()
        {
            var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int Comparer(int a, int b)
            {
                if (a % 2 == 0)
                {
                    if (b % 2 == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (b % 2 == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return a.CompareTo(b);
                    }
                }
            }

            Array.Sort(array, Comparer);

            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
        }
    }
}


