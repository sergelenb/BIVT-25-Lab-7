namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            // имя шахматиста
            private string name;
            // фамилия шахматиста
            private string surname;
            // массив очков за партии
            private double[] scores;
            // сколько матчей уже записано
            private int matchCount;
            // свойства только для чтения
            public string Name => name;
            public string Surname => surname;
            // массив результатов
            public double[] Scores => scores;
            // сумма всех очков
            public double TotalScore
            {
                get
                {
                    // защита от null
                    if (scores == null)
                        return 0;

                    double sum = 0;

                    // считаем сумму очков
                    foreach (double score in scores)
                    {
                        // -1 означает пустую ячейку
                        if (score != -1)
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

                // создаём массив на 10 партий
                scores = new double[10];

                // заполняем -1
                // чтобы тесты понимали,
                // что партия ещё не сыграна
                for (int i = 0; i < scores.Length; i++)
                {
                    scores[i] = -1;
                }

                matchCount = 0;
            }

            // добавляет результат партии
            public void PlayMatch(double result)
            {
                // защита от null
                if (scores == null)
                {
                    scores = new double[10];

                    for (int i = 0; i < scores.Length; i++)
                    {
                        scores[i] = -1;
                    }
                }

                // добавляем только если есть место
                if (matchCount < scores.Length)
                {
                    scores[matchCount] = result;
                    matchCount++;
                }
            }

            // сортировка по убыванию очков
            public static void Sort(Participant[] array)
            {
                Array.Sort(array,
                    (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Name} {Surname} {TotalScore}");
            }
        }
    }
}
