using LudoApplication.GameApplication;
using LudoApplication.GameItems;
using LudoApplication.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestLudoApplication
{
    [TestClass]
    public class TestPlayer
    {
        static Gameboard gameboard = new();
        readonly Player p = new(gameboard, "green", 0);
        
        [TestMethod]
        public void TestMoveToken()
        {
            p.MoveToken(1, 6, true);   
            Assert.AreEqual(gameboard.Board[p.Tokens[1].Position], 'g');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMoveTokenException()
        {
            p.MoveToken(4, 5, true);
        }

        
    }
}
