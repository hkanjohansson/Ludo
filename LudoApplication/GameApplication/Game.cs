﻿
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
        private readonly IList<Player> players;
        private readonly Die die;
        private int turn;

        public Game()
        {
            gb = new Gameboard();
            players = new List<Player>
            {
                new Player(gb, "green", 0),
                new Player(gb, "red", 13),
                new Player(gb, "blue", 26),
                new Player(gb, "yellow", 39)
            };
            die = new Die(6);
            turn = 0;
        }

        public void InitialRoll()
        {
            /*
             * Press enter to roll the die
             */
            int[] initRoll = new int[4];
            for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
            {
                Console.WriteLine($"Player {i + 1}, press enter to roll the die: ");
                Console.ReadLine();
                int dieRoll = die.Roll();
                Console.WriteLine($"You rolled a: {dieRoll}\n");
                
                for (int j = 0; j < NUMBER_OF_PLAYERS; j++)
                {
                    if (i != j)
                    {
                        while (dieRoll == initRoll[j])
                        {
                            Console.WriteLine("Press enter to roll the die");
                            Console.ReadLine();
                            dieRoll = die.Roll();
                            Console.WriteLine($"You rolled a: {dieRoll}\n");
                        }
                    }
                    
                }
                
                
                if (dieRoll > initRoll[i])
                {
                    initRoll[i] = dieRoll;
                    turn = i;
                }

                
            }

            Console.WriteLine($"Player {turn + 1} to start.");
        }

        public void MainGame()
        {
            while (true)
            {
                Console.WriteLine($"\nPlayer {PlayerTurn(turn) + 1} turn to roll");
                Console.WriteLine("Press enter to roll the die: ");
                Console.ReadLine();
                int moves = die.Roll();
                Console.WriteLine($"You rolled: {moves}\n");

                TokenToMove(out int tokenChoice, out Player p, out Token t);


                if (t.Home)
                {
                    Console.WriteLine($"Able to move out: {GameRules.AbleToMoveOut(die, moves)}");
                    if (GameRules.AbleToMoveOut(die, moves) && GameRules.Moveable(t, moves, gb))
                    {
                        p.MoveToken(tokenChoice, moves, true);
                        t.Home = false;
                        t.Safe = false;
                    }
                }
                else
                {
                    p.MoveToken(tokenChoice, moves, GameRules.Moveable(t, moves, gb));
                }

                GameUI.PrintUI(gb, players);
                turn++;

            }
        }

        public void TokenToMove(out int tokenChoice, out Player p, out Token t)
        {
            Console.WriteLine("Choose token to move: ");
            string choice = Console.ReadLine();
            tokenChoice = ParseChoice(ref choice);
            TokenChoiceValidation(ref tokenChoice);
            p = players[PlayerTurn(turn)];
            t = p.Tokens[tokenChoice];
        }

        public int ParseChoice(ref string choice)
        {
            int tokenChoice;
            while (!int.TryParse(choice, out tokenChoice))
            {
                Console.WriteLine("Povide a valid choice of token. Valid choices are the integers 0, 1, 2 and 3. Choose token to move: ");
                choice = Console.ReadLine();
            }

            return tokenChoice;
        }

        public void TokenChoiceValidation(ref int tokenChoice)
        {
            while (tokenChoice < 0 || tokenChoice > 3)
            {
                Console.WriteLine("Povide a valid choice of token. Valid choices are the integers 0, 1, 2 and 3. Choose token to move: ");
                tokenChoice = int.Parse(Console.ReadLine());
            }
        }

        public static int PlayerTurn(int turn)
        {
            return turn % 4;
        }
    }
}
