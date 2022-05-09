
using LudoApplication.GameItems;
using LudoApplication.Players;
using System;
using System.Collections.Generic;

namespace LudoApplication.GameApplication
{
    public class Game
    {
        const int NUMBER_OF_PLAYERS = 4;
        private Gameboard gb;
        private IList<Player> players;
        private Die die;
        private int turn;

        public Game()
        {
            gb = new Gameboard();
            players = new List<Player>();
            players.Add(new Player(gb, "green", 0));
            players.Add(new Player(gb, "red", 0));
            players.Add(new Player(gb, "blue", 0));
            players.Add(new Player(gb, "yellow", 0));
            die = new Die(6);
            turn = 0;
        }

        public void InitialRoll()
        {
            /*
             * Press enter to roll the die
             */
            int initRoll = int.MinValue;
            for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
            {
                Console.WriteLine("Press enter to roll the die");
                Console.ReadLine();
                int dieRoll = die.Roll();

                Console.WriteLine($"You rolled a: {dieRoll}.");
                if (dieRoll > initRoll)
                {
                    initRoll = dieRoll;
                    turn = i;
                }
            }

            Console.WriteLine($"Player {turn + 1} to start.");
        }

        public void MainGame()
        {
            while (true)
            {
                TokenToMove(out int tokenChoice, out Player p, out Token t);
                int moves = die.Roll();

                if (t.Home)
                {
                    p.MoveToken(tokenChoice, moves, GameRules.AbleToMoveOut(die, moves) && GameRules.Moveable(t, moves, gb));
                }
                else
                {
                    p.MoveToken(tokenChoice, moves, GameRules.Moveable(t, moves, gb));
                }


            }
        }

        public void TokenToMove(out int tokenChoice, out Player p, out Token t)
        {
            Console.WriteLine("Choose token to move: ");
            tokenChoice = int.Parse(Console.ReadLine());
            p = players[PlayerTurn(turn)];
            t = p.Tokens[tokenChoice];
        }

        public static int PlayerTurn(int turn)
        {
            return turn % 4;
        }
    }
}
