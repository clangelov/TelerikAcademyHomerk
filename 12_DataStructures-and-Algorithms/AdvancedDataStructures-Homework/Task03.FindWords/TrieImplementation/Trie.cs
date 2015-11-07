namespace Task03.FindWords.TrieImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Trie data structure.
    /// </summary>
    public class Trie : ITrie
    {
        /// <summary>
        /// Create a new Trie instance.
        /// </summary>
        /// <param name="rootTrieNode">The root TrieNode.</param>
        public Trie(TrieNode rootTrieNode)
        {
            this.RootTrieNode = rootTrieNode;
        }

        /// <summary>
        /// Root TrieNode.
        /// </summary>
        private TrieNode RootTrieNode { get; set; }

        /// <summary>
        /// Add a word to the Trie.
        /// </summary>
        public void AddWord(string word)
        {
            this.AddWord(this.RootTrieNode, word.ToCharArray());
        }

        /// <summary>
        /// Remove word from the Trie.
        /// </summary>
        public void RemoveWord(string word)
        {
            var trieNode = this.GetTrieNode(word);
            if (trieNode == null || !trieNode.IsWord)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} does not exist in trie.", word));
            }

            trieNode.RemoveNode(this.RootTrieNode);
        }

        /// <summary>
        /// Get all words in the Trie.
        /// </summary>
        public ICollection<string> GetWords()
        {
            var words = new List<string>();
            var buffer = new StringBuilder();
            this.GetWords(this.RootTrieNode, words, buffer);
            return words;
        }

        /// <summary>
        /// Get words for given prefix.
        /// </summary>
        public ICollection<string> GetWords(string prefix)
        {
            ICollection<string> words;
            if (string.IsNullOrEmpty(prefix))
            {
                words = this.GetWords();
            }
            else
            {
                var trieNode = this.GetTrieNode(prefix);

                // Empty list if no prefix match
                words = new List<string>();
                if (trieNode != null)
                {
                    var buffer = new StringBuilder();
                    buffer.Append(prefix);
                    this.GetWords(trieNode, words, buffer);
                }
            }

            return words;
        }

        /// <summary>
        /// Returns true or false if the word is present in the Trie.
        /// </summary>
        public bool HasWord(string word)
        {
            var trieNode = this.GetTrieNode(word);
            return trieNode != null && trieNode.IsWord;
        }

        /// <summary>
        /// Returns the count for the word in the Trie.
        /// </summary>
        public int WordCount(string word)
        {
            var trieNode = this.GetTrieNode(word);
            return trieNode == null ? 0 : trieNode.WordCount;
        }

        /// <summary>
        /// Get longest words from the Trie.
        /// </summary>
        public ICollection<string> GetLongestWords()
        {
            var longestWords = new List<string>();
            var buffer = new StringBuilder();
            var length = 0;
            this.GetLongestWords(this.RootTrieNode, longestWords, buffer, ref length);
            return longestWords;
        }

        /// <summary>
        /// Clear all words from the Trie.
        /// </summary>
        public void Clear()
        {
            this.RootTrieNode.Clear();
        }

        /// <summary>
        /// Get the equivalent TrieNode in the Trie for given prefix. 
        /// If prefix not present, then return null.
        /// </summary>
        private TrieNode GetTrieNode(string prefix)
        {
            var trieNode = this.RootTrieNode;
            foreach (var prefixChar in prefix)
            {
                trieNode = trieNode.GetChild(prefixChar);
                if (trieNode == null)
                {
                    break;
                }
            }

            return trieNode;
        }

        /// <summary>
        /// Recursive method to add word. Gets the first char of the word, 
        /// creates the child TrieNode if null, and recurses with the first
        /// char removed from the word. If the word length is 0, return.
        /// </summary>
        private void AddWord(TrieNode trieNode, char[] word)
        {
            if (word.Length == 0)
            {
                trieNode.WordCount++;
                return;
            }

            var firstChar = Utilities.FirstChar(word);
            TrieNode child = trieNode.GetChild(firstChar);

            if (child == null)
            {
                child = TrieFactory.CreateTrieNode(firstChar, trieNode);
                trieNode.SetChild(child);
            }

            var charRemoved = Utilities.FirstCharRemoved(word);
            this.AddWord(child, charRemoved);
        }

        /// <summary>
        /// Recursive method to get all the words starting from given TrieNode.
        /// </summary>
        private void GetWords(TrieNode trieNode, ICollection<string> words, StringBuilder buffer)
        {
            if (trieNode.IsWord)
            {
                words.Add(buffer.ToString());
            }

            foreach (var child in trieNode.GetChildren())
            {
                buffer.Append(child.Character);
                this.GetWords(child, words, buffer);

                // Remove recent character
                buffer.Length--;
            }
        }

        /// <summary>
        /// Recursive method to get longest words starting from given TrieNode.
        /// </summary>
        private void GetLongestWords(TrieNode trieNode, ICollection<string> longestWords, StringBuilder buffer, ref int length)
        {
            if (trieNode.IsWord)
            {
                if (buffer.Length > length)
                {
                    longestWords.Clear();
                    length = buffer.Length;
                }

                if (buffer.Length >= length)
                {
                    longestWords.Add(buffer.ToString());
                }
            }

            foreach (var child in trieNode.GetChildren())
            {
                buffer.Append(child.Character);
                this.GetLongestWords(child, longestWords, buffer, ref length);

                // Remove recent character
                buffer.Length--;
            }
        }
    }
}
