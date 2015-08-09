namespace Poker_Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        private PokerHandsChecker checker;

        private Hand shortFourCardsHand;
        private Hand longSixCardsHand;
        private Hand twoSameCardSuitsHand;
        private Hand validCardsHand;
        private Hand validFlushHand;
        private Hand validStraightFlushHand;
        private Hand validFourOfAKindHand;
        private Hand validStraigtHand;
        private Hand validThreeOfAKindHand;
        private Hand validFullHouseHand;
        private Hand validTwoPairHand;
        private Hand validOnePairHand;

        [TestInitialize]
        public void AddPokerHandsCheckerAndHands()
        {
            this.checker = new PokerHandsChecker();

            this.shortFourCardsHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Clubs)
            });

            this.longSixCardsHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Nine,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Clubs)
            });

            this.twoSameCardSuitsHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Nine,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.Nine,CardSuit.Clubs),
                new Card(CardFace.Nine,CardSuit.Clubs)
            });

            this.validCardsHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Seven,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Spades),
                new Card(CardFace.Ten,CardSuit.Clubs)
            });

            this.validFlushHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Clubs)
            });

            this.validStraightFlushHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Clubs)
            });

            this.validStraigtHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Spades)
            });

            this.validFourOfAKindHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Ace,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Clubs)
            });

            this.validThreeOfAKindHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Ten,CardSuit.Clubs)
            });

            this.validFullHouseHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Clubs)
            });

            this.validTwoPairHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Four,CardSuit.Spades),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Clubs)
            });

            this.validOnePairHand = new Hand(new List<ICard> 
            {
                new Card(CardFace.Ace,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Four,CardSuit.Spades),
                new Card(CardFace.Ten,CardSuit.Hearts),
                new Card(CardFace.Six,CardSuit.Clubs)
            });
        }

        // Task 3. In the PokerHandsChecker class implement the IsValidHand(IHand) method 

        [TestMethod]
        public void TestIsValidHandReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsValidHand(this.validCardsHand), "A valid hand does not return true");
        }

        [TestMethod]
        public void TestIsValidHandReturnsFalseHandWithLessCards()
        {
            Assert.IsFalse(this.checker.IsValidHand(this.shortFourCardsHand), "An invalid hand with only 4 cards does not return false");
        }

        [TestMethod]
        public void TestIsValidHandReturnsFalseHandWithMoreCards()
        {
            Assert.IsFalse(this.checker.IsValidHand(this.longSixCardsHand), "An invalid hand with 6 cards does not return false");
        }

        [TestMethod]
        public void TestIsValidHandReturnsFalseHandWithTwoSameCards()
        {
            Assert.IsFalse(this.checker.IsValidHand(this.twoSameCardSuitsHand), "An invalid hand 2 same cards does not return false");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsValidHandReturnsFalseWhenNullIsPassed()
        {
            this.checker.IsValidHand(null);
        }

        // Task 4. In the PokerHandsChecker class implement the IsFlush(IHand) method

        [TestMethod]
        public void TestIsFlushReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsFlush(this.validFlushHand), "A valid Flush hand does not return true");
        }

        [TestMethod]
        public void TestIsFlushReturnsFalseWithStreightFlushHand()
        {
            Assert.IsFalse(this.checker.IsFlush(this.validStraightFlushHand), "In case of Straight Flush does not return false");
        }

        [TestMethod]
        public void TestIsFlushReturnsFalseWithCardsOfDifferentSuit()
        {
            Assert.IsFalse(this.checker.IsFlush(this.validCardsHand), "In case of High card hand does not return false");
        }

        // Task 5. In the PokerHandsChecker class implement the IsFourOfAKind(IHand) method

        [TestMethod]
        public void TestIsFourOfAKindReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsFourOfAKind(this.validFourOfAKindHand), "A valid Four Of a Kind hand does not return true");
        }

        [TestMethod]
        public void TestIsFourOfAKindReturnsFalseWithLessThanFourEqualCards()
        {
            Assert.IsFalse(this.checker.IsFourOfAKind(this.validCardsHand), "In case of Hand with 5 different cards IsFourOfAKind does not return false");
        }

        // Task 6*. Implement the other check for poker hands
        // IsStraightFlush
        [TestMethod]
        public void TestIsStraightFlushReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsStraightFlush(this.validStraightFlushHand), "A valid Straight Flush hand does not return true");
        }

        [TestMethod]
        public void TestIsStraightFlushReturnsFasleWithFlushCard()
        {
            Assert.IsFalse(this.checker.IsStraightFlush(this.validFlushHand), "In case of Flush hand does not return false");
        }

        [TestMethod]
        public void TestIsStraightFlushReturnsFasleWithInvalidHand()
        {
            Assert.IsFalse(this.checker.IsStraightFlush(this.validCardsHand), "In case of any other invalid hand does not return false");
        }

        // IsStraight(IHand hand)
        [TestMethod]
        public void TestIsStraightReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsStraight(this.validStraigtHand), "A valid Straight hand does not return true");
        }

        [TestMethod]
        public void TestIsStraightReturnsFasleWithFlushCard()
        {
            Assert.IsFalse(this.checker.IsStraight(this.validFlushHand), "In case of Flush hand does not return false");
        }

        [TestMethod]
        public void TestIsStraightReturnsFasleWithStraightFlushCard()
        {
            Assert.IsFalse(this.checker.IsStraight(this.validStraightFlushHand), "In case of Straight Flush hand does not return false");
        }

        // IsFullHouse(IHand hand)
        [TestMethod]
        public void TestIsFullHouseReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsFullHouse(this.validFullHouseHand), "A valid Full House hand does not return true");
        }

        [TestMethod]
        public void TestIsFullHouseReturnsFalseWithThreeOFAKindHand()
        {
            Assert.IsFalse(this.checker.IsFullHouse(this.validThreeOfAKindHand), "In case of Three of A Kind does not return false");
        }

        [TestMethod]
        public void TestIsFullHouseReturnsFalseWithAnyOtherHand()
        {
            Assert.IsFalse(this.checker.IsFullHouse(this.validStraigtHand), "In case of Straight hand does not return false");
        }

        // IsThreeOfAKind(IHand hand)
        [TestMethod]
        public void TestIsThreeOfAKindReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsThreeOfAKind(this.validThreeOfAKindHand), "A valid Three Of A Kind hand does not return true");
        }

        [TestMethod]
        public void TestIsThreeOfAKindReturnsFalseWithInvalidHand()
        {
            Assert.IsFalse(this.checker.IsThreeOfAKind(this.validFlushHand), "In case of Straight hand hand does not return false");
        }

        //IsTwoPair(IHand hand)
        [TestMethod]
        public void TestIsTwoPairReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsTwoPair(this.validTwoPairHand), "A valid Two Pair hand does not return true");
        }

        [TestMethod]
        public void TestIsTwoPairReturnsFalseWithOnePairHand()
        {
            Assert.IsFalse(this.checker.IsTwoPair(this.validOnePairHand), "In case of One Pair hand does not return false");
        }

        // IsOnePair(IHand hand)
        [TestMethod]
        public void TestIsOnePairReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsOnePair(this.validOnePairHand), "A valid One Pair hand does not return true");
        }


        [TestMethod]
        public void TestIsOnePairReturnsFalseWithFullHouseHand()
        {
            Assert.IsFalse(this.checker.IsOnePair(this.validFullHouseHand), "In case of Full House hand does not return false");
        }

        // IsHighCard(IHand hand)
        [TestMethod]
        public void TestIsHighCardReturnsTrueWithValidHand()
        {
            Assert.IsTrue(this.checker.IsHighCard(this.validCardsHand), "A valid High Card hand does not return true");
        }

        [TestMethod]
        public void TestIsHighCardReturnsFalseWithInvalidHand()
        {
            Assert.IsFalse(this.checker.IsHighCard(this.validFullHouseHand), "In case of Full House hand does not return false");
            Assert.IsFalse(this.checker.IsHighCard(this.validStraigtHand), "In case of Straight hand does not return false");
            Assert.IsFalse(this.checker.IsHighCard(this.validThreeOfAKindHand), "In case of Three of a Kind hand does not return false");
            Assert.IsFalse(this.checker.IsHighCard(this.validOnePairHand), "In case of One Pair hand does not return false");
        }

        // Task 7*. Implement a card comparison logic for Poker hands
        // Partial solution
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCompareHandsToThrowWhenNullIsPassed()
        {
            this.checker.CompareHands(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCompareHandsToThrowWhenOnlyOneHandIsProvided()
        {
            this.checker.CompareHands(this.validOnePairHand, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCompareHandsToThrowWhenTheSameHandIsProvidedTwice()
        {
            this.checker.CompareHands(this.validOnePairHand, this.validOnePairHand);
        }

        [TestMethod]
        public void TestCompareHandsFisrtHandToBeBetter()
        {

            int expectedResult = 1;
            int actualResult =  this.checker.CompareHands(this.validFullHouseHand, this.validTwoPairHand);
            Assert.AreEqual(expectedResult, actualResult, "A stronger first card is not evaluated correctly" );
        }

        [TestMethod]
        public void TestCompareHandsSecondHandToBeBetter()
        {

            int expectedResult = -1;
            int actualResult = this.checker.CompareHands(this.validThreeOfAKindHand, this.validFlushHand);
            Assert.AreEqual(expectedResult, actualResult, "A stronger first card is not evaluated correctly");
        }

    }
}
