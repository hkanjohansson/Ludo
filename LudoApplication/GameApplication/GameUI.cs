using LudoApplication.GameItems;
using LudoApplication.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace LudoApplication.GameApplication
{
    public static class GameUI
    {
        /*
         * TODO - Refactor code that is duplicated.
         *      - Create an area for the players tokens.
         *      - Show the die rolls for a player. 
         *      - Make the application more user friendly by giving proper instructions.
         */
        public static void PrintUI(Gameboard gb, IList<Player> players)
        {
            StringBuilder sb = new();
            sb.Append("                ");
            CreateRow(gb, sb, 11, 13);
            sb.Append("                \n");
            CreateRowWithHomefield(gb, players[1], sb, 10, 14, 0);
            CreateRowWithHomefield(gb, players[1], sb, 9, 15, 1);
            CreateRowWithHomefield(gb, players[1], sb, 8, 16, 2);
            CreateRowWithHomefield(gb, players[1], sb, 7, 17, 3);
            CreateRowWithHomefield(gb, players[1], sb, 6, 18, 4);
            CreateRow(gb, sb, 0, 5);
            sb.Append("  F   ");
            CreateRow(gb, sb, 20, 25);
            sb.Append('\n');
            CreateRow(gb, sb, 51, 51);
            CreateHomeField(players[0], sb, 0);
            CreateHomeField(players[0], sb, 1);
            CreateHomeField(players[0], sb, 2);
            CreateHomeField(players[0], sb, 3);
            CreateHomeField(players[0], sb, 4);
            sb.Append(" F ");
            sb.Append("F  ");
            CreateHomeField(players[2], sb, 0);
            CreateHomeField(players[2], sb, 1);
            CreateHomeField(players[2], sb, 2);
            CreateHomeField(players[2], sb, 3);
            CreateHomeField(players[2], sb, 4);
            CreateRow(gb, sb, 26, 26);
            sb.Append('\n');
            CreateRow(gb, sb, 50, 45);
            sb.Append("  F   ");
            
            CreateRow(gb, sb, 31, 26);
            sb.Append('\n');
            CreateRowWithHomefield(gb, players[3], sb, 44, 32, 4);
            CreateRowWithHomefield(gb, players[3], sb, 43, 33, 3);
            CreateRowWithHomefield(gb, players[3], sb, 42, 34, 2);
            CreateRowWithHomefield(gb, players[3], sb, 41, 35, 1);
            CreateRowWithHomefield(gb, players[3], sb, 40, 36, 0);
            sb.Append("                ");
            CreateRow(gb, sb, 39, 37);
            Console.WriteLine(sb.ToString());
        }

        private static void CreateRowWithHomefield(Gameboard gb, Player p, StringBuilder sb, int leftIndex, int rightIndex, int homeIndex)
        {
            sb.Append("                ");
            if (gb.Board[leftIndex] == '\0')
            {
                sb.Append(" O ");
            }
            else
            {
                sb.Append($"{char.ToUpper(gb.Board[leftIndex])}");
            }

            CreateHomeField(p, sb, homeIndex);

            if (gb.Board[rightIndex] == '\0')
            {
                sb.Append(" O ");
            }
            else
            {
                sb.Append($" {char.ToUpper(gb.Board[rightIndex])} ");
            }

            sb.Append("                ");
            sb.Append('\n');
        }

        private static void CreateHomeField(Player p, StringBuilder sb, int homeIndex)
        {
            if (p.HomeField != homeIndex)
            {
                sb.Append(" X ");
            }
            else
            {
                sb.Append($" {char.ToUpper(p.ColourOfTokens[0])} ");
            }
        }

        private static void CreateRow(Gameboard gb, StringBuilder sb, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                Console.WriteLine("Hej hej hej");
                for (int i = startIndex; i >= endIndex; i--)
                {
                    Console.WriteLine(i);
                    if (gb.Board[i] == '\0')
                    {
                        sb.Append(" O ");
                    }
                    else
                    {
                        sb.Append($" {char.ToUpper(gb.Board[i])} ");
                    }

                }
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (gb.Board[i] == '\0')
                    {
                        sb.Append(" O ");
                    }
                    else
                    {
                        sb.Append($" {char.ToUpper(gb.Board[i])} ");
                    }

                }
            }



        }


    }


}
