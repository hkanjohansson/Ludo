using LudoApplication.GameApplication;
using LudoApplication.Players;

namespace LudoApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game g = new();
            g.InitialRoll();
            g.MainGame();
        }
    }
}
