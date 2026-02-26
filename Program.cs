using System.Diagnostics.Metrics;
namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            int count = 0;
            int countGame = 0;
            Random rnd = new Random();
            char answer = 'Y';
            do
            {
                int couneter = PlayGame(rnd, ref min, ref max, ref count, ref countGame);
                Console.WriteLine("Do you want play game?");
                answer = Convert.ToChar(Console.Read());
            }
            while (answer == 'Y');
            Console.WriteLine($"min = {min} max = {max} avg = {(double)count / countGame}");
        }
        static int PlayGame(Random rnd, ref int min, ref int max, ref int count, ref int countGame)
        {
            int couneter = 0;
            int number = rnd.Next(1, 101);
            Console.WriteLine("Try guess number?");
            while (true)
            {
                couneter++;
                int userNumber = ReadUserNumber();
                if (userNumber > number)
                    Console.WriteLine("Your number is less!");
                else if (userNumber < number)
                    Console.WriteLine("Your number is great!");
                else
                {
                    Console.WriteLine("You are Win!!!");
                    if (min == 0 || min > couneter)
                        min = couneter;
                    max = max < couneter ? couneter : max;
                    count += couneter;
                    countGame++;
                    break;
                }
            }
            return couneter;
        }
        static int ReadUserNumber()
        {
            int userNumber = 0;
            Console.WriteLine("Input number from [1;100]");

            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out userNumber)
                    || userNumber > 100 || userNumber < 1)
                    
                    Console.WriteLine("Input number from [1;100]");
                else
                    break;
                if (i == 2)
                {
                    Console.WriteLine("You are stupid");
                    return -1;
                }
            }
            return userNumber;
        }
    }
}
//1. Методы класса - разбить эту программу на методы, а в мейн вызвать.
// Метод - должен нести 1 SOLID - S-single resposnsobility principle.
// Создать в гитхабе Открытый репозиторий (public) с лицензией MIT с gitignore VisualStudio имя репозитория AlgorithmAndDataStructures в описании что-нибудь написать полезное.
// Сделать push через MicrosoftVisualStudio домашнего задания, написать в Commit то, что вы закодировали