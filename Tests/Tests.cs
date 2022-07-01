using NUnit.Framework;
using Otus.Trie.Logic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Can_Insert_To_Trie()
        {
            var trie = new Trie();

            trie.Insert("ab");
            trie.Insert("abc");

            Assert.IsNotNull(trie.Root.Nodes['a']);
            Assert.IsNotNull(trie.Root.Nodes['a'].Nodes['b']);
            Assert.IsNotNull(trie.Root.Nodes['a'].Nodes['b'].Nodes['c']);
            Assert.IsNull(trie.Root.Nodes['a'].Nodes['b'].Nodes['d']);
            Assert.IsNull(trie.Root.Nodes['d']);
        }

        [Test]
        public void Can_Search_In_Trie_Small_Word()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isExists = trie.Search("ab");

            Assert.IsTrue(isExists);
        }

        [Test]
        public void Can_Search_In_Trie_Big_Word()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isExists = trie.Search("abc");

            Assert.IsTrue(isExists);
        }

        [Test]
        public void Can_Search_If_Word_DoesNot_Exists_At_All()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isExists = trie.Search("qwe");

            Assert.False(isExists);
        }

        [Test]
        public void Can_Search_If_Part_Of_Word_Exists()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isExists = trie.Search("abcd");

            Assert.False(isExists);
        }

        [Test]
        public void Can_StartWith_If_Part_Of_Word_Exists()
        {
            var trie = new Trie();
            trie.Insert("abc");
            trie.Insert("abcd");

            var isStartsWith = trie.StartsWith("ab");

            Assert.True(isStartsWith);
        }

        [Test]
        public void Can_StartWith_If_Word_Exists_In_Full()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isStartsWith = trie.StartsWith("ab");

            Assert.True(isStartsWith);
        }

        [Test]
        public void Can_StartWith_If_Part_Of_Word_DoesNot_Exists()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isStartsWith = trie.StartsWith("abcd");

            Assert.False(isStartsWith);
        }

        [Test]
        public void Can_StartWith_If_Word_DoesNot_Exists_At_All()
        {
            var trie = new Trie();
            trie.Insert("ab");
            trie.Insert("abc");

            var isStartsWith = trie.StartsWith("qwe");

            Assert.False(isStartsWith);
        }
    }
}