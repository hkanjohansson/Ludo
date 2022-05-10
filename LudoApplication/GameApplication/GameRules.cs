using LudoApplication.GameItems;
using System;

namespace LudoApplication.GameApplication
{
    public static class GameRules
    {

        public static bool Moveable(Token t, int moves, Gameboard gb)
        {
            /*
             * The token is allowed to land on the last square i.e. do not check the last one.
             * 
             * TODO - Should it be checked if the tokens belongs to the current player?
             */
            for (int i = t.Position; i < t.Position + moves - 1; i++)
            {
                if (gb.Board[i] != '\0')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool FinishedToken(Token t)
        {
            /*
             * Safe indicates that the token has entered the finishing area,
             * and Token.Position == 6 indicates the last area of the finishing 
             * area.
             */
            return t.Safe && t.Position == 6;   
        }

        public static bool AbleToMoveOut(Die d, int dieRoll)
        {
            return dieRoll == d.NumberOfSides;
        }
    }
}
