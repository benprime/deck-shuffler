using System;
using System.Collections.Generic;
using System.Linq;

namespace CardShuffler
{
    /// <summary>
    /// Represents the full deck of cards.
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class.
        /// </summary>
        public Deck()
        {
            // Since we want one Rank of Every suit, we select from
            // both enum value collections without a join (Cartesian product)
            var q = from suit in Enum.GetValues(typeof(Suit)).Cast<Suit>()
                    from rank in Enum.GetValues(typeof(Rank)).Cast<Rank>()
                    select new Card(rank, suit);

            Cards = q.ToList();
        }

        /// <summary>
        /// Gets or sets list of <see cref="Card"/>s contained in the deck.
        /// </summary>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Sort the deck in ascending order.
        /// </summary>
        public void Sort()
        {
            Cards = Cards.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();
        }

        /// <summary>
        /// Shuffle the deck.
        /// </summary>
        /// <returns>seed value used to shuffle deck</returns>
        public int Shuffle()
        {
            var seed = Guid.NewGuid().GetHashCode();
            Shuffle(seed);
            return seed;
        }

        /// <summary>
        /// Shuffles the deck based on a seed.
        /// </summary>
        /// <param name="seed">seed value used to shuffle deck</param>
        public void Shuffle(int seed)
        {
            // Why am I not just using a static member variable for Random?
            // By passing in the seed the deck can be "shuffled" to a known state.
            // This may be important for games were there is a restart option or
            // a simpler way to save the deck order for reloading.
            var random = new Random(seed);

            // Fisher-Yates shuffle
            for (var i = 0; i < Cards.Count - 2; i++)
            {
                // only consider positions of unshuffled cards
                var swapIndex = random.Next(i, Cards.Count);

                var tmp = Cards[i];
                Cards[i] = Cards[swapIndex];
                Cards[swapIndex] = tmp;
            }
        }
    }
}