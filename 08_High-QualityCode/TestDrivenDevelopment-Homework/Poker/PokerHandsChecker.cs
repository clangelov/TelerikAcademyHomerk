namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int CardExpectedCount = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter");
            }

            if (hand.Cards.Count() != CardExpectedCount)
            {
                return false;
            }

            if (hand.Cards.Distinct().Count() != CardExpectedCount)
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var sortedCards = hand.Cards.OrderBy(card => (int)card.Face).ToArray();

            if (!sortedCards.All(card => card.Suit == sortedCards[0].Suit))
            {
                return false;
            }

            for (int i = 1; i < sortedCards.Length; i++)
            {
                int prevCardCode = (int)sortedCards[i - 1].Face;
                int nextCardCode = (int)sortedCards[i].Face;
                if (nextCardCode - 1 != prevCardCode)
                {
                    return false;
                }                
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {            
            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 3) && group.Any(gr => gr.Count() == 2);            
        }

        public bool IsFlush(IHand hand)
        {
            var sortedCards = hand.Cards.OrderBy(card => (int)card.Face).ToArray();
            var firstCardSuit = sortedCards[0].Suit;            

            if (sortedCards.All(card => card.Suit == firstCardSuit) & !this.IsStraightFlush(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            if (this.IsStraightFlush(hand) || this.IsFlush(hand))
            {
                return false;
            }

            var sortedCards = hand.Cards.OrderBy(card => (int)card.Face).ToArray();
            
            for (int i = 1; i < sortedCards.Length; i++)
            {
                int prevCardCode = (int)sortedCards[i - 1].Face;
                int nextCardCode = (int)sortedCards[i].Face;
                if (nextCardCode - 1 != prevCardCode)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (this.IsFullHouse(hand))
            {
                return false;
            }
            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 3);
        }

        public bool IsTwoPair(IHand hand)
        {
            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Where(gr => gr.Count() == 2).ToList().Count == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (IsFullHouse(hand))
            {
                return false;
            }
            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Where(gr => gr.Count() == 2).ToList().Count == 1;
        }

        public bool IsHighCard(IHand hand)
        {

            var group = hand.Cards.GroupBy(card => card.Face);
            if (group.Any(gr => gr.Count() != 1))
            {
                return false;
            }
            if (IsFlush(hand) || IsFullHouse(hand) || IsStraight(hand) ||
                IsStraightFlush(hand) || IsThreeOfAKind(hand))
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (firstHand == null || secondHand == null)
            {
                throw new ArgumentNullException("One or both of the parameters is null");
            }

            if (object.ReferenceEquals(firstHand, secondHand))
            {
                throw new ArgumentException("You can not compare the same object");
            }

            int firstHandStrength = this.CalculateGeneralHandStrength(firstHand);
            int secondHandStrength = this.CalculateGeneralHandStrength(secondHand);

            if (firstHandStrength > secondHandStrength)
            {
                return 1;
            }

            if (secondHandStrength > firstHandStrength)
            {
                return -1;
            }
            
            return 0;
        }
        private int CalculateGeneralHandStrength(IHand hand)
        {
            if (this.IsHighCard(hand))
            {
                return (int)HandStrength.HighCard;
            }
            else if (this.IsOnePair(hand))
            {
                return (int)HandStrength.OnePair;
            }
            else if (this.IsTwoPair(hand))
            {
                return (int)HandStrength.TwoPair;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return (int)HandStrength.ThreeOfAKind;
            }
            else if (this.IsStraight(hand))
            {
                return (int)HandStrength.Straight;
            }
            else if (this.IsFlush(hand))
            {
                return (int)HandStrength.Flush;
            }
            else if (this.IsFullHouse(hand))
            {
                return (int)HandStrength.FullHouse;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return (int)HandStrength.FourOfAKind;
            }
            else
            {
                return (int)HandStrength.StraightFlush;
            }
            
        }
    }
}
