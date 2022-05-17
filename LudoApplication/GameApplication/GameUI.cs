using LudoApplication.GameItems;
using LudoApplication.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace LudoApplication.GameApplication
{
    public static class GameUI
    {
        public static void MainMenu()
        {
            Console.WriteLine("" +
                "\nWelcome to a game of Ludo!\n\n" +

                "This is a game of four players. Each player\ngets four tokens. " +
                "To be able to move out a token from the home\n" +
                "area, you have to roll a six. A valid choice of token is between " +
                "0 and 3. \n\n" +

                "The game starts by all four players roll the die and\n" +
                "the one with the highest roll get the initial move\n" +
                "and then the order is chronological.\n\n" +
                "You cannot move past an opponents token in the field,\n" +
                "but you can land on the same spot.If you land on\n" +
                "the same spot as an opponent, you send that token back " +
                "home.\n\n" +
                "When a token is about to finish. The last roll must result\n" +
                "in an exact match of how many moves that is left to finish.\n\n" +
                "That all for the rules of the game.\n\n" +
                "Press enter to start playing the game!\n");

            Console.ReadLine();
        }
        public static void PrintUI(Gameboard gb, IList<Player> players)
        {
            /*
             * The UI is created by printing row by row, and thereof will the players and numbers of
             * the field be a little bit mixed.  
             * 
             * The letter 'F' in the middle of the board. 
             */
            StringBuilder sb = new();
            TokenArea(players[0], 1, sb);
            CreateRow(gb, sb, 11, 13);
            TokenArea(players[1], 2, sb);
            sb.Append("                \n");
            for (int i = 0; i < 5; i++)
            {
                CreateRowWithFinishField(gb, players[1], sb, 10 - i, 14 + i, i);
            }

            CreateRow(gb, sb, 0, 5);
            sb.Append("  F  ");
            CreateRow(gb, sb, 19, 24);
            sb.Append('\n');
            CreateRow(gb, sb, 51, 51);

            for (int i = 0; i < 5; i++)
            {
                CreateFinishField(players[0], sb, i, gb);
            }

            sb.Append(" F ");
            sb.Append("F ");

            for (int i = 4; i >= 0; i--)
            {
                CreateFinishField(players[3], sb, i, gb);
            }

            CreateRow(gb, sb, 25, 25);
            sb.Append('\n');
            CreateRow(gb, sb, 50, 45);
            sb.Append("  F  ");

            CreateRow(gb, sb, 31, 26);
            sb.Append('\n');

            for (int i = 0; i < 5; i++)
            {
                CreateRowWithFinishField(gb, players[2], sb, 44 - i, 32 + i, 4 - i);
            }

            TokenArea(players[2], 3, sb);
            CreateRow(gb, sb, 39, 37);
            TokenArea(players[3], 4, sb);

            sb.AppendLine();
            sb.AppendLine("\nFinished Tokens and Token Positions:");
            for (int i = 0; i < 4; i++)
            {
                ShowFinishedTokens(players[i], i + 1, sb);
                ShowTokensPositions(players[i], i + 1, sb);
                sb.Append('\n');
            }

            Console.WriteLine(sb.ToString());
        }

        private static void CreateRowWithFinishField(Gameboard gb, Player p, StringBuilder sb, int leftIndex, int rightIndex, int homeIndex)
        {
            /*
             * Appending a spot from the gameboard, finish area and another spot from the gameboard.
             */
            sb.Append("                ");
            if (gb.Board[leftIndex] == '\0')
            {
                sb.Append(" O ");
            }
            else
            {
                sb.Append($" {char.ToUpper(gb.Board[leftIndex])} ");
            }

            CreateFinishField(p, sb, homeIndex, gb);

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

        private static void CreateFinishField(Player p, StringBuilder sb, int homeIndex, Gameboard gb)
        {
            /*
             * Appending a spot from the finishing area.
             */
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
            /*
             * Appending a regular row from the gameboard.
             */
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
                if (t.Home)
                {
                    sb.Append($"{char.ToUpper(t.Colour[0])} ");
                }
                else
                {
                    sb.Append("O ");
                }
            }
        }

        public static void ShowTokensPositions(Player p, int playerId, StringBuilder sb)
        {
            sb.Append($"\t [ ");
            foreach (Token t in p.Tokens)
            {
                sb.Append($"{char.ToUpper(t.Colour[0])}{t.Id}: {t.Position}  ");
            }

            sb.Append(" ]\n");
        }
        public static void ShowFinishedTokens(Player p, int playerId, StringBuilder sb)
        {
            sb.Append($"Player {playerId}: [ ");
            foreach (Token t in p.FinishedTokens)
            {
                sb.Append($"{char.ToUpper(t.Colour[0])}{t.Id}");
            }

            sb.Append(" ]");
        }
    }
}
