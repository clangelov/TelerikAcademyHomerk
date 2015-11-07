namespace Task03.FindWords.TrieImplementation
{
    using System.Collections.Generic;

    public static class TrieFactory
    {
        /// <summary>
        /// Create a new Trie instance.
        /// </summary>
        public static ITrie CreateTrie()
        {
            return new Trie(CreateTrieNode(' ', null));
        }

        /// <summary>
        /// Create a new TrieNode instance.
        /// </summary>
        /// <param name="character">Character of the TrieNode.</param>
        internal static TrieNode CreateTrieNode(char character, TrieNode parent)
        {
            return new TrieNode(character, new Dictionary<char, TrieNode>(), 0, parent);
        }
    }
}
