namespace Task03.FindWords.TrieImplementation
{
    using System.Collections.Generic;

    /// <summary>
    /// TrieNode is an internal object to encapsulate recursive, helper etc. methods. 
    /// </summary>
    public class TrieNode
    {
        /// <summary>
        /// Create a new TrieNode instance.
        /// </summary>
        /// <param name="character">The character for the TrieNode.</param>
        /// <param name="children">Children of TrieNode.</param>
        /// <param name="isWord">If root TrieNode to this TrieNode is a word.</param>
        /// <param name="wordCount"></param>
        internal TrieNode(char character, IDictionary<char, TrieNode> children, int wordCount, TrieNode parent)
        {
            this.Character = character;
            this.Children = children;
            this.WordCount = wordCount;
            this.Parent = parent;
        }

        /// <summary>
        /// Children Character->TrieNode map.
        /// </summary>
        public IDictionary<char, TrieNode> Children { get; set; }

        /// <summary>
        /// The character for the TrieNode.
        /// </summary>
        internal char Character { get; private set; }

        /// <summary>
        /// Boolean to indicate whether the root to this node forms a word.
        /// </summary>
        internal bool IsWord
        {
            get { return this.WordCount > 0; }
        }

        /// <summary>
        /// The count of words for the TrieNode.
        /// </summary>
        internal int WordCount { get; set; }

        /// <summary>
        /// Parent TrieNode of this TrieNode.
        /// </summary>
        /// <remarks>Required to easily remove word from Trie.</remarks>
        internal TrieNode Parent { get; private set; }

        /// <summary>
        /// For readability.
        /// </summary>
        /// <returns>Character.</returns>
        public override string ToString()
        {
            return this.Character.ToString();
        }

        public override bool Equals(object obj)
        {
            TrieNode that;
            return
                obj != null
                && (that = obj as TrieNode) != null
                && that.Character == this.Character;
        }

        public override int GetHashCode()
        {
            return this.Character.GetHashCode();
        }

        internal IEnumerable<TrieNode> GetChildren()
        {
            return this.Children.Values;
        }

        internal TrieNode GetChild(char character)
        {
            TrieNode trieNode;
            this.Children.TryGetValue(character, out trieNode);
            return trieNode;
        }

        internal void SetChild(TrieNode child)
        {
            this.Children[child.Character] = child;
        }

        internal void RemoveNode(TrieNode rootTrieNode)
        {
            // set this node's word count to 0
            this.WordCount = 0;
            this.RemoveNode_Recursive(rootTrieNode);
        }

        internal void Clear()
        {
            this.WordCount = 0;
            this.Children.Clear();
        }

        private void RemoveChild(char character)
        {
            this.Children.Remove(character);
        }

        /// <summary>
        /// Recursive method to remove word. Remove only if node does not 
        /// have children and is not a word node and has a parent node.
        /// </summary>
        private void RemoveNode_Recursive(TrieNode rootTrieNode)
        {
            if (this.Children.Count == 0 && !this.IsWord && this != rootTrieNode)
            {
                var parent = this.Parent;
                this.Parent.RemoveChild(this.Character);
                this.Parent = null;
                parent.RemoveNode_Recursive(rootTrieNode);
            }
        }
    }
}
