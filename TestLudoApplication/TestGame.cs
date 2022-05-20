using LudoApplication.GameApplication;
using LudoApplication.GameItems;
using LudoApplication.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLudoApplication
{
    [TestClass]
    public class TestGame
    {
        readonly Player p = new(new Gameboard(), "green", 0);
        readonly Game game = new();

        [TestMethod]
        public void TestParseChoice()
        {
            string choice = "3";
            int parsedChoice = Game.ParseChoice(ref choice);
            Assert.AreEqual(3, parsedChoice);
        }

        [TestMethod]
        public void TestTokenChoiceValidation()
        {
            int validChoice = 3;
            Game.TokenChoiceValidation(ref validChoice);
            Assert.AreEqual(3, validChoice);
        }

        [TestMethod]
        public void TestEnterFinishArea()
        {
            p.Tokens[0].Position = 50;
            GameRules.EnterFinishArea(p, p.Tokens[0], 3);
            Assert.IsTrue(p.Tokens[0].FinishPosition == 3);
        }

        [TestMethod]
        public void TestFinishingToken()
        {
            p.Tokens[0].Safe = true;
            p.MoveFinishingToken(p.Tokens[0], 3, true);
            int finishingMove = p.Tokens[0].FinishPosition + 2;
            Assert.IsTrue(GameRules.FinishedToken(p.Tokens[0], finishingMove));
        }

        [TestMethod]
        public void TestLandOnOpponent()
        {
            game.Players[1].MoveToken(0, 6, true);
            game.Players[0].Tokens[0].Position = 16;
            GameRules.LandOnOpponent(game.Players[0].Tokens[0], game.Gb, game.Players, 3);
            Assert.AreEqual(game.Players[1].Tokens[0].Home, true);
            Assert.AreEqual(game.Players[1].Tokens[0].RelativePosition, 0);
        }
    }
}
