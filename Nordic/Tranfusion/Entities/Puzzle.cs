using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Entities
{
    /// <summary>
    /// Головоломка
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// Словарь кувшинов
        /// </summary>
        public Dictionary<int, Jar> Jars = new Dictionary<int, Jar>();

        /// <summary>
        /// Множество возможных состояния
        /// </summary>
        public HashSet<State> States { get; set; } = new HashSet<State>();

        /// <summary>
        /// Множество ходов
        /// </summary>
        public HashSet<Turn> Turns { get; set; } = new HashSet<Turn>();

        /// <summary>
        /// Добавление состояния в головоломку
        /// </summary>
        /// <param name="state"></param>
        public void AddState(State state)
        {
            state.Puzzle = this;
            States.Add(state);
        }

        public void Solve()
        {
            var state = States.First(x => x.StateType == Enums.StateType.Start);

            foreach (var turn in state.PossibleTurns())
            {
                var newState = new State(state, turn);
                States.Add(newState);
                Turns.Add(turn);
            }
        }
    }
}
