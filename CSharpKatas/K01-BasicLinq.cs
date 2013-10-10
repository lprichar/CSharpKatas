using NUnit.Framework;

namespace CSharpKatas
{
    public class Kata
    {
        public int SumToN(int start, int count)
        {
            // todo #1: Get all the tests passing
            // todo #2: Refactor so there are no loops or if statements (this is the functional approach and is idiomatic for C#)
            // todo #3: Refactor to use the Aggregate() LINQ method (see 101 Linq Samples: http://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b)
            return 0;
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void SumToN_Start0Count0()
        {
            var kata = new Kata();
            Assert.AreEqual(0, kata.SumToN(0, 0));
        }

        [Test]
        public void SumToN_Start1Count1()
        {
            var kata = new Kata();
            Assert.AreEqual(1, kata.SumToN(1, 1));
        }

        [Test]
        public void SumToN_Start0Count2()
        {
            var kata = new Kata();
            Assert.AreEqual(3, kata.SumToN(0, 3));
        }

        [Test]
        public void SumToN_0To100()
        {
            var kata = new Kata();
            Assert.AreEqual(5050, kata.SumToN(1, 100));
        }

        [Test]
        public void SumToN_100To100()
        {
            var kata = new Kata();
            Assert.AreEqual(199, kata.SumToN(99, 2));
        }
    }
}
