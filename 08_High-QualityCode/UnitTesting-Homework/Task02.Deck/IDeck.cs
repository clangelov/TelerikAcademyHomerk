namespace Task02.Deck
{
    using Task02.Deck.Cards;

    public interface IDeck
    {
        Card GetTrumpCard { get; }        

        int CardsLeft { get; }

        Card GetNextCard();

        void ChangeTrumpCard(Card newCard);
    }
}
