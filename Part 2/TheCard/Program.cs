namespace TheCardProgram
{
    class Card
    {
        public CardRank _rank {  get; }
        public CardColor _color { get; }
        
        //Parameter Constructor 
        public Card(CardColor color, CardRank rank)
        {
            _rank = rank;
            _color = color;
        }

        //Parameterless Constructor
        public Card()
        {
            Console.WriteLine("Specify a a color and a rank please");
        } 

        public string CardType(Card card)
        {
            if (card._rank == CardRank.DollarSing || card._rank == CardRank.PercentScore || 
                card._rank == CardRank.Ampersand || card._rank == CardRank.Caret)
            {
                return "Symbol Card";
            }
            else
            {
                return "Number Card";
            }
        }
        
        static public List<Card> CreateDeck()
        {
            List<Card> cardDeck = new List<Card>();

            foreach (CardColor i in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardRank b in Enum.GetValues(typeof(CardRank)))
                {
                    cardDeck.Add(new Card(i, b));
                }
            }

            return cardDeck;
        }
        
        static void Main()
        {
            
            List<Card> cardDeck = Card.CreateDeck();
            
            foreach (Card card in cardDeck)
            {
                Console.WriteLine($"The {card._color} {card._rank}");
            }
            
            Console.WriteLine("Press any key to close!");
            Console.ReadKey();
        }
        
    }
}

enum CardRank { One, Two, Three, Four, Five, Seven, Eight, Nine, Ten, DollarSing, PercentScore, Ampersand, Caret }
enum CardColor { Red, Green, Blue, Yellow}