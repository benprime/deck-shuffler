using System.Linq;
using CardShuffler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// Unity tests for deck features.
    /// </summary>
    [TestClass]
    public class DeckTests
    {
        /// <summary>
        /// Test deck used by all unit tests.
        /// </summary>
        private Deck _deck;

        /// <summary>
        /// Test setup to initialize test deck.
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            _deck = new Deck();
        }

        /// <summary>
        /// Verify deck count is 52 after instantiating a deck.
        /// </summary>
        [TestMethod]
        public void CreatedWith52Cards()
        {
            Assert.AreEqual(52, _deck.Cards.Count);
        }

        /// <summary>
        /// Verify each position of deck has been initialized.
        /// </summary>
        [TestMethod]
        public void CreatedDeckFilledAllCardSlots()
        {
            CollectionAssert.AllItemsAreNotNull(_deck.Cards);
            CollectionAssert.AllItemsAreInstancesOfType(_deck.Cards, typeof(Card));
        }

        /// <summary>
        /// Verify deck contains no duplicate cards after instantiating deck.
        /// </summary>
        [TestMethod]
        public void CreatedDeckContainsNoDuplicates()
        {
            CollectionAssert.AllItemsAreUnique(_deck.Cards);
        }

        /// <summary>
        /// Verify deck count is 52 after sorting deck.
        /// </summary>
        [TestMethod]
        public void SortedDeckCheck52Cards()
        {
            _deck.Sort();
            Assert.AreEqual(52, _deck.Cards.Count);
        }

        /// <summary>
        /// Verify each position of deck has been initialized after sorting.
        /// </summary>
        [TestMethod]
        public void SortedDeckFilledAllCardSlots()
        {
            _deck.Sort();
            CollectionAssert.AllItemsAreNotNull(_deck.Cards);
            CollectionAssert.AllItemsAreInstancesOfType(_deck.Cards, typeof(Card));
        }

        /// <summary>
        /// Verify deck contains no duplicate cards after sorting deck.
        /// </summary>
        [TestMethod]
        public void SortedDeckContainsNoDuplicates()
        {
            _deck.Sort();
            CollectionAssert.AllItemsAreUnique(_deck.Cards);
        }

        /// <summary>
        /// Verify deck is sorted as expected when sort is called.
        /// </summary>
        [TestMethod]
        public void SortedDeckVerifyOrder()
        {
            _deck.Sort();
            var expected = new[]
            {
                new Card(Rank.Ace, Suit.Spades),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Spades),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Eight, Suit.Spades),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Eight, Suit.Diamonds),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Nine, Suit.Spades),
                new Card(Rank.Nine, Suit.Clubs),
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Ten, Suit.Spades),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Jack, Suit.Spades),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.King, Suit.Spades),
                new Card(Rank.King, Suit.Clubs),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.King, Suit.Hearts)
            };
            CollectionAssert.AreEqual(expected, _deck.Cards);
        }

        /// <summary>
        /// Verify deck count is 52 after shuffling deck.
        /// </summary>
        [TestMethod]
        public void ShuffledDeckCheck52Cards()
        {
            _deck.Shuffle();
            Assert.AreEqual(52, _deck.Cards.Count);
        }

        /// <summary>
        /// Verify each position of deck has been initialized after shuffling.
        /// </summary>
        [TestMethod]
        public void ShuffledDeckFilledAllCardSlots()
        {
            _deck.Shuffle();
            CollectionAssert.AllItemsAreNotNull(_deck.Cards);
            CollectionAssert.AllItemsAreInstancesOfType(_deck.Cards, typeof(Card));
        }

        /// <summary>
        /// Verify deck contains no duplicate cards after shuffling.
        /// </summary>
        [TestMethod]
        public void ShuffledDeckContainsNoDuplicates()
        {
            _deck.Shuffle();
            CollectionAssert.AllItemsAreUnique(_deck.Cards);
        }

        /// <summary>
        /// Verify deck is shuffled as expected when a known seed is passed.
        /// </summary>
        [TestMethod]
        public void ShuffleKnownSeed()
        {
            _deck.Shuffle(2147483647);
            var expected = new[]
            {
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Five, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Six, Suit.Diamonds),
                new Card(Rank.Nine, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.King, Suit.Hearts),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Ten, Suit.Clubs),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Ace, Suit.Spades),
                new Card(Rank.Six, Suit.Spades),
                new Card(Rank.Nine, Suit.Spades),
                new Card(Rank.Four, Suit.Clubs),
                new Card(Rank.Seven, Suit.Spades),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Three, Suit.Clubs),
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Jack, Suit.Clubs),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.Nine, Suit.Diamonds),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.King, Suit.Spades),
                new Card(Rank.Jack, Suit.Spades),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Nine, Suit.Clubs),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Eight, Suit.Diamonds),
                new Card(Rank.Ten, Suit.Spades),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.King, Suit.Clubs),
                new Card(Rank.Eight, Suit.Spades),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Ten, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds)
            };
            CollectionAssert.AreEqual(expected, _deck.Cards);
        }

        /// <summary>
        /// Verify deck is rearranged from one shuffler to another.
        /// </summary>
        [TestMethod]
        public void ShuffleMultiple()
        {
            _deck.Shuffle();
            var deck1 = _deck.Cards.ToList();
            _deck.Shuffle();
            Assert.IsFalse(deck1.SequenceEqual(_deck.Cards));
        }
    }
}