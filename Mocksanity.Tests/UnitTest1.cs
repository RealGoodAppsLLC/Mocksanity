using System;
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

            return baseResult + 5;
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

            var q = new Mock<IDisposable>();

            using var mocksane = MocksaneInitializer.Initialize(
                sut,
                b => b.MakeThing(5));

            using var mocksane2 = MocksaneInitializer.Initialize<Foo, int>(
                sut,
                b => b.MakeThing(5));

            var r = sut.MakeThing(8);

            Assert.Equal(13, r); // r is actually 18 for some reason
        }
    }
}
