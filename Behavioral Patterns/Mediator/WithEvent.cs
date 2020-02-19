using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.WithEvent
{
    internal abstract class GameEventArgs : EventArgs
    {
        public abstract void Print();
    }

    internal class PlayerScoredEventArgs : GameEventArgs
    {
        public string PlayerName;
        public int GoalsScoredSoFar;

        public PlayerScoredEventArgs(string playerName, int goalsScoredSoFar)
        {
            PlayerName = playerName;
            GoalsScoredSoFar = goalsScoredSoFar;
        }

        public override void Print()
        {
            Console.WriteLine($"{PlayerName} has scored! their {GoalsScoredSoFar} goal");
        }
    }

    internal class Game
    {
        public event EventHandler<GameEventArgs> Events;

        public void Fire(GameEventArgs args)
        {
            Events?.Invoke(this, args);
        }
    }

    internal class Player
    {
        private string name;
        private int goalsScored = 0;
        private Game game;

        public Player(Game game, string name)
        {
            this.name = name;
            this.game = game;
        }

        public void Score()
        {
            goalsScored++;
            var args = new PlayerScoredEventArgs(name, goalsScored);
            game.Fire(args);
        }
    }

    internal class Coach
    {
        private Game game;

        public Coach(Game game)
        {
            this.game = game;
            game.Events += (sender, args) =>
            {
                if (args is PlayerScoredEventArgs scored && scored.GoalsScoredSoFar < 3)
                {
                    Console.WriteLine($"coach says: well done,{scored.PlayerName}");
                }
            };
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var game = new Game();
            var player = new Player(game, "Sam");
            var coach = new Coach(game);
            player.Score();
            player.Score();
            player.Score();
        }
    }
}