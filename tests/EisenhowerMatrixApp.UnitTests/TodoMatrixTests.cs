using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace EisenhowerMatrixApp.UnitTests
{
    [TestFixture]
    public class TodoMatrixTests
    {
        private TodoMatrix _todoMatrix;

        [SetUp]
        public void SetUp()
        {
            _todoMatrix = new TodoMatrix();
        }

        [Test]
        public void GetQuarters_ReturnsAllQuarters()
        {
            var quarters = _todoMatrix.GetQuarters();

            Assert.AreEqual(4, quarters.Count);
            Assert.IsTrue(quarters.ContainsKey("IU"));
            Assert.IsTrue(quarters.ContainsKey("IN"));
            Assert.IsTrue(quarters.ContainsKey("NU"));
            Assert.IsTrue(quarters.ContainsKey("NN"));
        }

        [Test]
        public void GetQuarter_ValidStatus_ReturnsQuarter()
        {
            var quarter = _todoMatrix.GetQuarter("IU");

            Assert.IsNotNull(quarter);
        }

        [Test]
        public void AddItem_ImportantAndUrgent_AddsItemToIUQuarter()
        {
            var title = "Important and Urgent Task";
            var deadline = DateTime.Now.AddDays(2);
            var isImportant = true;

            _todoMatrix.AddItem(title, deadline, isImportant);

            var quarter = _todoMatrix.GetQuarter("IU");
            Assert.AreEqual(1, quarter.GetItems().Count);
            Assert.AreEqual(title, quarter.GetItems()[0].GetTitle());
        }

        [Test]
        public void AddItem_ImportantAndNotUrgent_AddsItemToINQuarter()
        {
            var title = "Important but Not Urgent Task";
            var deadline = DateTime.Now.AddDays(5);
            var isImportant = true;

            _todoMatrix.AddItem(title, deadline, isImportant);

            var quarter = _todoMatrix.GetQuarter("IN");
            Assert.AreEqual(1, quarter.GetItems().Count);
            Assert.AreEqual(title, quarter.GetItems()[0].GetTitle());
        }

        [Test]
        public void AddItem_NotImportantAndUrgent_AddsItemToNUQuarter()
        {
            var title = "Not Important but Urgent Task";
            var deadline = DateTime.Now.AddDays(1);
            var isImportant = false;

            _todoMatrix.AddItem(title, deadline, isImportant);

            var quarter = _todoMatrix.GetQuarter("NU");
            Assert.AreEqual(1, quarter.GetItems().Count);
            Assert.AreEqual(title, quarter.GetItems()[0].GetTitle());
        }

        [Test]
        public void AddItem_NotImportantAndNotUrgent_AddsItemToNNQuarter()
        {
            var title = "Not Important and Not Urgent Task";
            var deadline = DateTime.Now.AddDays(7);
            var isImportant = false;

            _todoMatrix.AddItem(title, deadline, isImportant);

            var quarter = _todoMatrix.GetQuarter("NN");
            Assert.AreEqual(1, quarter.GetItems().Count);
            Assert.AreEqual(title, quarter.GetItems()[0].GetTitle());
        }

        [Test]
        public void ArchiveItems_ArchivesAllItemsInQuarters()
        {
            _todoMatrix.AddItem("Task 1", DateTime.Now.AddDays(1), true);
            _todoMatrix.AddItem("Task 2", DateTime.Now.AddDays(2), false);
            _todoMatrix.AddItem("Task 3", DateTime.Now.AddDays(3), true);

            _todoMatrix.ArchiveItems();

            var quarters = _todoMatrix.GetQuarters();
            foreach (var quarter in quarters.Values)
            {
                Assert.AreEqual(0, quarter.GetItems().Count);
            }
        }

        [Test]
        public void ToString_ReturnsMatrixStringRepresentation()
        {
            var quarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Now, true), 
                new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)), 
                new TodoItem("study OOP", DateTime.Now.AddDays(2), true) });

            string referenceString = "1. [x] 19-5 water plants\n2. [ ] 20-5 wash windows\n3. [ ] 27-5 fix car\n4. [x] 21-5 study OOP\n";

            var _todoMatrix = new TodoMatrix();
            _todoMatrix.AddItem("water plants", DateTime.Now, true);
            _todoMatrix.AddItem("wash windows", DateTime.Now.AddDays(1));
            _todoMatrix.AddItem("fix car", DateTime.Now.AddDays(8));
            _todoMatrix.AddItem("study OOP", DateTime.Now.AddDays(2), true);


            var matrixString = "IU\n1. [ ] 19-5 water plants\n\nNU\n2. [ ] 20-5 wash windows\n\nNN\n3. [ ] 27-5 fix car\n\nIU\n4. [ ] 21-5 study OOP";

            var expectedOutput = _todoMatrix.ToString();
            Assert.AreEqual(expectedOutput, matrixString);
        }
    }
}
