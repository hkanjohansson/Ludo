namespace LudoApplication.GameItems
{
    public class Gameboard
    {
        private int[] board;

        public Gameboard()
        {
            Board = new int[52];
        }

        public int[] Board { get => board; set => board = value; }
    }
}
