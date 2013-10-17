//// ReSharper disable PossibleMultipleEnumeration
//// ReSharper disable LoopCanBeConvertedToQuery
//// ReSharper disable UnusedVariable

//using System.Collections.Generic;
//using System.Linq;
//using NUnit.Framework;

//namespace CSharpKatas
//{
//    // Todo #1: Uncoment everything (Ctr-A, Ctr-KU)
//    // Todo #2: Make all the tests pass without using LINQ

//    [TestFixture]
//    public class TestMyWhere
//    {
//        [Test]
//        public void MyWhere_GivenAnArrayOfInts_FiltersThem()
//        {
//            int[] ints = { 1, 2, 3, 4, 5 };
//            List<int> oddInts = ints.MyWhere(IsOdd).ToList();
//            Assert.AreEqual(3, oddInts.Count());
//            Assert.AreEqual(1, oddInts[0]);
//            Assert.AreEqual(3, oddInts[1]);
//            Assert.AreEqual(5, oddInts[2]);
//        }

//        [Test]
//        public void MyWhere_GivenAListOfStrings_FiltersThem()
//        {
//            var strings = new List<string> { "two", "roads", "diverged", "in", "a", "yellow", "wood" };
//            List<int> stringsWithO = strings.MyWhere(i => i.Contains("o")).ToList();
//            Assert.AreEqual(4, stringsWithO.Count());
//            Assert.AreEqual("two", stringsWithO[0]);
//            Assert.AreEqual("roads", stringsWithO[1]);
//            Assert.AreEqual("yellow", stringsWithO[2]);
//            Assert.AreEqual("wood", stringsWithO[3]);
//        }

//        [Test]
//        public void MyWhere_DefersExecution()
//        {
//            int[] ints = { 1, 2, 3, 4, 5 };
//            int timesExecutedLambda = 0;
//            IEnumerable<int> oddIntsQuery = ints.MyWhere(i =>
//            {
//                timesExecutedLambda++;
//                return IsOdd(i);
//            });
//            Assert.AreEqual(0, timesExecutedLambda, "The lambda of the where clause should not be executed until it is used.");
//            var numberOfOddInts = oddIntsQuery.Count();
//            Assert.AreEqual(5, timesExecutedLambda, "Calling .Count() should execute the lamda of the where clause for each item in the list");
//            var oddIntsList = oddIntsQuery.ToList();
//            Assert.AreEqual(10, timesExecutedLambda, "Converting the IEnumerable to a List should execute the lambda of the where clause for each item in the list");
//            var numberOfOddIntsInList = oddIntsList.Count;
//            Assert.AreEqual(10, timesExecutedLambda, "Getting the number of items in the list should not execute the lambda any more times");
//        }

//        private static bool IsOdd(int i)
//        {
//            return i % 2 == 1;
//        }
//    }
//}
