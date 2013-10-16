// ReSharper disable CSharpWarnings::CS0162
// ReSharper disable ConvertToConstant.Local
// ReSharper disable RedundantLogicalConditionalExpressionOperand
// ReSharper disable ConditionIsAlwaysTrueOrFalse

using System;
using NUnit.Framework;

namespace CSharpKatas
{
    public class CSharpNaturalLanguageConverter
    {
        public string Convert(Func<bool> func)
        {
            return null;
        }
    }

    [TestFixture]
    [Ignore]
    public class LinqProvidersTest
    {
        [Test]
        public void Convert_True_ConvertedToYes()
        {
            // todo #1: Remove the ignore attribute and get the tests passing. Changing the paremeter of the function is ok, but not the unit tests
            // todo #2: This is a terrible non-real world example because a real example would be too involved. So how is this feature really used?

            var languageConverter = new CSharpNaturalLanguageConverter();
            string actual = languageConverter.Convert(() => true);
            Assert.AreEqual("Yes", actual);
        }
        
        [Test]
        public void Convert_False_ConvertedToNo()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            string actual = languageConverter.Convert(() => false);
            Assert.AreEqual("No", actual);
        }
        
        [Test]
        public void Convert_Variables_FirstLetterCapitalized()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var cat = false;
            string actual = languageConverter.Convert(() => cat);
            Assert.AreEqual("Cat", actual);
        }

        [Test]
        public void Convert_SingleLetterVariables_FirstLetterCapitalized()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var a = false;
            string actual = languageConverter.Convert(() => a);
            Assert.AreEqual("A", actual);
        }

        [Test]
        public void Convert_OperatorsAndVariables_MapToStrings()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var cat = false;
            var dog = true;
            string actual = languageConverter.Convert(() => cat && dog);
            Assert.AreEqual("Cat and Dog", actual);
        }

        [Test]
        public void Convert_OrOperator_MapToOr()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var cat = false;
            var dog = true;
            string actual = languageConverter.Convert(() => cat || dog);
            Assert.AreEqual("Cat or Dog", actual);
        }

        [Test]
        public void Convert_LogicalOr_MapToLogialOr()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var cat = false;
            var dog = true;
            string actual = languageConverter.Convert(() => dog | cat);
            Assert.AreEqual("Dog (or) Cat", actual);
        }

        [Test]
        public void Convert_LogicalAnd_MapToLogialAnd()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var cat = false;
            var dog = true;
            string actual = languageConverter.Convert(() => dog & cat);
            Assert.AreEqual("Dog (and) Cat", actual);
        }

        [Test]
        public void Convert_OperatorsAndVariables_RecurseIndefinetely()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            var cat = false;
            string actual = languageConverter.Convert(() => cat && cat && cat && cat);
            Assert.AreEqual("Cat and Cat and Cat and Cat", actual);
        }

        [Test]
        public void Convert_ConstantsInOperators_StillConvertToNaturalLanguage()
        {
            var languageConverter = new CSharpNaturalLanguageConverter();
            bool yes = false;
            string actual = languageConverter.Convert(() => yes && false && true);
            Assert.AreEqual("Yes and No and Yes", actual);
        }
    }
}
