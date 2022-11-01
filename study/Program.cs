using System.Text;

namespace study
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            RomanianNumbersToArabic();
        }

        private static void RomanianNumbersToArabic()
        {
            Console.Write("Enter string of romanian numbers: ");
            var romanianNumbers = Console.ReadLine();

            if (romanianNumbers == null) return;

            var dictionary = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var result = 0;

            var filteredString = string.Empty;

            for (var i = 0; i < romanianNumbers.Length; i++)
            {
                var isRomanianNumber = dictionary.TryGetValue(romanianNumbers[i], out int arabicValue);

                if (isRomanianNumber) filteredString += romanianNumbers[i];
            }

            for (var i = 0; i < filteredString.Length; i++)
            {
                var arabicNumber1 = dictionary[filteredString[i]];
                if (i == filteredString.Length - 1) result += arabicNumber1;
                else
                {
                    var arabicNumber2 = dictionary[filteredString[i + 1]];

                    if (arabicNumber2 > arabicNumber1)
                    {
                        result -= arabicNumber1;
                    }
                    else result += arabicNumber1;
                }
            }

            Console.WriteLine($"{filteredString} converted to arabic numbers is {result}");
        }

        private static int getInt()
        {
            return int.Parse(Console.ReadLine());
        }

        private static void _3LoginAttempts()
        {
            const string login = "vova", password = "password";

            const int loginAttempts = 3;

            bool userEntered = false;

            for (var i = 0; i < loginAttempts; i++)
            {
                Console.Clear();

                Console.Write("Enter login: ");
                var enteredLogin = Console.ReadLine();

                Console.Write("Enter password: ");
                var enteredPassword = Console.ReadLine();

                if (enteredLogin == login && enteredPassword == password)
                {
                    userEntered = true;
                    break;
                }
            }

            Console.WriteLine(userEntered ? "Enter the System" : "The number of available tries have been exceeded");
        }

        private static void Factorial()
        {
            Console.Write("Enter number, for which you want to get factorial: ");
            var number = getInt();

            int factorial = 1;

            for (var i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"Factorial of {number} is {factorial}");
        }

        private static void GetAvg()
        {
            List<int> list = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                Console.Write($"Enter {i + 1} of 10 element: ");
                int enteredNumber = int.Parse(Console.ReadLine());

                if (enteredNumber == 0) break;

                if (enteredNumber % 3 == 0) list.Add(enteredNumber);
            }

            double sumOfAll = 0;

            foreach (var number in list)
            {
                sumOfAll += number;
            }

            Console.WriteLine($"avg number of % 3 == 0 numbers is {sumOfAll / list.Count}");
        }

        private static void Fibonacci()
        {
            Console.Write("Enter length of Fibonacci series: ");
            var length = getInt();

            var fibNumbers = new long[length];

            for (var i = 0; i < length; i++)
            {
                if (i < 2)
                {
                    fibNumbers[i] = 1;
                    continue;
                }

                long prevValue1 = fibNumbers[i - 2];
                long prevValue2 = fibNumbers[i - 1];

                fibNumbers[i] = prevValue1 + prevValue2;
            }

            foreach (var number in fibNumbers)
            {
                Console.Write($"{number} ");
            }
        }

        private static void Label()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (i == 3 && j == 4) goto LabelToBreak;

                    Console.WriteLine($"{i} {j}");
                }
            }

            LabelToBreak:
            {
                Console.WriteLine("Exit");
            }
        }

        private static void MaxValueOf2Numbers()
        {
            Console.Title = "Application Test";

            Console.Write("Enter 1 number: ");
            var firstNum = int.Parse(Console.ReadLine());

            Console.Write("Enter 2 number: ");
            var secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNum > secondNum ? $"{firstNum} is bigger" : $"{secondNum} is bigger");
        }

        private static void HwUserProfile()
        {
            Console.WriteLine("Enter your params:");

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            double age = double.Parse(Console.ReadLine());

            Console.Write("Weight: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());

            double imt = weight / (Math.Pow(height, 2));

            Console.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("Your profile:\n");
            sb.Append($"Full name: {lastName}, {name}\n");
            sb.Append($"Age: {age}\n");
            sb.Append($"Weight: {weight}\n");
            sb.Append($"Height: {height}\n");
            sb.Append($"IMT: {imt}\n");

            Console.WriteLine(sb.ToString());
        }

        private static void HwHeron()
        {
            Console.Write("Enter side A: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter side B: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Enter side C: ");
            double c = double.Parse(Console.ReadLine());

            double p = (a + b + c) / 2;

            double square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            Console.WriteLine($"Square of triangle is {square:f2}");
        }

        private static void HwFrom1To3()
        {
            Console.WriteLine("First task");
            Console.Write("Enter your name: ");
            var userName = Console.ReadLine();
            Console.WriteLine($"Your name is {userName}");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Second task");
            Console.Write("Enter x: ");
            var userInput = Console.ReadLine();
            int x = int.Parse(userInput);
            Console.Write("Enter y: ");
            userInput = Console.ReadLine();
            int y = int.Parse(userInput);
            (x, y) = (y, x);
            Console.WriteLine($"Swapped x = {x} and swapped y = {y}");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Third task");
            Console.Write("Enter your number: ");
            userInput = Console.ReadLine();

            Console.WriteLine($"Length of your number is {userInput.Length}");
            Console.ReadLine();
        }
    }
}