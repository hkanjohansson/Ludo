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
         */
        public static void PrintUI(Gameboard gb, IList<Player> players)
        {
            StringBuilder sb = new();
            TokenArea(players[0], 1, sb);
            CreateRow(gb, sb, 11, 13);
            TokenArea(players[1], 2, sb);
            sb.Append("                \n");
            CreateRowWithHomefield(gb, players[1], sb, 10, 14, 0);
            CreateRowWithHomefield(gb, players[1], sb, 9, 15, 1);
            CreateRowWithHomefield(gb, players[1], sb, 8, 16, 2);
            CreateRowWithHomefield(gb, players[1], sb, 7, 17, 3);
            CreateRowWithHomefield(gb, players[1], sb, 6, 18, 4);
            CreateRow(gb, sb, 0, 5);
            sb.Append("  F  ");
            CreateRow(gb, sb, 20, 25);
            sb.Append('\n');
            CreateRow(gb, sb, 51, 51);
            CreateHomeField(players[0], sb, 0, gb);
            CreateHomeField(players[0], sb, 1, gb);
            CreateHomeField(players[0], sb, 2, gb);
            CreateHomeField(players[0], sb, 3, gb);
            CreateHomeField(players[0], sb, 4, gb);
            sb.Append(" F ");
            sb.Append("F ");
            CreateHomeField(players[3], sb, 0, gb);
            CreateHomeField(players[3], sb, 1, gb);
            CreateHomeField(players[3], sb, 2, gb);
            CreateHomeField(players[3], sb, 3, gb);
            CreateHomeField(players[3], sb, 4, gb);
            CreateRow(gb, sb, 26, 26);
            sb.Append('\n');
            CreateRow(gb, sb, 50, 45);
            sb.Append("  F  ");
            
            CreateRow(gb, sb, 31, 26);
            sb.Append('\n');
            CreateRowWithHomefield(gb, players[2], sb, 44, 32, 4);
            CreateRowWithHomefield(gb, players[2], sb, 43, 33, 3);
            CreateRowWithHomefield(gb, players[2], sb, 42, 34, 2);
            CreateRowWithHomefield(gb, players[2], sb, 41, 35, 1);
            CreateRowWithHomefield(gb, players[2], sb, 40, 36, 0);
            TokenArea(players[2], 3, sb);
            CreateRow(gb, sb, 39, 37);
            TokenArea(players[3], 4, sb);

            sb.AppendLine();
            sb.AppendLine("Finished Tokens:");
            ShowFinishedTokens(players[0], 1, sb);
            ShowFinishedTokens(players[1], 2, sb);
            ShowFinishedTokens(players[2], 3, sb);
            ShowFinishedTokens(players[3], 4, sb);

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
                sb.Append($" {char.ToUpper(gb.Board[leftIndex])} ");
            }

            CreateHomeField(p, sb, homeIndex, gb);

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

        private static void CreateHomeField(Player p, StringBuilder sb, int homeIndex, Gameboard gb)
        {
            if (p.FinishArea[homeIndex] == 'X')
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
                for (int i = startIndex; i >= endIndex; i--)
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

        public static void TokenArea(Player p, int playerIndex, StringBuilder sb)
        {
            sb.Append($"Player{playerIndex}:");
            foreach (Token t in p.Tokens)
            {
                if (t != null && t.Home)
                {
                    sb.Append($"{char.ToUpper(t.Colour[0])} ");
                } else
                {
                    sb.Append("O ");
                }
            }

            
        }

        public static void ShowFinishedTokens(Player p, int playerId, StringBuilder sb)
        {
            sb.Append($"Player {playerId}: [ ");
            foreach (Token t in p.FinishedTokens)
            {
                sb.Append($"{char.ToUpper(t.Colour[0])}{t.Id} ");
            }

            sb.Append(" ]\n");
        }
    }
}
