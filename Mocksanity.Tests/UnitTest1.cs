using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace RealGoodApps.Mocksanity.Tests
{
    interface ITest
    {
        int Magic(int x);
    }

    public class Foo : ITest
    {
        public virtual int MakeThing(int x)
        {
            return x;
        }

        public int Magic(int x)
        {
            return x + 2;
        }
    }

    public sealed class Bar : Foo
    {
        public override int MakeThing(int x)
        {
            var baseResult = base.MakeThing(x);

            Console.WriteLine("Making a thing Bar.");

            return baseResult + this.NonvirtualMakeThing(x, x - 10, x - 20) + 5;
        }

        public int NonvirtualMakeThing(int x, int y, int z)
        {
            return x + y + z;
        }
    }

    public sealed class Baz
    {
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new Bar();

            using var mocksane = MocksaneInitializer.Initialize(
                sut,
                b => b.NonvirtualMakeThing(50, 40, 30),
                p => 20);

            var r = sut.MakeThing(50);

            Assert.Equal(75, r);
        }
    }
}
