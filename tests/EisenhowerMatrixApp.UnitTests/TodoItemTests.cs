using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NUnit.Framework;

namespace EisenhowerMatrixApp.UnitTests;

[TestFixture]
public class TodoItemTests
{
    [Test]
    public void Constructor_WhenCalled_ShouldInitializeInstance()
    {
        TodoItem testItem = new TodoItem("Test", DateTime.Now);


        Assert.That(testItem, Is.InstanceOf<TodoItem>(), "Test initialization of TodoItem");
        Assert.That(testItem, Is.InstanceOf<TodoItem>(), "Test initialization of TodoItem");
    }

    public static IEnumerable TestUndoneTodoItemsData
    {
        get
        {
            yield return new TestCaseData("Test", new DateTime(2000, 1, 1), false);
            yield return new TestCaseData("Test", new DateTime(2000, 7, 30), false);
        }
    }
    
    public static IEnumerable TestDoneTodoItemsData
    {
        get
        {
             
            yield return new TestCaseData("Test", new DateTime(2000, 8, 4), true);
            yield return new TestCaseData("Test", new DateTime(2000, 2, 3), true);
            
        }
    }

    [Test]
    [TestCaseSource(nameof(TestUndoneTodoItemsData))]
    public void Constructor_WhenCalled_ShouldInitializeProperties(string title, DateTime deadline, bool isDone)
    {
        TodoItem todoItem = new TodoItem(title, (DateTime)deadline, isDone);
        Assert.AreEqual(title, todoItem.GetTitle());
        Assert.AreEqual(deadline, todoItem.GetDeadline());
        Assert.AreEqual(isDone, todoItem.IsDone());
    }

    [Test]
    [TestCaseSource(nameof(TestDoneTodoItemsData))]
    public void Mark_WhenCalledOnMarked_ShouldNotChangeIsDone(string title, DateTime deadline, bool isDone)
    {
        TodoItem todoItem = new TodoItem(title, (DateTime)deadline, isDone);
        Assert.AreEqual(true, todoItem.IsDone(),"Initial state of isDone should be true"); //too much
        todoItem.Mark();
        Assert.AreEqual(true, todoItem.IsDone(), "State of isDone after .Unmark() should still be true");
    }


    [Test]
    [TestCaseSource(nameof(TestUndoneTodoItemsData))]
    public void Mark_WhenCalledOnUnmarked_ShouldChangeIsDone(string title, DateTime deadline, bool isDone)
    {
        TodoItem todoItem = new TodoItem(title, (DateTime)deadline, isDone);
        Assert.AreEqual(false, todoItem.IsDone(),"Initial state of isDone should be false"); //too much
        todoItem.Mark();
        Assert.AreEqual(true, todoItem.IsDone(), "State of isDone after .Mark() should be true");
        todoItem.Mark();
        Assert.AreEqual(true, todoItem.IsDone(),"State of isDone after calling .Mark() twice should be still true");
    }
    
    [Test]
    [TestCaseSource(nameof(TestDoneTodoItemsData))]
    public void Unmark_WhenCalledOnMarked_ShouldChangeIsDone(string title, DateTime deadline, bool isDone)
    {
        TodoItem todoItem = new TodoItem(title, (DateTime)deadline, isDone);
        Assert.AreEqual(true, todoItem.IsDone(),"Initial state of isDone should be true"); //too much
        todoItem.Unmark();
        Assert.AreEqual(false, todoItem.IsDone(), "State of isDone after .Unmark() should be false");
        todoItem.Unmark();
        Assert.AreEqual(false, todoItem.IsDone(),"State of isDone after calling .Unmark() twice should still be false");
    }


    [Test]
    [TestCaseSource(nameof(TestUndoneTodoItemsData))]
    public void Unmark_WhenCalledOnUnmarked_ShouldNotChangeIsDone(string title, DateTime deadline, bool isDone)
    {
        TodoItem todoItem = new TodoItem(title, (DateTime)deadline, isDone);
        Assert.AreEqual(false, todoItem.IsDone(),"Initial state of isDone should be false"); //too much
        todoItem.Unmark();
        Assert.AreEqual(false, todoItem.IsDone(), "State of isDone after .Unmark() should still be false");
    }

    public static IEnumerable TestTodoItemsDataWithExpectedToString
    {
        //$"[{GetSymbolForStatus()}] {ChangeDeadlineFormat()} {_title}";
        get
        {
            yield return new TestCaseData("Test", new DateTime(2000, 1, 1), false, "[ ] 1-1 Test");
            yield return new TestCaseData("Title", new DateTime(2000, 3, 2), true, "[x] 2-3 Title");
        }
        
    }

    [Test]
    [TestCaseSource(nameof(TestTodoItemsDataWithExpectedToString))]
    public void ToString_WhenCalled_ShouldReturnDateInExpectedFormat(string title, DateTime deadline, bool isDone, string expectedString)
    {
        TodoItem todoItem = new TodoItem(title, deadline, isDone);
        Assert.AreEqual(expectedString, todoItem.ToString());
    }
}