using System;

namespace CardShuffler
{
    /// <summary>
    /// Deck shuffler test program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point to deck shuffler test program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        private static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();

            foreach(var card in deck.Cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}