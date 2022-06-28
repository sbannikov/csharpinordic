using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Entities
{
    public class State
    {
        /// <summary>
        /// Тип состояния
        /// </summary>
        public Enums.StateType StateType { get; set; }

        /// <summary>
        /// Уровень жидкости в каждом кувшине
        /// Кувшин определяется номером
        /// </summary>
        public Dictionary<int, int?> Jars { get; set; } = new Dictionary<int, int?>();

        /// <summary>
        /// Головоломка, к которой относится состояние
        /// </summary>
        public Puzzle Puzzle { get; set; }

        /// <summary>
        /// Признак обработки состояния
        /// </summary>
        public bool Processed { get; set; } = false;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public State() { }

        /// <summary>
        /// Создание состояния после хода
        /// </summary>
        /// <param name="oldState">Исходное состояние</param>
        /// <param name="turn">Ход</param>
        /// <exception cref="ApplicationException"></exception>
        public State(State oldState, Turn turn)
        {
            StateType = Enums.StateType.Intermediate;
            Puzzle = oldState.Puzzle;
            // Копирование содержимого словаря в пустой словарь
            foreach (var jar in oldState.Jars)
            {
                Jars.Add(jar.Key, jar.Value);
            }
            // Сколько налито в кувшине "откуда" - сколько надо перелить
            int n1 = Jars[turn.FromJar].Value;
            // Сколько можно налить в кувшин "туда"
            int n2 = Puzzle.Jars[turn.ToJar].Size - Jars[turn.ToJar].Value;
            // Если кувшин "туда" почему-то полный
            if (n2 == 0)
            {
                throw new ApplicationException("Кувшин-приёмник полный");
            }
            if (n1 > n2) // неполное переливание
            {
                Jars[turn.FromJar] -= n2;
                Jars[turn.ToJar] += n2;
            }
            else // полное переливание
            {
                Jars[turn.FromJar] -= n1;
                Jars[turn.ToJar] += n1;
            }
        }

        /// <summary>
        /// Формирование множества возможных ходов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Turn> PossibleTurns()
        {
            foreach (var fromJar in Jars.Keys)
            {
                foreach (var toJar in Jars.Keys)
                {
                    // Нельзя переливать из кувшина в него же
                    if (fromJar == toJar) continue;
                    // Нельзя переливать из пустого кувшина
                    if (Jars[fromJar].Value == 0) continue;
                    // Нельзя переливать в полный кувшин
                    if (Jars[toJar].Value == Puzzle.Jars[toJar].Size) continue;
                    // Похоже, это легитимный ход
                    yield return new Turn()
                    {
                        FromState = this,
                        FromJar = fromJar,
                        ToJar = toJar,
                    };
                }
            }
        }

        /// <summary>
        /// Создание новых состояний, в которые мы можем попасть из текущего
        /// </summary>
        public void MakeTurns()
        {
            foreach (var turn in PossibleTurns())
            {
                var newState = new State(this, turn);
                turn.ToState = newState;
                Puzzle.States.Add(newState);
                Puzzle.Turns.Add(turn);
            }
            Processed = true;
        }

        /// <summary>
        /// Проверка на финальное состояние
        /// </summary>
        /// <returns></returns>
        public bool IsFinal()
        {
            var final = Puzzle.States.First(x => x.StateType == Enums.StateType.Finish);
            foreach (int number in Jars.Keys)
            {
                if ((Jars[number] != final.Jars[number]) && final.Jars[number].HasValue)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Строковое представление состояния
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(':', Jars.Values.Select(x => x.ToString()));
        }
    }
}
