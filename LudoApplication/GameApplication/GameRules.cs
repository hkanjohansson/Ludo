using LudoApplication.GameItems;
using LudoApplication.Players;
using System;

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
             * 
             * TODO - Should it be checked if the tokens belongs to the current player?
             */

            for (int i = t.Position + 1; i < t.Position + moves - 1; i++)
            {
                if (gb.Board[i % gb.Board.Length] != '\0')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EnterFinishArea(Player p, Token t, int moves)
        {
            Console.WriteLine("Enter finish area number: " + (t.Position + p.StartSquare) % (52 + p.StartSquare));
            /*
             * TODO - Set the remaining moves to finishing move 
             */

            for (int i = t.Position + p.StartSquare; i < t.Position + p.StartSquare + moves; i++)
            {
                if (i % (52 + p.StartSquare - 1) == 0 && t.Position > p.StartSquare)
                {
                    
                    p.MoveFinishingToken(t, i - t.Position - p.StartSquare, true);
                    t.Safe = true;
                    return true;
                }
            }


            return false;
        }
        public static bool FinishedToken(Token t, int dieRoll)
        {
            /*
             * Safe indicates that the token has entered the finishing area,
             * and Token.FinishPosition == 6 indicates the last area of the finishing 
             * area.
             */
            return t.Safe && t.FinishPosition + dieRoll == 5;
        }




    }
}
