namespace Poker_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestToStringToWorksCorrect()
        {
            string result = "Two of Clubs";
            var card = new Card(CardFace.Two, CardSuit.Clubs);
            Assert.AreEqual(result, card.ToString(), "Strings are different!");
        }
    }
}
