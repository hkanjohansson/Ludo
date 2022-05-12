using LudoApplication.GameApplication;
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
        private string colourOfTokens;
        private List<Token> tokens;
        private readonly int startSquare;
        private readonly int homeField;

        public Player(Gameboard gb, string colourOfTokens, int startSquare)
        {
            gameboard = gb;
            this.colourOfTokens = colourOfTokens;
            Tokens = new List<Token>();
            homeField = LENGTH_OF_HOME;
            this.startSquare = startSquare;
            
            for (int i = 0; i < NUMBER_OF_TOKENS; i++)
            {
                Tokens.Add(new Token(i, colourOfTokens, startSquare));
            }
        }

        public int HomeField => homeField;
        public Gameboard Gameboard { get; }
        public string ColourOfTokens { get => colourOfTokens; set => colourOfTokens = value; }
        public List<Token> Tokens { get => tokens; set => tokens = value; }
        public int StartSquare => startSquare;

        

        public void MoveToken(int tokenId, int moves, bool moveable)
        {
            if (tokenId < 0 || tokenId >= 4)
            {
                throw new ArgumentOutOfRangeException($"Invalid choice: {tokenId}. Provide a valid choice. Valid choices are: 0, 1, 2 and 3.");
            }

            Token t = tokens[tokenId];
            
            if (moveable)
            {
                gameboard.Board[t.Position] = '\0';
                t.Position += moves;
                gameboard.Board[t.Position] = colourOfTokens[0];
            }
        }

        public void MoveFinishingToken(Token t, int moves, bool moveable)
        {
            if (moveable)
            {
                gameboard.FinishArea[t.FinishPosition] = 'X';
                t.FinishPosition += moves;

                gameboard.FinishArea[t.FinishPosition - 1] = t.Colour[0];
            }
        }
    }
}
