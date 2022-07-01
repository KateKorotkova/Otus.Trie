namespace Otus.Trie.Logic.Trie
{
    public class Node
    {
        //public only for test purpose
        public readonly Node[] Nodes;
        public bool IsFullWord { get; set; }
        public Node this[int character] => Nodes[character];


        public Node()
        {
            Nodes = new Node[256];
        }


        public bool IsExists(char character)
        {
            return Nodes[character] != null;
        }

        public void Add(char character)
        {
            if(IsExists(character))
                return;

            Nodes[character] = new Node();
        }
    }
}