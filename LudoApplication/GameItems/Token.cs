namespace LudoApplication.GameItems
{
    public class Token
    {
        private int id;
        private string colour;
        private int position;
        private bool safe;
        public Token(int id, string colour, int position)
        {
            this.id = id;
            this.colour = colour;
            this.position = position;
            safe = false;
        }

        public int Id { get => id; set => id = value; }
        public string Colour { get => colour; set => colour = value; }
        public bool Safe { get => safe; set => safe = value; }
        public int Position { get => position; set => position = value; }
    }
}
