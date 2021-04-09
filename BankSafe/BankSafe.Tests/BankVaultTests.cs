using NUnit.Framework;
using System;

namespace BankSafe
{
    public class BankVaultTests
    {
        private string testName = "TestName";
        private string testID = "111ZZZ";
        Item testItem;
        BankVault testBankVault;

        [SetUp]
        public void Setup()
        {
            testItem = new Item(testName, testID);
            testBankVault = new BankVault();
        }

        [Test]
        public void Corect_Set()
        {
            Assert.AreEqual(testItem.Owner, testName);
            Assert.AreEqual(testItem.ItemId, testID);
        }

        [Test]
        public void Add_Corectly()
        {
            string result = testBankVault.AddItem("A1", testItem);
            Assert.AreEqual(result, $"Item:{testItem.ItemId} saved successfully!");
        }

        [Test]
        public void Add_On_NON_Existing_Cell_Must_Throw_And_Message()
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                string result = testBankVault.AddItem("A5", testItem);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");

        }

        [Test]
        public void Add_Existing_Item_Must_Throw_And_Message()
        {
            string result = testBankVault.AddItem("A1", testItem);


            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                string result = testBankVault.AddItem("A2", testItem);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");

        }

        [Test]
        public void Remove_Corectly()
        {
            string result = testBankVault.AddItem("A2", testItem);
            string removeResult = testBankVault.RemoveItem("A2", testItem);

            Assert.AreEqual(removeResult, $"Remove item:{testItem.ItemId} successfully!");
        }

        [Test]
        public void Remove_From_NON_Existing_Cell()
        {
            string result = testBankVault.AddItem("A2", testItem);


            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                string removeResult = testBankVault.RemoveItem("F2", testItem);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void Remove_NON_Existing_Item()
        {
            string result = testBankVault.AddItem("A2", testItem);


            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                string removeResult = testBankVault.RemoveItem("B2", testItem);
            });

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }



    }
}