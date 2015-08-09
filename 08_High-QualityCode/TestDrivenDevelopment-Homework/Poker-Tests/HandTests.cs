namespace Poker_Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestToStringToWorksCorrect()
        {
            string result = "Player has: " +
                            "Two of Clubs, " +
                            "Three of Clubs, " +
                            "Four of Clubs, " +
                            "Five of Clubs, " +
                            "Six of Clubs.";

            var cards = new List<ICard>() 
            {
                new Card(CardFace.Two, CardSuit.Clubs), 
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Five, CardSuit.Clubs), 
                new Card(CardFace.Six, CardSuit.Clubs)
            };

            var hand = new Hand(cards);

            Assert.AreEqual(result, hand.ToString(), "Strings are different!");
        }
    }
}
