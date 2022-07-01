namespace Otus.Trie.Logic
{
    public class CustomHash
    {
        public readonly NodeForCustomHash Root;


        public CustomHash()
        {
            Root = new NodeForCustomHash();
        }


        public void Insert(string word, string value)
        {
            var currentNode = Root;

            foreach (var character in word)
            {
                currentNode.Add(character);

                currentNode = currentNode.Get(character);
            }

            currentNode.Value = value;
        }

        public string Get(string word)
        {
            var nodeWithWord = GetNode(word);
            if (nodeWithWord == null || !nodeWithWord.IsFullWord)
                return null;

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

        private NodeForCustomHash GetNode(string word)
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


    public class NodeForCustomHash
    {
        public readonly NodeForCustomHash[] Nodes;
        public bool IsFullWord => Value != null;
        public string Value { get; set; }


        public NodeForCustomHash()
        {
            Nodes = new NodeForCustomHash[256];
        }


        public bool IsExists(char character)
        {
            return Nodes[character] != null;
        }

        public NodeForCustomHash Get(char character)
        {
            return Nodes[character];
        }

      
        public void Add(char character)
        {
            if (!IsExists(character))
                Nodes[character] = new NodeForCustomHash();
        }
    }
}