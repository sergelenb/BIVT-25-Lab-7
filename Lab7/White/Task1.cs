namespace Lab7.White
{
    public class Task1
    {
             public struct Participant
        {
            // фамилия участника
            private string surname;
            // клуб участника
            private string club;
            // первый прыжок
            private double firstJump;
            // второй прыжок
            private double secondJump;
            // сколько прыжков уже записано
            private int jumpCount;
       
            public string Surname => surname;
            public string Club => club;
            public double FirstJump => firstJump;
            public double SecondJump => secondJump;

            // сумма двух прыжков
            public double JumpSum => firstJump + secondJump;
            // конструктор
            public Participant(string surname, string club)
            {
                this.surname = surname;
                this.club = club;

                firstJump = 0;
                secondJump = 0;

                jumpCount = 0;
            }

            // записывает результаты прыжков
            // только первые 2 попытки
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

                // если прыжков уже 2 —
                // новые значения не записываются
            }

            // сортировка по убыванию суммы прыжков
            public static void Sort(Participant[] array)
            {
                Array.Sort(array,
                    (a, b) => b.JumpSum.CompareTo(a.JumpSum));
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Surname} {Club} " +
                    $"{FirstJump} {SecondJump} " +
                    $"{JumpSum}");
            }
        }
            
    }
}
