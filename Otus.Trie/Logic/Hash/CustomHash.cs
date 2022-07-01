namespace Otus.Trie.Logic.Hash
{
    public class CustomHash<TValue>
    {
        //public only for test purpose
        public readonly Node<TValue> Root;


        public CustomHash()
        {
            Root = new Node<TValue>();
        }


        public void Insert(string key, TValue value)
        {
            var currentNode = Root;

            foreach (var character in key)
            {
                currentNode.Add(character);

                currentNode = currentNode[character];
            }

            currentNode.Value = value;
        }

        public TValue Get(string key)
        {
            var nodeOfKey = GetNode(key);
            if (nodeOfKey == null || !nodeOfKey.IsFullWord)
                return default;

            return nodeOfKey.Value;
        }

        public bool Search(string key)
        {
            var nodeOfKey = GetNode(key);

            return nodeOfKey?.IsFullWord ?? false;
        }

        public bool StartsWith(string prefix)
        {
            var nodeWithWord = GetNode(prefix);

            return nodeWithWord != null;
        }


        #region Support Methods

        private Node<TValue> GetNode(string word)
        {
            var currentNode = Root;

            foreach (var character in word)
            {
                if (!currentNode.IsExists(character))
                    return null;

                currentNode = currentNode[character];
            }

            return currentNode;
        }

        #endregion
    }
}