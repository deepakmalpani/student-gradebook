using System;
using System.Reflection;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act
            
            //assert
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);
        }

        [Fact]
        public void TwoVarsReferenceSameObject()
        {
            //arrange    
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
