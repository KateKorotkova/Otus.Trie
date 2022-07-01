namespace Otus.Trie.Logic
{
    public class CustomHash<TValue>
    {
        public readonly NodeForCustomHash<TValue> Root;


        public CustomHash()
        {
            Root = new NodeForCustomHash<TValue>();
        }


        public void Insert(string word, TValue value)
        {
            var currentNode = Root;

            foreach (var character in word)
            {
                currentNode.Add(character);

                currentNode = currentNode.Get(character);
            }

            currentNode.Value = value;
        }

        public TValue Get(string word)
        {
            var nodeWithWord = GetNode(word);
            if (nodeWithWord == null || !nodeWithWord.IsFullWord)
                return default;

            return nodeWithWord.Value;
        }

        public bool Search(string word)
        {
            var nodeWithWord = GetNode(word);

            return nodeWithWord?.IsFullWord ?? false;
        }

        public bool StartsWith(string prefix)
        {
            var nodeWithWord = GetNode(prefix);

            return nodeWithWord != null;
        }


        #region Support Methods

        private NodeForCustomHash<TValue> GetNode(string word)
        {
            var currentNode = Root;

            foreach (var character in word)
            {
                if (!currentNode.IsExists(character))
                    return null;

                currentNode = currentNode.Get(character);
            }

            return currentNode;
        }

        #endregion
    }


    public class NodeForCustomHash<TValue>
    {
        public readonly NodeForCustomHash<TValue>[] Nodes;
        public bool IsFullWord => Value != null;
        public TValue Value { get; set; }


        public NodeForCustomHash()
        {
            Nodes = new NodeForCustomHash<TValue>[256];
        }


        public bool IsExists(char character)
        {
            return Nodes[character] != null;
        }

        public NodeForCustomHash<TValue> Get(char character)
        {
            return Nodes[character];
        }

      
        public void Add(char character)
        {
            if (!IsExists(character))
                Nodes[character] = new NodeForCustomHash<TValue>();
        }
    }
}