using System;
using NUnit.Framework;
using UnitTestingTutorial.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        Stack<object> _stack;
        
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<object>();
        }
        
        [Test]
        public void Count_EmptyStack_Return0()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void Push_NullArgument_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_AddArgumentInStack()
        {
            object obj = new object();
            _stack.Push(obj);
            
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Pop_NotEmptyStack_RemoveLastElementInStack()
        {
            object obj = new object();
            _stack.Push(obj);
            _stack.Push(obj);
            _stack.Push(obj);
            _stack.Pop();
            
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Pop_WhenCalled_ReturnRemovedElement()
        {
            object obj = new object();
            object obj1 = new object();
            object obj2 = new object();
            
            _stack.Push(obj);
            _stack.Push(obj1);
            _stack.Push(obj2);
            
            object removedElement = _stack.Pop();
            
            Assert.That(removedElement, Is.EqualTo(obj2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_NotEmptyStack_ReturnLastElementInStack()
        {
            object obj = new object();
            _stack.Push(obj);

            object lastElementInStack = _stack.Peek();
            
            Assert.That(lastElementInStack, Is.EqualTo(obj));
        }

        [Test]
        public void Peek_NotEmptyStack_DoesNotRemoveLastElementInStack()
        {
            object obj = new object();
            object obj1 = new object();
            object obj2 = new object();
            
            _stack.Push(obj);
            _stack.Push(obj1);
            _stack.Push(obj2);

            _stack.Peek();
            
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}