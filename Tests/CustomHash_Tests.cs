using NUnit.Framework;
using Otus.Trie.Logic;

namespace Tests
{
    public class CustomHash_Tests
    {
        [Test]
        public void Can_Insert_To_CustomHash()
        {
            var customHash = new CustomHash();

            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            Assert.IsNotNull(customHash.Root.Nodes['a']);
            Assert.IsNotNull(customHash.Root.Nodes['a'].Nodes['b']);
            Assert.IsNotNull(customHash.Root.Nodes['a'].Nodes['b'].Nodes['c']);
            Assert.IsNull(customHash.Root.Nodes['a'].Nodes['b'].Nodes['d']);
            Assert.IsNull(customHash.Root.Nodes['d']);
        }

        [Test]
        public void Can_Search_In_CustomHash_Small_Word()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isExists = customHash.Search("ab");

            Assert.IsTrue(isExists);
        }

        [Test]
        public void Can_Search_In_CustomHash_Big_Word()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isExists = customHash.Search("abc");

            Assert.IsTrue(isExists);
        }

        [Test]
        public void Can_Search_If_Word_DoesNot_Exists_At_All()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isExists = customHash.Search("qwe");

            Assert.False(isExists);
        }

        [Test]
        public void Can_Search_If_Part_Of_Word_Exists()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isExists = customHash.Search("abcd");

            Assert.False(isExists);
        }

        [Test]
        public void Can_StartWith_If_Part_Of_Word_Exists()
        {
            var customHash = new CustomHash();
            customHash.Insert("abc", "test");
            customHash.Insert("abcd", "test");

            var isStartsWith = customHash.StartsWith("ab");

            Assert.True(isStartsWith);
        }

        [Test]
        public void Can_StartWith_If_Word_Exists_In_Full()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isStartsWith = customHash.StartsWith("ab");

            Assert.True(isStartsWith);
        }

        [Test]
        public void Can_StartWith_If_Part_Of_Word_DoesNot_Exists()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isStartsWith = customHash.StartsWith("abcd");

            Assert.False(isStartsWith);
        }

        [Test]
        public void Can_StartWith_If_Word_DoesNot_Exists_At_All()
        {
            var customHash = new CustomHash();
            customHash.Insert("ab", "test");
            customHash.Insert("abc", "test");

            var isStartsWith = customHash.StartsWith("qwe");

            Assert.False(isStartsWith);
        }

        [Test]
        public void Can_Get_Value()
        {
            var keyToSearch = "abc";
            var valueToSearch = "test_2";

            var customHash = new CustomHash();
            customHash.Insert("ab", "test_1");
            customHash.Insert(keyToSearch, valueToSearch);

            
            var value = customHash.Get(keyToSearch);


            Assert.AreEqual(value, valueToSearch);
        }

        [Test]
        public void CanNot_Get_Value_By_A_Part_Of_Key_If_Value_On_It_DoesNot_Exits()
        {
            var customHash = new CustomHash();
            customHash.Insert("abc", "test_1");
            customHash.Insert("abcd", "test_2");

            var value = customHash.Get("ab");

            Assert.IsNull(value);
        }

        [Test]
        public void CanNot_Get_Value_By_A_Part_Of_Key_If_Value_On_It_Exits()
        {
            var customHash = new CustomHash();
            customHash.Insert("abc", "test_1");

            var value = customHash.Get("abcd");

            Assert.IsNull(value);
        }

        [Test]
        public void CanNot_Get_Value_By_UnExisting_Key()
        {
            var customHash = new CustomHash();
            customHash.Insert("abc", "test_1");
            customHash.Insert("abcd", "test_2");

            var value = customHash.Get("qwe");

            Assert.IsNull(value);
        }
    }
}