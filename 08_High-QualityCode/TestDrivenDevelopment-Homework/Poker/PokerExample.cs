namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerExample
    {
        public static void Main()
        {            
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card.Equals(card2));

            /*
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsTwoPair(hand));
             */
        }
    }
}
