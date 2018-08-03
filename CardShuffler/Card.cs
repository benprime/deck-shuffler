using System;

namespace CardShuffler
{
    /// <summary>
    /// Represents a single card in the deck.
    /// </summary>
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        /// <summary>
        /// Rank of card.
        /// </summary>
        public readonly Rank Rank;

        /// <summary>
        /// Suit of card.
        /// </summary>
        public readonly Suit Suit;

        /// <summary>
        /// String representation of card.
        /// </summary>
        private readonly string _description;

        /// <summary>
        /// Initializes a new immutable instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="rank">Rank of card.</param>
        /// <param name="suit">Suit of card.</param>
        public Card(Rank rank, Suit suit)
        {
            Suit = suit;
            Rank = rank;
            _description = rank + " of " + suit;
        }

        /// <summary>
        /// Method to compare one card to another for sorting.
        /// </summary>
        /// <param name="other">Card to compare against.</param>
        /// <returns>Results of comparison between both cards.</returns>
        public int CompareTo(Card other)
        {
            var rankResult = Rank.CompareTo(other.Rank);
            return rankResult != 0 ? rankResult : Suit.CompareTo(other.Suit);
        }

        /// <summary>
        /// Custom equality comparison using the rank and suit.
        /// </summary>
        /// <param name="other">Card to compare against</param>
        /// <returns>true if equal</returns>
        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Rank == other.Rank && Suit == other.Suit;
        }

        /// <summary>
        /// Custom equality comparer for when compared against something
        /// that is currently casted to an object type.
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns>true if equal</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Card) obj);
        }

        /// <summary>
        /// Adding rank and suit to the hashcode calculation.
        /// </summary>
        /// <returns>the card's hashcode</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Rank * 397) ^ (int) Suit;
            }
        }

        /// <summary>
        /// Provides human readable card description.
        /// </summary>
        /// <returns>Description of card.</returns>
        public override string ToString()
        {
            return _description;
        }
    }
}