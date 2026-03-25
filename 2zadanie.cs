namespace App2Bebra
{
    internal class Program
    {
        // Объясняем для самых маленьких, ну и для тех у кого нет фонтана:(
        static void Main()
        {
            //Вводим список с примером, в нашем случае счастливое число = 2.
            int[] arr = { 2, 2, 3, 4 };
            //выводим в cmd вывод функции FindLucky с нашей переменной arr.
            Console.WriteLine(FindLucky(arr)); // 2

        }
        // Вводим наш метод(или функцию, как в питоне) cntrl+c -> cntrl v с презентации.
        public static int FindLucky(int[] arr)
        {
            //делаем сортировку, чтобы одинаковые число стояли рядом.
            Array.Sort(arr);
            int result = -1;
            // 
            int slow = 0;
            //список от 0 до конца массива(длинна тут в arr.Length)
            while (slow < arr.Length)
            {
                //fast и slow на 0 индексе.
                int fast = slow;

                // цикл по перебору чисел. Сравниваем число 1 индекса(fast) и 0(slow)
                while (fast < arr.Length && arr[fast] == arr[slow])
                {
                    // двигаем fast дальше на +1 по индексу.
                    fast++;
                }

                // Количество повторений числа( в моем примере fast = 2, а slow = 0)
                int count = fast - slow;

                // сравниваем кол-во чисел с числом взятое по индексу через slow.
                if (count == arr[slow])
                {
                    result = arr[slow]; // Так как массив растет, последнее найденное будет макс.
                }

                // не нашли? идем некст
                slow = fast;
            }
            // прикольдес, чтобы объяснить, что в массиве нет счастливого числа.
            if (result == -1)
            {
               Console.WriteLine("Нету такого числа, так что выведем твой уровень IQ:");
               return result;
            }
            // на случай, если пользователь умный.
            else
            {
                return result;
            }
               
        }
    }
}