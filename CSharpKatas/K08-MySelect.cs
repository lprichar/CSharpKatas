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
//    public class TestMySelect
//    {
//        [Test]
//        public void MySelect_GivenAnArrayOfInts_FiltersThem()
//        {
//            int[] ints = { 0, 1, 2, 3 };
//            List<int> oddInts = ints.MySelect(Tripple).ToList();
//            Assert.AreEqual(4, oddInts.Count());
//            Assert.AreEqual(0, oddInts[0]);
//            Assert.AreEqual(3, oddInts[1]);
//            Assert.AreEqual(6, oddInts[2]);
//            Assert.AreEqual(9, oddInts[3]);
//        }

//        private int Tripple(int arg)
//        {
//            return arg * 3;
//        }

//        [Test]
//        public void MySelect_GivenAListOfStrings_ConvertsToIntegers()
//        {
//            var strings = new List<string> { "1", "4", "-10" };
//            List<int> stringsWithO = strings.MySelect(int.Parse).ToList();
//            Assert.AreEqual(3, stringsWithO.Count());
//            Assert.AreEqual(1, stringsWithO[0]);
//            Assert.AreEqual(4, stringsWithO[1]);
//            Assert.AreEqual(-10, stringsWithO[2]);
//        }

//        [Test]
//        public void MySelect_DefersExecution()
//        {
//            int[] ints = { 1, 2, 3, 4, 5 };
//            int timesExecutedLambda = 0;
//            IEnumerable<int> oddIntsQuery = ints.MySelect(i =>
//            {
//                timesExecutedLambda++;
//                return Tripple(i);
//            });
//            Assert.AreEqual(0, timesExecutedLambda, "The lambda of the select clause should not be executed until it is used.");
//            var numberOfOddInts = oddIntsQuery.Count();
//            Assert.AreEqual(5, timesExecutedLambda, "Calling .Count() should execute the lamda of the select clause for each item in the list");
//            var oddIntsList = oddIntsQuery.ToList();
//            Assert.AreEqual(10, timesExecutedLambda, "Converting the IEnumerable to a List should execute the lambda of the select clause for each item in the list");
//            var numberOfOddIntsInList = oddIntsList.Count;
//            Assert.AreEqual(10, timesExecutedLambda, "Getting the number of items in the list should not execute the lambda any more times");
//        }
//    }
//}
