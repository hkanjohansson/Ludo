﻿namespace LudoApplication.GameItems
{
    public class Token
    {
        private int id;
        private string colour;
        private bool home;
        private int position;
        private bool safe;
        public Token(int id, string colour, int position)
        {
            this.id = id;
            this.colour = colour;
            home = true;
            this.position = position;
            safe = false;
        }

        public int Id { get => id; set => id = value; }
        public string Colour { get => colour; set => colour = value; }
        public bool Home { get => home; set => home = value; }
        public int Position { get => position; set => position = value; }
        public bool Safe { get => safe; set => safe = value; }
    }
}
