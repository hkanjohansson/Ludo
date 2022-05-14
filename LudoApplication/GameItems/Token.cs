namespace LudoApplication.GameItems
{
    public class Token
    {
        private int id;
        private string colour;
        private bool home;
        private int position;
        private int relativePosition;
        private bool safe;
        private int finishPosition;
        private bool finished;
        public Token(int id, string colour, int position)
        {
            this.id = id;
            this.colour = colour;
            home = true;
            this.position = position;
            relativePosition = 0;
            safe = false;
            finishPosition = 0;
            finished = false;
        }

        public int Id { get => id; set => id = value; }
        public string Colour { get => colour; set => colour = value; }
        public bool Home { get => home; set => home = value; }
        public int Position { get => position % 52; set => position = value; }
        public int RelativePosition { get => relativePosition; set => relativePosition = value; }
        public bool Safe { get => safe; set => safe = value; }
        public int FinishPosition { get => finishPosition; set => finishPosition = value; }
        public bool Finished { get => finished; set => finished = value; }
    }
}
