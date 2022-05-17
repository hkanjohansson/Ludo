using LudoApplication.GameApplication;
using LudoApplication.GameItems;
using System;
using System.Collections.Generic;

namespace LudoApplication.Players
{
    public class Player
    {
        const int NUMBER_OF_TOKENS = 4;
        private readonly Gameboard gameboard;
        private string colourOfTokens;
        private List<Token> tokens;
        private List<Token> finishedTokens; // Tokens that are finished and therefore they are out of the game
        private readonly int startSquare;
        private char[] finishArea;

        public Player(Gameboard gb, string colourOfTokens, int startSquare)
        {
            gameboard = gb;
            this.colourOfTokens = colourOfTokens;
            tokens = new List<Token>();
            finishedTokens = new List<Token>();
            
            this.startSquare = startSquare;
            for (int i = 0; i < NUMBER_OF_TOKENS; i++)
            {
                tokens.Add(new Token(i, colourOfTokens, startSquare));
            }

            finishArea = new char[5];
            for (int i = 0; i < finishArea.Length; i++)
            {
                finishArea[i] = 'X';
            }
        }

        
        public Gameboard Gameboard { get => gameboard; }
        public string ColourOfTokens { get => colourOfTokens; set => colourOfTokens = value; }
        public List<Token> Tokens { get => tokens; set => tokens = value; }
        public int StartSquare => startSquare;
        public char[] FinishArea { get => finishArea; set => finishArea = value; }
        public List<Token> FinishedTokens { get => finishedTokens; set => finishedTokens = value; }

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
                t.RelativePosition += moves;
                gameboard.Board[t.Position] = colourOfTokens[0];
            }
        }

        public void MoveFinishingToken(Token t, int moves, bool moveable)
        {
            if (moveable)
            {
                Gameboard.Board[t.Position] = '\0';
                FinishArea[t.FinishPosition] = 'X';
                t.FinishPosition += moves;
                FinishArea[t.FinishPosition] = t.Colour[0];
            }
        }
    }
}
