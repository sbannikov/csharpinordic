using System;

namespace Queens
{
    class Program
    {
        // Положение ферзей по вертикали от 0 до 7
        static int[] queens = new int[8];

        /// <summary>
        /// Перемещение n-го ферзя
        /// </summary>
        /// <param name="n">Номер ферзя</param>
        static void Move(int n)
        {
            for (int col = 0; col < 8; col++)
            {
                queens[n] = col;
                if (n < 7)
                {
                    Move(n + 1);
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write(queens[i]);
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            // Move(0);

            // Цикл по первому ферзю
            for (int q1 = 0; q1 < 8; q1++)
            {
                queens[0] = q1;

                // Цикл по второму ферзю
                for (int q2 = 0; q2 < 8; q2++)
                {
                    queens[1] = q2;

                    // отсекаем комбинации, когда ферзи стоят по одной вертикали
                    if (queens[0] == queens[1]) { continue; }

                    // отсекаем комбинации, когда ферзи стоят по одной диагонали
                    if (Math.Abs(queens[0] - queens[1]) == 1) { continue; }

                    // Цикл по третьему ферзю
                    for (int q3 = 0; q3 < 8; q3++)
                    {
                        queens[2] = q3;

                        // отсекаем комбинации, когда ферзи стоят по одной вертикали
                        if (queens[0] == queens[2]) { continue; }
                        if (queens[1] == queens[2]) { continue; }

                        // отсекаем комбинации, когда ферзи стоят по одной диагонали
                        if (Math.Abs(queens[0] - queens[2]) == 2) { continue; }
                        if (Math.Abs(queens[1] - queens[2]) == 1) { continue; }


                        // Вывести содержимое массива на экран
                        for (int i = 0; i < 8; i++)
                        {
                            Console.Write($"{queens[i]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
