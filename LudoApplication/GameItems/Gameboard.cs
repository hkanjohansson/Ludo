namespace LudoApplication.GameItems
{
    public class Gameboard
    {
        private char[] board;
        private char[] finishArea;

        public Gameboard()
        {
            board = new char[52];
            finishArea = new char[5];
            
            for (int i = 0; i < finishArea.Length; i++)
            {
                finishArea[i] = 'X';
            }
        }

        public char[] Board { get => board; set => board = value; }
        public char[] FinishArea { get => finishArea; set => finishArea = value; }
    }
}
