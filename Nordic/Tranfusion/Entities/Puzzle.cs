using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Entities
{
    /// <summary>
    /// Головоломка
    /// </summary>
    public class Puzzle : IEqualityComparer<State>
    {
        /// <summary>
        /// Словарь кувшинов
        /// </summary>
        public Dictionary<int, Jar> Jars = new Dictionary<int, Jar>();

        /// <summary>
        /// Множество возможных состояния
        /// </summary>
        public HashSet<State> States { get; set; }

        /// <summary>
        /// Множество ходов
        /// </summary>
        public HashSet<Turn> Turns { get; set; } = new HashSet<Turn>();

        public Puzzle()
        {
            States = new HashSet<State>(this);
        }

        /// <summary>
        /// Добавление состояния в головоломку
        /// </summary>
        /// <param name="state"></param>
        public void AddState(State state)
        {
            state.Puzzle = this;
            States.Add(state);
        }

        /// <summary>
        /// Сравнение состояний на равенство
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(State? x, State? y)
        {
            foreach (int number in x.Jars.Keys)
            {
                if (x.Jars[number] != y.Jars[number])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode([DisallowNull] State obj)
        {
            int hash = 0;
            foreach (var item in obj.Jars.Values)
            {
                hash = hash ^ item.GetHashCode();
            }
            return hash;
        }

        /// <summary>
        /// Начальное состояние головоломки
        /// </summary>
        public Entities.State StartingState => 
            States.First(x => x.StateType == Enums.StateType.Start);

        /// <summary>
        /// Рекурсивый перебор всех возможных ходов с контролем циклов
        /// (возврат в состояние, в котором мы уже были)
        /// </summary>
        /// <param name="state">Текущее состояние</param>
        /// <param name="stack">Стек сделанных ходов</param>
        /// <returns></returns>
        private bool PerformTurns(Entities.State state, Stack<Entities.Turn> stack)
        {
            // Все ходы из текущего состояния
            var outgoing = Turns.Where(x => x.FromState == state).ToList();
            foreach (var turn in outgoing)
            {
                // Проверка на вхождение в состояние, где мы уже были
                if (stack.Any(x => x.FromState == turn.ToState)) continue;

                // Проверка на финальное состояние
                if (turn.ToState.IsFinal())
                { 
                    // Записываем последний ход
                    stack.Push(turn);
                    return true;
                }

                // Сохраняем сделанный ход
                stack.Push(turn);
                // Перебираем все новые варианты
                if (PerformTurns(turn.ToState, stack))
                {
                    return true;
                }
                // И если ничего не нашли, забываем, что мы тут были
                // Значит, нам сюда было не надо
                stack.Pop();
            }
            // Решение не найдено, печалька!
            return false;
        }

        /// <summary>
        /// Последовательность ходов, ведущих к решению
        /// </summary>
        /// <returns>Последовательность ходов или null, если нет решения</returns>
        public IEnumerable<Entities.Turn>? GetTurns()
        {
            var state = StartingState;
            var stack = new Stack<Entities.Turn>();
            if (PerformTurns(state, stack))
            {
                // Вернуть стек в обратном порядке
                return stack.Reverse().ToList();
            }
            return null;
        }

        /// <summary>
        /// Решение задачи
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entities.Turn>? Solve()
        {
            // Построение множества возможных состояний
            var state = StartingState;
            state.MakeTurns();
            do
            {
                state = States.FirstOrDefault(x => !x.Processed && x.StateType == Enums.StateType.Intermediate);
                if (state != null)
                {
                    state.MakeTurns();
                }
            }
            while (state != null);

            var result = GetTurns();
            return result;
        }
    }
}
