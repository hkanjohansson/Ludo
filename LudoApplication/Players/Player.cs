using LudoApplication.GameItems;
using System;
using System.Collections.Generic;

namespace LudoApplication.Players
{
    public class Player
    {
        const int NUMBER_OF_TOKENS = 4;
        const int LENGTH_OF_HOME = 6;
        private readonly Gameboard gameboard;
        private IList<Token> tokens;
        private readonly int homeField;

        public Player(Gameboard gb, string colourOfTokens, int startSquare)
        {
            gameboard = gb;
            Tokens = new List<Token>();
            homeField = LENGTH_OF_HOME;

            for (int i = 0; i < NUMBER_OF_TOKENS; i++)
            {
                Tokens.Add(new Token(i, colourOfTokens, startSquare));
            }
        }

        public int HomeField => homeField;
        public Gameboard Gameboard { get; }
        public IList<Token> Tokens { get => tokens; set => tokens = value; }

        public void MoveToken(int tokenId, int moves, bool moveable)
        {
            if (tokenId < 0 || tokenId >= 4)
            {
                throw new ArgumentOutOfRangeException($"Invalid choice: {tokenId}. Provide a valid choice. Valid choices are: 0, 1, 2 and 3.");
            }

            Token t = tokens[tokenId];
            
            if (moveable)
            {
                t.Position += moves;
                gameboard.Board[t.Position - 1] = 1;
            }
        }
    }
}
