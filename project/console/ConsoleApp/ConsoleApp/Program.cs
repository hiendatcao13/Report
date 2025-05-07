using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        delegate void ThongBao(string message);
        static void Main(string[] args)
        {
            Action<string> action;
            action = printMessageHelloWorld;
            action("xin chào mọi người");

            Predicate<string> predicate;
            predicate = isHello;

            Func<string, bool> func;
            func = isHello;

            //tuple type
            (string ten, int age) GetPerson()
            {
                return ("Pino Dat", 20);
            }

            var (ten, age) = GetPerson();
            Console.WriteLine($"Name: {ten}, Age: {age}");
            Console.WriteLine("Phép toán từ 1 đến 10 = "+ Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            Func<int, int, int> calculator = (a, b) => a + b;
            Console.WriteLine("Sum of 2 numbers: " + calculator(5, 10));
            Console.WriteLine("Is they hello? " + func("Goodbye everyone"));
            Console.WriteLine("Is they hello? " + predicate("Hello everyone"));
            Console.WriteLine("End of code............");

            Console.Write("Nhap: ");
            string input = Console.ReadLine();
            Console.WriteLine("Kết quả: " + isRegex(input));
        }

        static bool isRegex(string message)
        {
            string pattern = "abc{2}";
            return Regex.IsMatch(message, pattern);
        }
        static void printMessageHello(string v)
        {
            Console.WriteLine("Hello");
        }

        static void printMessageWorld()
        {
            Console.WriteLine("World");
        }
        static void printMessageHelloWorld(string message2)
        {
            Console.WriteLine("Hello World " + message2);
        }
        static bool isHello (string message)
        {
            return message.Contains("Hello");
        }
        static int Sum(params int[] arr)
        {
            return arr.Sum();
        }
        static IEnumerable<int> randomNumberMeAppearTwo(bool isRandom)
        {
            if(isRandom)
                yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
    }
}