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
    //[Ignore("Same same but different")]
    public void AddItem_WhenCalled_ShouldAddItemToList(string title)
    {
        var item = new TodoItem(title, DateTime.Now);
        var list = new List<TodoItem> { item };
        var referenceQuarter = new TodoQuarter() { _todoItems = list };
        var expectedQuarter = new TodoQuarter();

        expectedQuarter.AddItem(title, DateTime.Now);

        Assert.That(referenceQuarter, Is.SameAs(expectedQuarter));
    }

    [Test]
    [TestCase(0)]
    //[TestCase(1)]
    //[TestCase(2)]
    //[Ignore("Same same but different")]
    public void RemoveItem_WhenCalled_ShouldRemoveItemAtPosition(int position)
    {
        List<TodoItem> todoItems = new List<TodoItem> { new TodoItem("water plants", DateTime.Now), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) };
        var referenceQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) });
        TodoQuarter expectedQuarter = new TodoQuarter(todoItems);

        expectedQuarter.RemoveItem(position);

        Assert.AreEqual(expectedQuarter, referenceQuarter);
    }

    [Test]
    //[Ignore("Same same but different")]
    public void ArchiveItems_WhenCalled_ShouldRemoveDoneItems()
    {
        var referenceQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)) });
        var actualQuarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Now, true), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)), new TodoItem("study OOP", DateTime.Now.AddDays(2), true) });

        actualQuarter.ArchiveItems();

        Assert.AreEqual(referenceQuarter, actualQuarter);
    }

    [Test]
    public void ToString_WhenCalled_ShouldPrintOutWholeQuarter()
    {
        var quarter = new TodoQuarter(new List<TodoItem> { new TodoItem("water plants", DateTime.Now, true), new TodoItem("wash windows", DateTime.Now.AddDays(1)), new TodoItem("fix car", DateTime.Now.AddDays(8)), new TodoItem("study OOP", DateTime.Now.AddDays(2), true) });
        string referenceString = "1. [x] 18-5 water plants\n2. [ ] 19-5 wash windows\n3. [ ] 26-5 fix car\n4. [x] 20-5 study OOP\n";

        var expectedString = quarter.ToString();

        Assert.AreEqual(expectedString, referenceString);
    }
}