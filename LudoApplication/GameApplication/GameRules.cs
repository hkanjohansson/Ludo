using LudoApplication.GameItems;
using LudoApplication.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoApplication.GameApplication
{
    public static class GameRules
    {
        public static bool AbleToMoveOut(Die d, int dieRoll)
        {
            return dieRoll == d.NumberOfSides;
        }

        public static bool Moveable(Token t, int moves, Gameboard gb)
        {
            /*
             * The token is allowed to land on the last square i.e. do not check the last one.
             */
            if (t == null)
            {
                return false;
            }

            for (int i = t.Position + 1; i < t.Position + moves - 1; i++)
            {
                if (gb.Board[i % gb.Board.Length] != '\0')
                {
                    return false;
                }
            }


            return true;
        }

        public static void LandOnOpponent(Token t, Gameboard gb, List<Player> players, int moves)
        {
            /*
             * Cases: 
             * 
             * 1) If oppColour is the same as the spot landing on or no token at all, then return.
             * 
             * 2) If landing on an opponent an opponent reset the fields of the captured token
             * and send off the gameboard.
             */
            char oppColour = gb.Board[(t.Position + moves) % gb.Board.Length];
            if (oppColour == t.Colour[0] || gb.Board[(t.Position + moves) % gb.Board.Length] == '\0')
            {
                Console.WriteLine("Landed on an empty spot or a spot where your own token were placed.");
                return;
            }

            Player opponent = players.Where(p => p.ColourOfTokens[0] == oppColour).FirstOrDefault();
            Token oppToken = opponent.Tokens.Where(t2 => t2.Position == t.Position + moves).FirstOrDefault();

            if (oppToken == null)
            {
                return;
            }

            Console.WriteLine($"Opponents token colour: {oppToken.Colour}");
            oppToken.Home = true;
            oppToken.Safe = true;
            oppToken.Position = opponent.StartSquare;
            oppToken.RelativePosition = 0;
            gb.Board[t.Position + moves] = char.ToUpper(t.Colour[0]);
            Console.WriteLine($"Sent token {oppToken.Colour[0]}{oppToken.Id} back home.");

        }
        public static void EnterFinishArea(Player p, Token t, int moves)
        {
            /*
             * Marks a token safe and the token is then being placed on the finishing
             * area instead of the gameboard.
             */
            t.Safe = true;
            p.MoveFinishingToken(t, moves, t.FinishPosition + moves < 5);
        }

        public static bool FinishedToken(Token t, int finishingMove)
        {
            /*
             * Safe indicates that the token has entered the finishing area,
             * and Token.FinishPosition == 5 indicates 'F' on the UI and hence
             * the position right outside the finishing area and thereof the 
             * token is finished.
             */
            return t.Safe && finishingMove == 5;
        }
    }
}
