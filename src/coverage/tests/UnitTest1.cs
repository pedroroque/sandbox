using System;
using Domain;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var stuff = Class1.GetStuff();
            Assert.Equal("Stuff", stuff);
        }


        public void Test2() {
            var result = Class1.GetAnotherSuff();
            Assert.Equal("AnotherStuff",result);
        }
    }
}
