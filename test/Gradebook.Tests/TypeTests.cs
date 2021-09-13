using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Security.Principal;
using Xunit;

namespace Gradebook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPoinToMethod(){
             WriteLogDelegate log = ReturnMessage;

             log += ReturnMessage;
             log += IncrementCount;

             var result = log("Hello");
             Assert.Equal(3,count);
        }
        string ReturnMessage(string message){
            count++;
            return message;
        }
        string IncrementCount(string message){
            count++;
            return message.ToLower();
        }
        [Fact]
        public void PassingValueTypes(){
            //arrange
            var x=GetInt();
            SetInt(ref x);
            //act
            
            //assert
            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x=42;
        }

        private int GetInt()
        {
            return 3;
        }
        
        [Fact]
        public void StringBehavesLikeValueTypes(){
            //arrange
            string name = "Scott";
            string upper = MakeUpperCase(name);
            //act
            
            //assert
            Assert.Equal("Scott",name);
            Assert.Equal("SCOTT",upper);
        }

        private string MakeUpperCase(string x)
        {
            return x.ToUpper();
        }

        [Fact]
        public void CSharpCanPassByRef(){
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1,"New name");
            //act
            
            //assert
            Assert.Equal("New name",book1.Name);
        }
        
        private void GetBookSetNameByRef(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue(){
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1,"New name");
            //act
            
            //assert
            Assert.Equal("Book 1",book1.Name);
        }
        
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            SetName(book1,"New name");
            //act
            
            //assert
            Assert.Equal("New name",book1.Name);
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }


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

        private Book GetBook(string name)
        {
            return new Book(name);
        }
        
        
    }
}
