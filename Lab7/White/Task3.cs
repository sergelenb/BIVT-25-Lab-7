using System.Collections;

namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            // имя студента
            private string name;
            // фамилия студента
            private string surname;
            // массив оценок без нулей
            private int[] marks;
            // количество пропусков
            private int skipped;
           
            public string Name => name;
            public string Surname => surname;
            public int Skipped => skipped;

            // средняя оценка по предмету
            public double AverageMark
            {
                get
                {
                    if (marks == null || marks.Length == 0)
                        return 0;

                    int sum = 0;

                    foreach (int mark in marks)
                    {
                        sum += mark;
                    }

                    return (double)sum / marks.Length;
                }
            }

            // конструктор
            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;

                marks = new int[0];
                skipped = 0;
            }

            // добавляет оценку или пропуск
            public void Lesson(int mark)
            {
                // 0 — это пропуск
                if (mark == 0)
                {
                    skipped++;
                }
                else
                {
                    // если оценка не 0, добавляем её в массив
                    if (marks == null)
                        marks = new int[0];

                    Array.Resize(ref marks, marks.Length + 1);
                    marks[marks.Length - 1] = mark;
                }
            }

            // сортировка по убыванию пропусков
            public static void SortBySkipped(Student[] array)
            {
                Array.Sort(array,
                    (a, b) => b.Skipped.CompareTo(a.Skipped));
            }

            // вывод информации
            public void Print()
            {
                Console.WriteLine(
                    $"{Name} {Surname} " +
                    $"{AverageMark:F2} " +
                    $"{Skipped}");
            }
        }
    }
}
