namespace LudoApplication.GameItems
{
    public class Gameboard
    {
        private char[] board;
        
        public Gameboard()
        {
            board = new char[52];
            
        }

        public char[] Board { get => board; set => board = value; }
    }
}
