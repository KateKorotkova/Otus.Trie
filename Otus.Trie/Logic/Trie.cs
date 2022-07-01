namespace Otus.Trie.Logic
{
    public class Trie
    {
        public readonly Node Root;

        public Trie()
        {
            Root = new Node();
        }


        public void Insert(string word)
        {
            var currentNode = Root;

            foreach (var character in word)
            {
                currentNode.Add(character);

                currentNode = currentNode.Get(character);
            }

            currentNode.IsFullWord = true;
        }

        public bool Search(string word)
        {
            var currentNode = Root;

            foreach (var character in word)
            {
                if (!currentNode.IsExists(character))
                    return false;

                currentNode = currentNode.Get(character);
            }

            return currentNode.IsFullWord;
        }

        public bool StartsWith(string prefix)
        {
            var currentNode = Root;

            foreach (var character in prefix)
            {
                if (!currentNode.IsExists(character))
                    return false;

                currentNode = currentNode.Get(character);
            }

            return true;
        }
    }


    public class Node
    {
        public readonly Node[] Nodes;
        public bool IsFullWord;

        
        public Node()
        {
            Nodes = new Node[256];
        }


        public bool IsExists(char character)
        {
            return Nodes[character] != null;
        }

        public Node Get(char character)
        {
            return Nodes[character];
        }

        public void Add(char character)
        {
            if (!IsExists(character))
                Nodes[character] = new Node();
        }
    }
}
