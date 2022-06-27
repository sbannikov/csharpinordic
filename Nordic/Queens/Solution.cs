using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    /// <summary>
    /// Решение задачи n ферзей
    /// </summary>
    public class Solution
    {
        private int size;

        /// <summary>
        /// Положение ферзей по вертикали от 0 до <see cref="Size"/>
        /// </summary>
        private int[] queens;

        /// <summary>
        /// Проверка, что n-ферзь под ударом одного из предыдущих
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool Checked(int n)
        {
            for (int i = 0; i < n; i++)
            {
                // отсекаем комбинации, когда ферзи стоят по одной вертикали
                if (queens[n] == queens[i]) { return true; }

                // отсекаем комбинации, когда ферзи стоят по одной диагонали
                if (Math.Abs(queens[n] - queens[i]) == (n - i)) { return true; }
            }
            return false;
        }

        public IEnumerable<int[]> Move(int n)
        {
            for (int col = 0; col < size; col++)
            {
                queens[n] = col;               

                // Проверка на корректность расположения ферзей
                if (n > 0)
                {
                    if (Checked(n))
                    {
                        continue;
                    }
                }

                if (n < size - 1)
                {
                    foreach (var item in Move(n + 1))
                    {
                        yield return item;
                    }
                }
                else
                {
                    // обязательно копируем массив, чтобы массив queens не испортили
                    int[] copy = new int[queens.Length];
                    Array.Copy(queens, copy, queens.Length);
                    yield return copy;
                }
            }
        }

        /// <summary>
        /// Решение задачи n ферзей
        /// </summary>
        /// <param name="n"></param>
        public Solution(int n)
        {
            size = n;
            queens = new int[size];
        }
    }
}
