using System.Diagnostics.Metrics; // Подключение пространства имён (в данном коде не используется)

namespace GuessNumber // Объявление пространства имён
{
    internal class Program // Главный класс программы
    {
        static void Main(string[] args) // Точка входа в программу
        {
            int min = 0; // Минимальное количество попыток за все игры
            int max = 0; // Максимальное количество попыток
            int count = 0; // Общее количество попыток во всех играх
            int countGame = 0; // Количество сыгранных игр
            Random rnd = new Random(); // Создание генератора случайных чисел
            char answer = 'Y'; // Переменная для ответа пользователя (продолжать игру?)
            do // Цикл выполняется минимум один раз
            {
                int couneter = PlayGame(rnd, ref min, ref max, ref count, ref countGame);
                // Вызов игры. Передаём статистику по ссылке (ref), чтобы она изменялась внутри метода
                Console.WriteLine("Do you want play game?"); // Вопрос о продолжении игры
                answer = Convert.ToChar(Console.Read());
                // Чтение одного символа из консоли (лучше использовать ReadLine)
            }
            while (answer == 'Y'); // Повторяем, пока пользователь вводит 'Y'
            Console.WriteLine($"min = {min} max = {max} avg = {(double)count / countGame}");
            // Вывод статистики: минимум, максимум и среднее количество попыток
        }
        static int PlayGame(Random rnd, ref int min, ref int max, ref int count, ref int countGame)
        // Метод одной игры. Возвращает количество попыток
        {
            int couneter = 0; // Счётчик попыток
            int number = rnd.Next(1, 100);
            // Генерация случайного числа от 1 до 99 (100 не включается)
            Console.WriteLine("Try guess number?"); // Сообщение игроку
            while (true) // Бесконечный цикл до угадывания числа
            {
                couneter++; // Увеличиваем счётчик попыток
                int userNumber = ReadUserNumber();
                // Чтение числа, введённого пользователем
                if (userNumber > number)
                    Console.WriteLine("Your number is less!");
                // Подсказка (сообщение написано логически наоборот)
                else if (userNumber < number)
                    Console.WriteLine("Your number is great!");
                // Подсказка (также перепутан текст)
                else
                {
                    Console.WriteLine("You are Win!!!"); // Сообщение о победе
                    if (min == 0 || min > couneter)
                        min = couneter;
                    // Обновляем минимум попыток
                    max = max < couneter ? couneter : max;
                    // Обновляем максимум попыток (тернарный оператор)
                    count += couneter;
                    // Добавляем попытки к общему количеству
                    countGame++;
                    // Увеличиваем количество игр
                    break; // Выход из цикла после победы
                }
            }
            return couneter; // Возвращаем количество попыток
        }
        static int ReadUserNumber() // Метод чтения числа от пользователя
        {
            int userNumber = 0; // Переменная для хранения введённого числа
            Console.WriteLine("Input number from [1;100]");
            // Просим пользователя ввести число от 1 до 100

            for (int i = 0; i < 3; i++)
            // Даём пользователю 3 попытки ввода корректного числа
            {
                if (!int.TryParse(Console.ReadLine(), out userNumber)
                    || userNumber > 100 || userNumber < 1)
                    // Проверяем: число ли это и входит ли в диапазон
                    Console.WriteLine("Input number from [1;100]");
                else
                    break; // Если всё корректно — выходим из цикла
                if (i == 2) // Если третья неудачная попытка
                {
                    Console.WriteLine("You are stupid");
                    // Сообщение (некорректное с точки зрения UX)
                    Environment.Exit(0);
                    // Завершение программы
                }
            }
            return userNumber; // Возвращаем введённое число
        }
    }
}
//1. Методы класса - разбить эту программу на методы, а в мейн вызвать.
// Метод - должен нести 1 SOLID - S-single resposnsobility principle.
// Создать в гитхабе Открытый репозиторий (public) с лицензией MIT с gitignore VisualStudio имя репозитория AlgorithmAndDataStructures в описании что-нибудь написать полезное.
// Сделать push через MicrosoftVisualStudio домашнего задания, написать в Commit то, что вы закодировали