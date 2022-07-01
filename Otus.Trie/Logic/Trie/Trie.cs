namespace Otus.Trie.Logic.Trie
{
    public class Trie
    {
        //public only for test purpose
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

                currentNode = currentNode[character];
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

                currentNode = currentNode[character];
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

                currentNode = currentNode[character];
            }

            return true;
        }
    }
}
