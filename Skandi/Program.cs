using System.Diagnostics;

namespace Skandi
{
    internal class Program
    {

        private static List<string[]> handyNumbers = new List<string[]>();
        private static List<string[]> machineNumbers = new List<string[]>();
        private static List<string[]> userTickets = new List<string[]>();

        static void Main(string[] args)
        {
            string path = @"skandi.csv";
            ReadFile(path);
            // GetNumbers(machineNumbers);
            // UserInput();
            // CheckUserNumbers(userTickets);

            string[] numbers = {"1", "2", "3", "4", "5", "6", "7" };
            List<string[]> steps = NextStep(numbers, 6);
            ReadListOfArrays(steps);
        }


        public static void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] numbers = line.Split(';');
                List<string> handy = new List<string>();
                List<string> machine = new List<string>();

                for (int i = 0; i < numbers.Length; i++)
                {
                    if(i >= 11 && i < 18)
                    {
                        machine.Add(numbers[i]);
                    }
                    if(i > 17 && i <=24 )
                    {
                        handy.Add(numbers[i]);
                    }
                }
                handyNumbers.Add(handy.ToArray());
                machineNumbers.Add(machine.ToArray());
            }
            sr.Close();
        }


        public static void GetNumbers(List<string[]> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.ElementAt(i).Length; j++)
                {
                    string number = list.ElementAt(i)[j];
                    Console.Write(number + ", ");
                }
                Console.WriteLine("");
            }
        }


        public static void UserInput()
        {
            Console.WriteLine("Hány szelvény?");
            int tickets = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < tickets; i++)
            {
                List<string> numbers = new List<string>();

                Console.WriteLine("/*-*-*-*-*-*-*-*");
                Console.WriteLine($"{i + 1} szelvény:");

                for (int j = 0; j < 7; j++)
                {
                    string input = Console.ReadLine();
                    numbers.Add(input);
                }

                userTickets.Add(numbers.ToArray());
            }

        }


        public static void CheckNumbers(List<string[]> list, string[] numbers) 
        {
            for (int i = 0; i < list.Count; i++)
            {
                List<string> found = new List<string>();

                for (int j = 0; j < list.ElementAt(i).Length; j++)
                {
                    string number = list.ElementAt(i)[j];

                    if (!numbers.Contains(number))
                    {
                        break;
                    } else
                    {
                        found.Add(number);
                    }
                }
                if(found.Count == 7)
                {
                    Console.WriteLine("Találat!");
                    break;
                }
            }
            Console.WriteLine("Nincs találat!");

            // 1 6 11 14 21 25 35
            // 1 5 6 14 21 25 32
            // 2 5 9 11 13 29 35
            // 2 6 11 14 21 25 32
        }


        public static void CheckUserNumbers(List<string[]> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                CheckNumbers(handyNumbers, list.ElementAt(i).ToArray());
                CheckNumbers(machineNumbers, list.ElementAt(i).ToArray());
            }
        }


        public static string[] IncrementArray(string[] numbers, int index)
        {
            int count = Convert.ToInt32(numbers[index]);
            count++;
            numbers[index] = count.ToString();
            return numbers;
        }

        public static List<string[]> NextStep(string[] numbers, int startIndex)
        {
            List<string[]> list = new List<string[]>();
            string[] temp = numbers;
            int endIndex = 35 - (7 - startIndex);

            for (int i = startIndex; i < endIndex; i++)
            {
                string[] result = IncrementArray(temp, startIndex);
                temp = result;
                list.Add(result.ToArray());
            }

            return list;
        }


        public static void ReadListOfArrays(List<string[]> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.ElementAt(i).Length; j++)
                {
                    Console.Write(list.ElementAt(i)[j] + ", ");
                }
                Console.WriteLine("");
            }
        }

    }
}