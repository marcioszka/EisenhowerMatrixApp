using EisenhowerMatrixApp;
using NUnit.Framework;
using System;

namespace EisenhowerMatrixApp.UnitTests;

[TestFixture]
public class TodoQuarterTests
{
    [Test]
    public void Constructor_WhenCalled_ShouldInitializeInstance()
    {
        List<TodoItem> _todoItems = new List<TodoItem> { new TodoItem("water plants", DateTime.Now), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) };

        TodoQuarter todoQuarter = new TodoQuarter();

        Assert.That(todoQuarter, Is.InstanceOf<TodoQuarter>(), "testing todoQuarter");
        Assert.That(todoQuarter, Is.Not.Null);
    }

    [Test]
    public void Constructor_WhenCalled_ShouldInitializeProperties()
    {
        List<TodoItem> todoItems = new List<TodoItem> { new TodoItem("water plants", DateTime.Now), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) };

        TodoQuarter todoQuarter = new TodoQuarter(todoItems);

        Assert.That(todoItems, Is.SameAs(todoQuarter._todoItems), "checking list of object");
    }

    [Test]
    public void GetItems_WhenCalles_ShouldReturnListOfTodoItems()
    {
        List<TodoItem> todoItems = new List<TodoItem> { new TodoItem("water plants", DateTime.Now), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) };
        TodoQuarter todoQuarter = new TodoQuarter(todoItems);

        var list = todoQuarter.GetItems();

        Assert.AreEqual(list, todoItems);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void GetItem_WhenCalled_ShouldReturnTodoItemAtPosition(int position)
    {
        List<TodoItem> todoItems = new List<TodoItem> { new TodoItem("water plants", DateTime.Now), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) };
        TodoQuarter todoQuarter = new TodoQuarter(todoItems);

        var item = todoQuarter.GetItem(position);

        Assert.AreEqual(todoQuarter._todoItems[position], item);
    }

    [Test]
    [TestCase("wash the dishes")]
    [TestCase("feed the fish")]
    [TestCase("study c#")]
    public void AddItem_WhenCalled_ShouldAddItemToList(string title)
    {
        var item = new TodoItem(title, DateTime.Parse("27-6-2023"));
        var list = new List<TodoItem> { item };
        var referenceQuarter = new TodoQuarter() { _todoItems = list };
        var expectedQuarter = new TodoQuarter();

        expectedQuarter.AddItem(title, DateTime.Parse("27-6-2023"));

        Assert.That(referenceQuarter.Equals(expectedQuarter), Is.True);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void RemoveItem_WhenCalled_ShouldRemoveItemAtPosition(int position)
    {
        List<TodoItem> todoItems = new List<TodoItem> { new TodoItem("water plants", DateTime.Parse("19-5-2023")), new TodoItem("wash windows", DateTime.Parse("20-5-2023")), new TodoItem("fix car", DateTime.Parse("27-5-2023")) };
        TodoQuarter referenceQuarter = null;
        switch (position)
        {
            case 0:
                referenceQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("wash windows", DateTime.Parse("20-5-2023")), new TodoItem("fix car", DateTime.Parse("27-5-2023")) });
                break;
            case 1:
                referenceQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Parse("19-5-2023")), new TodoItem("fix car", DateTime.Parse("27-5-2023")) });
                break;
            case 2:
                referenceQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Parse("19-5-2023")), new TodoItem("wash windows", DateTime.Parse("20-5-2023")) });
                break;
        }
        TodoQuarter expectedQuarter = new TodoQuarter(todoItems);

        expectedQuarter.RemoveItem(position);

        Assert.That(referenceQuarter.Equals(expectedQuarter), Is.True);
    }

    [Test]
    public void ArchiveItems_WhenCalled_ShouldRemoveDoneItems()
    {
        var referenceQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("wash windows", DateTime.Parse("20-5-2023")), new TodoItem("fix car", DateTime.Parse("27-5-2023")) });
        var actualQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Parse("19-5-2023"), true), new TodoItem("wash windows", DateTime.Parse("20-5-2023")), new TodoItem("fix car", DateTime.Parse("27-5-2023")), new TodoItem("study OOP", DateTime.Parse("21-5-2023"), true) });

        actualQuarter.ArchiveItems();

        Assert.That(referenceQuarter.Equals(actualQuarter), Is.True);
    }

    [Test]
    [Ignore("Fix dates in manually added items")]
    public void ToString_WhenCalled_ShouldPrintOutWholeQuarter()
    {
        var quarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Now, true), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)), new TodoItem("study OOP", DateTime.Now.AddDays(2), true) });
        string referenceString = "1. [x] 18-5 water plants\n2. [ ] 19-5 wash windows\n3. [ ] 26-5 fix car\n4. [x] 20-5 study OOP\n";

        var expectedString = quarter.ToString();

        Assert.AreEqual(expectedString, referenceString);
    }


    [Test]
    public void TodoItem_Equals_WhenCalled_ShouldCompareTwoObjects()
    {
        string date1 = "23-5-2023";
        string date2 = "23-5-2023";
        var item1 = new TodoItem("abba", DateTime.Parse(date1), false);
        var item2 = new TodoItem("abba", DateTime.Parse(date2), false);

        Assert.That(item1.Equals(item2), Is.True);

    }
}