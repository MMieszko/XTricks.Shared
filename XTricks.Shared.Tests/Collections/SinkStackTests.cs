using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using XTricks.Shared.Collections;

namespace XTricks.Shared.Tests.Collections
{
    [TestFixture]
    public class SinkStackTests
    {
        [Test]
        public void Ctor_Negative_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new SinkStack<object>(-1));
        }

        [Test]
        public void Ctor_Zero_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new SinkStack<object>(0));
        }

        [Test]
        public void Push()
        {
            var stack = new SinkStack<object>(5);

            stack.Push(new object());
            stack.Push(new object());
            stack.Push(new object());

            stack.Count.Should().Be(3);
        }

        [Test]
        public void Pop()
        {
            var stack = new SinkStack<object>(5);

            stack.Push(new object());
            stack.Push(new object());
            stack.Push(new object());

            stack.Pop();
            stack.Pop();

            stack.Count.Should().Be(1);
        }

        [Test]
        public void Pop_TooMuch_Throws()
        {
            var stack = new SinkStack<object>(5);

            stack.Push(new object());
            stack.Push(new object());
            stack.Push(new object());

            stack.Pop();
            stack.Pop();
            stack.Pop();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek()
        {
            var stack = new SinkStack<TestObject>(100);

            var obj1 = new TestObject(1);
            var obj2 = new TestObject(2);
            var obj3 = new TestObject(3);

            stack.Push(obj1);
            stack.Push(obj2);
            stack.Push(obj3);

            stack.Pop();
            stack.Pop();
            stack.Peek().Id.Should().Be(1);
        }

        [Test]
        public void ToList()
        {
            var items = new SinkStack<object>(20);

            items.Push(new object());

            var list = items.ToList();
        }

        private class TestObject
        {
            public int Id { get; }

            public TestObject(int id)
            {
                this.Id = id;
            }
        }
    }
}
