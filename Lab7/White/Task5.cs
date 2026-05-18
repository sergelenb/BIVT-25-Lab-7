namespace Lab7.White
{
    public class Task5
    {
       public struct Match
        {
            // забитые голы
            private int goals;
            // пропущенные голы
            private int misses;
            // свойства только для чтения
            public int Goals => goals;
            public int Misses => misses;
            // разница голов
            public int Difference => goals - misses;
            // очки за матч
            public int Score
            {
                get
                {
                    // победа
                    if (goals > misses)
                        return 3;

                    // ничья
                    if (goals == misses)
                        return 1;

                    // поражение
                    return 0;
                }
            }

            // конструктор
            public Match(int goals, int misses)
            {
                this.goals = goals;
                this.misses = misses;
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Goals}:{Misses} " +
                    $"{Difference} " +
                    $"{Score}");
            }
        }

        public struct Team
        {
            // название команды
            private string name;

            // массив матчей
            private Match[] matches;

            // свойства только для чтения
            public string Name => name;
            public Match[] Matches => matches;

            // общая разница голов
            public int TotalDifference
            {
                get
                {
                    if (matches == null)
                        return 0;

                    int sum = 0;

                    foreach (Match match in matches)
                    {
                        sum += match.Difference;
                    }

                    return sum;
                }
            }

            // общее количество очков
            public int TotalScore
            {
                get
                {
                    if (matches == null)
                        return 0;

                    int sum = 0;

                    foreach (Match match in matches)
                    {
                        sum += match.Score;
                    }

                    return sum;
                }
            }

            // конструктор
            public Team(string name)
            {
                this.name = name;

                matches = new Match[0];
            }

            // добавляет новый матч
            public void PlayMatch(int goals, int misses)
            {
                if (matches == null)
                    matches = new Match[0];

                Array.Resize(ref matches, matches.Length + 1);

                matches[matches.Length - 1] =
                    new Match(goals, misses);
            }

            // сортировка команд
            public static void SortTeams(Team[] teams)
            {
                Array.Sort(teams, (a, b) =>
                {
                    // сначала сравниваем очки
                    int scoreCompare =
                        b.TotalScore.CompareTo(a.TotalScore);

                    if (scoreCompare != 0)
                        return scoreCompare;

                    // если очки равны —
                    // сравниваем разницу голов
                    return b.TotalDifference
                        .CompareTo(a.TotalDifference);
                });
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Name} " +
                    $"{TotalScore} " +
                    $"{TotalDifference}");
            }
        }
    }
}
