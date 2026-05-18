namespace Lab7.White
{
    public class Task2
    {
           public struct Participant
        {
            // имя участника
            private string name;
            // фамилия участника
            private string surname;
            // первый прыжок
            private double firstJump;
            // второй прыжок
            private double secondJump;
            // сколько прыжков уже записано
            private int jumpCount;
      
            public string Name => name;
            public string Surname => surname;
            public double FirstJump => firstJump;
            public double SecondJump => secondJump;

            // лучший результат из двух прыжков
            public double BestJump => Math.Max(firstJump, secondJump);

            // конструктор
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;

                firstJump = 0;
                secondJump = 0;

                jumpCount = 0;
            }

            // записывает только первые 2 прыжка
            public void Jump(double result)
            {
                // первый прыжок
                if (jumpCount == 0)
                {
                    firstJump = result;
                    jumpCount++;
                }

                // второй прыжок
                else if (jumpCount == 1)
                {
                    secondJump = result;
                    jumpCount++;
                }

                // если уже есть 2 прыжка —
                // новые данные не записываются
            }

            // сортировка по убыванию лучшего результата
            public static void Sort(Participant[] array)
            {
                Array.Sort(array,
                    (a, b) => b.BestJump.CompareTo(a.BestJump));
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Name} {Surname} " +
                    $"{FirstJump} {SecondJump} " +
                    $"{BestJump}");
            }
        }
    }
}
