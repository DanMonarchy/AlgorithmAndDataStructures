namespace App1Bebra
{
    internal class Program
    {
        // Объясняем для тех, у кого есть памятник Пушкина во дворе.
        static void Main()
        {
            string stroka1 = "aab";
            string stroka2 = "baaac";
            //костыль, чтобы 2 метод был без staic
            Program myProg = new Program();
            //теперь мы можем спокойно использовать нашу функцию/метод/класс хз ваще что это такое.
            bool result = myProg.CanConstruct(stroka1, stroka2);
            //выводим эту штуку
            Console.WriteLine(result);

        }
        // метод или класс или че эта ваще
        public bool CanConstruct(string ransomNote, string magazine)
        {
            // превращаем строки в массивы символов, чтобы потом их отсортировать и сравнить
            char[] ransomChar = ransomNote.ToCharArray();
            char[] magazineChar = magazine.ToCharArray();
            // сортируем эти массивы, чтобы потом их сравнить
            Array.Sort(ransomChar);
            Array.Sort(magazineChar);
            //
            int i = 0;
            // 
            int j = 0;
            // пока не дошли до конца одной из строк, сравниваем буковки.
            while (i < ransomChar.Length && j < magazineChar.Length)
            {
                // ЕСЛИ СОВПАЛО - УРА ПОБЕДА!
                if (ransomChar[i] == magazineChar[j])
                {
                    i++; // идем дальше по первой строке, так как нашли совпадение
                    j++; // идем дальше по второй строке, так как нашли совпадение
                }
                // Если буква в журнале "меньше" по алфавиту, чем нужная мне 
                else if (ransomChar[i] > magazineChar[j])
                {
                    // Идем дальше по списку, так как там может быть нужная буква
                    j++;
                }
                //
                else
                {
                    return false; 
                }
            }
            // Если мы дошли до конца первой строки, значит все буквы были найдены в журнале.
            return i == ransomChar.Length;
        }
    }
}