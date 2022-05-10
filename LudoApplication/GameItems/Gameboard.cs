namespace LudoApplication.GameItems
{
    public class Gameboard
    {
        private char[] board;

        public Gameboard()
        {
            Board = new char[52];
        }

        public char[] Board { get => board; set => board = value; }
    }
}
