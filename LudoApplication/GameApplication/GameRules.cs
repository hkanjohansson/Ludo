using LudoApplication.GameItems;
using LudoApplication.Players;

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

        public static void EnterFinishArea(Player p, Token t, int moves)
        {
            t.Safe = true;
            p.MoveFinishingToken(t, moves - 1, t.FinishPosition + moves <= 5);
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
