namespace Poker
{
    using System;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            string output = this.Face + " of " + this.Suit;
            return output;
        }

        public override bool Equals(object card)
        {

            var other = card as Card;

            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Face == other.Face && this.Suit == other.Suit;
        }

        public override int GetHashCode()
        {
            int hashCardFace = this.Face.GetHashCode();

            int hashCardSuit = this.Suit.GetHashCode();

            return hashCardFace ^ hashCardSuit;
        }
    }
}
