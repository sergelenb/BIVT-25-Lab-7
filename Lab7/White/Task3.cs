namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            private string name;
            private string surname;
            private int[] marks;
            private int skipped;
            private int markCount;

            public string Name => name;
            public string Surname => surname;
            public int Skipped => skipped;

            public double AverageMark
            {
                get
                {
                    if (marks == null || markCount == 0)
                        return 0;

                    int sum = 0;

                    for (int i = 0; i < markCount; i++)
                    {
                        sum += marks[i];
                    }

                    return (double)sum / markCount;
                }
            }

            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;

                marks = new int[10];
                skipped = 0;
                markCount = 0;
            }

            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    skipped++;
                }
                else
                {
                    if (marks == null)
                        marks = new int[10];

                    if (markCount < marks.Length)
                    {
                        marks[markCount] = mark;
                        markCount++;
                    }
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                Array.Sort(array,
                    (a, b) => b.Skipped.CompareTo(a.Skipped));
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AverageMark:F2} {Skipped}");
            }
        }
    }
}
