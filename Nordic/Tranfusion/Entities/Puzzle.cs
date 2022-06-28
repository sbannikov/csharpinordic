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

        public bool Solve()
        {
            // Построение множества возможных состояний
            var state = States.First(x => x.StateType == Enums.StateType.Start);
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

            bool solved = States.Where(x => x.StateType != Enums.StateType.Finish).Any(x => x.IsFinal());
            return solved;

        }
    }
}
