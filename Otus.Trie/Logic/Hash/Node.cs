namespace Otus.Trie.Logic.Hash
{
    public class Node<TValue>
    {
        //public only for test purpose
        public readonly Node<TValue>[] Nodes;
        public TValue Value { get; set; }

        public bool IsFullWord => Value != null;
        public Node<TValue> this[int character] => Nodes[character];


        public Node()
        {
            Nodes = new Node<TValue>[256];
        }


        public bool IsExists(char character)
        {
            return Nodes[character] != null;
        }

        public void Add(char character)
        {
            if (IsExists(character))
                return;

            Nodes[character] = new Node<TValue>();
        }
    }
}