using LudoApplication.GameApplication;

namespace LudoApplication
{
    public class LudoApplicationMain
    {
        public static void Main(string[] args)
        {
            Game g = new();
            g.InitialRoll();
            g.MainGame();
        }
    }
}
