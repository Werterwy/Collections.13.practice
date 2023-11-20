using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections._13.practice
{
    internal class Program
    {
        /// <summary>
        /// Вывести на экран позицию и значение элемента, являющегося вторым максимальным значением в коллекции
        /// </summary>
        public static void Secondmax(List<int> list)
        {
            int max=list.Max();
            list.Sort();
            for (int i=0; i<list.Count-2; i++)
            {
                int secmax = list[list.Count-i-2];
                if (secmax < max)
                {
                    Console.WriteLine(secmax);
                    break;
                }
            }

        }
        /// <summary>
        ///  a.Удалить все нечетные элементы списка List<int>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> deleteodd(List<int> list)
        {
            for(int i=0; i<list.Count; i++)
            {
                if (list[i] % 2 != 0)
                {
                    list.RemoveAt(i);
                }
            }

            return list;
        }

        public static void average(List<double> list)
        {
            double sum = 0;
            for(int i=0; i< list.Count; i++)
            {
                sum += list[i];
            }
            sum /= list.Count;
            for(int j=0; j< list.Count; j++)
            {
                if (list[j] > sum)
                {
                    Console.Write(list[j]+" ");
                }
            }
            Console.WriteLine("");
        }


        static void Main(string[] args)
        {
            /* 1.Создать коллекцию List<int>.Вывести на экран позицию и значение элемента, являющегося вторым 
                 максимальным значением в коллекции
                 a.Удалить все нечетные элементы списка List<int>*/


            /*   List<int> list = new List<int>();
               for(int i=0; i<10;  i++)
               {
                   Random rnd = new Random();
                   list.Add((i+1)*12);
               }
               Console.Write("Второй максимальный значение в list: ");
               Secondmax(list);
               list.Add(13);

               deleteodd(list);

               foreach(int i in list)
               {
                   Console.WriteLine(i);
               }*/


            /* 2.Дана коллекция типа List<double>.Вывести на экран элементы списка, 
                значение которых больше среднего арифметического всех элементов коллекции.*/


            /*  List<double> listd= new List<double>();
              for (int i = 0; i < 10; i++)
              {
                  Random rnd = new Random();
                  listd.Add((i + 1) * 12);
              }

              Console.WriteLine("Все значение которых больше среднего арифметического ");
              average(listd);*/


            /* 3.Дан файл, в котором записан набор чисел.Переписать в другой файл все числа в обратном порядке*/

            /*string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            List<int> numbers = ReadNumbersFromFile(inputFilePath);

            numbers.Reverse();

            WriteNumbersToFile(outputFilePath, numbers);

            Console.WriteLine("Числа записаны в обратном порядке в файл " + outputFilePath);*/


            /* 4.Дан файл, содержащий информацию о сотрудниках фирмы: фамилия, имя, отчество, пол, возраст,
                размер зарплаты. За один просмотр файла напечатать элементы файла в следующем порядке:
                сначала все данные о сотрудниках, зарплата которых меньше 10000, потом 
                данные об остальных сотрудниках, сохраняя исходный порядок в каждой группе сотрудников.*/

            string filePath = "employees.txt";

            List<Employee> employees = ReadEmployeesFromFile(filePath);

            var lowSalaryGroup = employees.Where(e => e.Salary < 10000).ToList();
            var highSalaryGroup = employees.Where(e => e.Salary >= 10000).ToList();

            PrintEmployees(lowSalaryGroup);
            PrintEmployees(highSalaryGroup);

            Console.ReadLine();



        }
        /// <summary>
        /// для чтения из файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static List<int> ReadNumbersFromFile(string filePath)
        {
            List<int> numbers = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numbers.Add(number);
                        }
                        else
                        {
                            Console.WriteLine($"Ошибка парсинга числа в строке: {line}. Пропускаем.");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            }

            return numbers;
        }

        /// <summary>
        /// запись в файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="numbers"></param>
        public static void WriteNumbersToFile(string filePath, List<int> numbers)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var number in numbers)
                    {
                        writer.WriteLine(number);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при записи файла: {e.Message}");
            }
        }

        /// <summary>
        /// запись из файла содержащий информацию о сотрудниках фирмы: фамилия, имя, отчество,
        /// пол, возраст, размер зарплаты. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Employee> ReadEmployeesFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length == 6)
                        {
                            Employee employee = new Employee
                            {
                                LastName = parts[0],
                                FirstName = parts[1],
                                Patronymic = parts[2],
                                Gender = parts[3],
                                Age = int.Parse(parts[4]),
                                Salary = decimal.Parse(parts[5])
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            }

            return employees;
        }

        /// <summary>
        /// вывод на экран содержимого в employees
        /// </summary>
        /// <param name="employees"></param>
        public static void PrintEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
