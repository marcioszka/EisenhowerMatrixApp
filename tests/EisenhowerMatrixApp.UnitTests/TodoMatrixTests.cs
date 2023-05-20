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

        //[Test]
        //public void IsItemUrgent_ReturnsTrueWhenDeadlineIsWithinTimeSpan()
        //{
        //    int timeSpan = 3;
        //    DateTime deadline = DateTime.Now.AddDays(timeSpan - 1);
        //    var item = new TodoItem("Water plants", deadline, true);
            
        //    bool isUrgent = _todoMatrix.IsItemUrgent(deadline);

        //    Assert.IsTrue(isUrgent);
        //}

        [Test]
        public void ArchiveItems_ArchivesAllItemsInQuarters()
        {
            _todoMatrix.AddItem("Water plants", DateTime.Now.AddDays(1), true);
            _todoMatrix.AddItem("Wash windows", DateTime.Now.AddDays(2), false);
            _todoMatrix.AddItem("Fix car", DateTime.Now.AddDays(3), true);

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
            var quarter = new TodoQuarter(new List<TodoItem> { new TodoItem("Water plants", DateTime.Now, true), 
                new TodoItem("Wash windows", DateTime.Now.AddDays(1)), new TodoItem("Fix car", DateTime.Now.AddDays(8)), 
                new TodoItem("Study OOP", DateTime.Now.AddDays(2), true) });

            var _todoMatrix = new TodoMatrix();
            _todoMatrix.AddItem("Water plants", DateTime.Now, true);
            _todoMatrix.AddItem("Wash windows", DateTime.Now.AddDays(1));
            _todoMatrix.AddItem("Fix car", DateTime.Now.AddDays(8));
            _todoMatrix.AddItem("Study OOP", DateTime.Now.AddDays(2), true);


            var matrixString = "IU\n1. [ ] 20-5 Water plants\n2. [ ] 22-5 Study OOP\n\n\nIN\n\n\nNU\n1. [ ] 21-5 Wash windows\n\n\nNN\n1. [ ] 28-5 Fix car\n\n\n";

            var expectedOutput = _todoMatrix.ToString();
            Assert.AreEqual(expectedOutput, matrixString);
        }
    }
}
