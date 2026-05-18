namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            // имя участника
            private string name;
            // фамилия участника
            private string surname;
            // массив очков за партии
            private double[] scores;
          
            public string Name => name;
            public string Surname => surname;
            public double[] Scores => scores;

            // сумма всех очков
            public double TotalScore
            {
                get
                {
                    if (scores == null)
                        return 0;

                    double sum = 0;

                    foreach (double score in scores)
                    {
                        sum += score;
                    }

                    return sum;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;

                scores = new double[0];
            }

            // добавляет результат новой партии
            public void PlayMatch(double result)
            {
                if (scores == null)
                    scores = new double[0];

                Array.Resize(ref scores, scores.Length + 1);
                scores[scores.Length - 1] = result;
            }

            // сортировка по убыванию общего количества очков
            public static void Sort(Participant[] array)
            {
                Array.Sort(array,
                    (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Name} {Surname} " +
                    $"{TotalScore}");
            }
        }
    }
}
