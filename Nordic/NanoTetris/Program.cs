using System;

namespace NanoTetris
{
    class Program
    {
        /// <summary>
        /// Матрица игрового поля (двумерный массив)
        /// <para>первый индекс - X (горизонталь) - измерение 0</para>
        /// <para>второй индекс - Y (вертикаль) - измерение 1</para>
        /// </summary>
        static ConsoleColor[,] field;

        /// <summary>
        /// Количество очков
        /// </summary>
        static int Score = 0;

        /// <summary>
        /// Ячейка игрового поля
        /// </summary>
        const string Cell = "[.]";

        /// <summary>
        /// Вывод количества очков
        /// </summary>
        static void DrawScore()
        {
            Console.CursorLeft = (field.GetUpperBound(0) + 2) * Cell.Length;
            Console.CursorTop = 0;
            Console.Write($"SCORE: {Score}");
        }

        /// <summary>
        /// Отображение одной клетки поля
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        static void DrawCell(int x, int y)
        {
            ConsoleColor oldBack = Console.BackgroundColor;
            ConsoleColor oldFore = Console.ForegroundColor;
            Console.CursorLeft = x * Cell.Length;
            Console.CursorTop = y;
            Console.BackgroundColor = field[x, y];
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Cell);
            Console.BackgroundColor = oldBack;
            Console.ForegroundColor = oldFore;
        }

        /// <summary>
        /// Задать значение клетки поля и нарисовать
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="color">Цвет клетки</param>
        static void SetCell(int x, int y, ConsoleColor color)
        {
            field[x, y] = color;
            DrawCell(x, y);
        }

        /// <summary>
        /// Проверка на заполнение последней строки
        /// </summary>
        /// <returns>true, если последняя строка заполнена</returns>
        static bool IsFilled()
        {
            int y = field.GetUpperBound(1);

            bool flag = true; // можно без этой переменной
            for (int x = 0; x <= field.GetUpperBound(0); x++)
            {
                if (field[x, y] == ConsoleColor.Black)
                {
                    flag = false; // return false; 
                    break; // можно удалить, но эффективность снижается
                }
            }

            return flag; // return true;
        }

        /// <summary>
        /// Удаление последней строки и сдвиг вниз игрового поля
        /// </summary>
        static void Shift(int toDelete)
        {
            // Подсчёт очков
            // за каждый кубик количество очков, равное его "цвету"
            for (int x = 0; x <= field.GetUpperBound(0); x++)
            {
                Score += (int)field[x, toDelete];
            }

            // Это если каждый кубик - одно очко
            // Score += field.GetUpperBound(1);

            // Обрабатываются строки с предпоследней по первую
            for (int x = 0; x <= field.GetUpperBound(0); x++)
            {
                for (int y = toDelete; y >= 0; y--)
                {
                    SetCell(x, y + 1, field[x, y]);
                }
                // Покрасить самую верхнюю клетку чёрным
                SetCell(x, 0, ConsoleColor.Black);
            }
        }

        static void Main(string[] args)
        {
            string message = null;
            try
            {
                // Двумерный массив (матрица)
                // первый индекс - X (горизонталь) - измерение 0
                // второй индекс - Y (вертикаль) - измерение 1
                field = new ConsoleColor[6, 10];
                // Генератор случайных чисел
                var random = new Random();

                // Формирование поля
                for (int x = 0; x <= field.GetUpperBound(0); x++)
                {
                    for (int y = 0; y <= field.GetUpperBound(1); y++)
                    {
                        DrawCell(x, y);
                    }
                }

                DrawScore();

                // Жду нажатия кнопки
                ConsoleKeyInfo key = Console.ReadKey(true);

                int CurrentX = 0; // координата кубика
                int CurrentY = 0; // координата кубика
                                  // цвет кубика
                ConsoleColor CurrentColor = ConsoleColor.Black;
                bool finish = false;

                while (!finish)
                {
                    // Обработчик кнопок
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            finish = true; // выход из программы по кнопке
                            break;

                        case ConsoleKey.Spacebar:
                        case ConsoleKey.DownArrow:
                            if (CurrentColor == ConsoleColor.Black)
                            {
                                // Генерация координаты нового кубика
                                CurrentX = random.Next(field.GetLowerBound(0), field.GetUpperBound(0));
                                CurrentY = 0;
                                if (field[CurrentX, CurrentY] != ConsoleColor.Black)
                                {
                                    // полностью заполнена вертикаль, проигрыш
                                    finish = true;
                                    // Вариант - выброс исключения для передачи управления
                                    // throw new Exception("Игра окончена");
                                }
                                else
                                {
                                    // формируем случайный цвет, кроме белого и чёрного
                                    CurrentColor = (ConsoleColor)random.Next(1, 15);
                                    SetCell(CurrentX, CurrentY, CurrentColor);
                                }
                            }
                            else if (CurrentY < field.GetUpperBound(1) && field[CurrentX, CurrentY + 1] == ConsoleColor.Black)
                            {
                                SetCell(CurrentX, CurrentY, ConsoleColor.Black);
                                SetCell(CurrentX, ++CurrentY, CurrentColor);
                            }
                            else
                            {
                                CurrentColor = ConsoleColor.Black;
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            // проверяем, что кубик есть,
                            // что не самая левая вертикаль
                            // и что есть куда двигаться влево (нет других кубиков)
                            if (CurrentColor != ConsoleColor.Black
                                && CurrentX > 0
                                && field[CurrentX - 1, CurrentY] == ConsoleColor.Black)
                            {
                                SetCell(CurrentX, CurrentY, ConsoleColor.Black);
                                SetCell(--CurrentX, CurrentY, CurrentColor);
                            }
                            else
                            {
                                Console.Beep();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (CurrentColor != ConsoleColor.Black && CurrentX < field.GetUpperBound(0) && field[CurrentX + 1, CurrentY] == ConsoleColor.Black)
                            {
                                SetCell(CurrentX, CurrentY, ConsoleColor.Black);
                                SetCell(++CurrentX, CurrentY, CurrentColor);
                            }
                            else
                            {
                                Console.Beep();
                            }
                            break;
                        default:
                            Console.Beep();
                            break;
                    }

                    // В конце цикла снова ждём нажатия кнопки
                    if (!finish)
                    {
                        key = Console.ReadKey(true);
                    }

                    if (IsFilled())
                    {
                        // Удаление предпоследней строки
                        Shift(field.GetUpperBound(1) - 1);
                        DrawScore();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                Console.CursorLeft = 0;
                Console.CursorTop = field.GetUpperBound(1) + 2;
                if (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}
