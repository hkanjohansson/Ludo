using LudoApplication.GameItems;
using System;

namespace LudoApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gameboard gb = new();

            for (int i = 0; i < gb.Board.Length; i++)
            {
                Console.WriteLine(gb.Board[i]);
            }
        }
    }
}
