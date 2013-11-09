using System.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas
{
    public class ProjectLog
    {
        public ProjectLog(string logLine)
        {
            var bits = logLine.Split(',');
            EntryDate = DateTime.Parse(bits[0]);
            Message = bits[1];
        }

        public DateTime EntryDate { get; set; }
        public string Message { get; set; }
    }

    public class LogParser
    {
        public IEnumerable<string> GetMessagesWithinRange(string projectName, DateTime start, DateTime end)
        {
            string fileName = string.Format("C:\\temp\\Log-{0}.csv", projectName);
            if (!File.Exists(fileName)) return Enumerable.Empty<string>();
            var allLines = File.ReadAllLines(fileName);
            return allLines
                .Select(i => new ProjectLog(i))
                .Where(i => i.EntryDate > start && i.EntryDate < end)
                .Select(i => i.Message);
        }
    }

    [TestFixture]
    [Ignore]
    public class TestDoStuff
    {
        [Test]
        public void GetRowsWithinRange_ThereIsARowWithinRange_ItsMessageIsReturned()
        {
            // todo #0: Remove the Ignore attribute
            // todo #1: Start to clean this up by focusing on LogParser. Extract out its File IO logic into a separate class so doesn't violate the single responsiblity principle (http://en.wikipedia.org/wiki/Solid_(object-oriented_design)).
            // todo #2: Implement the Inversion of Control (IoC) pattern in LogParser so that you could potentially use a separate implementation for the File IO logic
            // todo #3: Refactor the unit tests so that they never interact with the file system. Do this by subclassing the new class you created in #1 and injecting that into LogParser.
            // todo #4: Now that you've done dependency injection manually, redo #3 with Moq.  Get it via nuget, read the examples in the documentation on their website.
            
            var logParser = GetAndInitLogParser("C:\\temp\\Log-Proj1.csv", "1/1/2013 5:00 PM,Begin logging");
            var actual = logParser.GetMessagesWithinRange("Proj1", new DateTime(2013, 1, 1), new DateTime(2013, 1, 2)).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Begin logging", actual[0]);
        }

        public LogParser GetAndInitLogParser(string logName, string logContents)
        {
            if (!string.IsNullOrEmpty(logName))
                File.WriteAllText(logName, logContents);
            var logParser = new LogParser();
            return logParser;
        }

        [Test]
        public void GetRowsWithinRange_ThereIsARowOutsideOfRange_NothingIsReturned()
        {
            var logParser = GetAndInitLogParser("C:\\temp\\Log-Proj2.csv", "1/1/2013 5:00 PM,User attempted to log in");
            var actual = logParser.GetMessagesWithinRange("User attempted to log in", new DateTime(2013, 2, 1), new DateTime(2013, 2, 2)).ToList();
            Assert.AreEqual(0, actual.Count);
        }
        
        [Test]
        public void GetRowsWithinRange_ProjectDoesNotExist_NothingIsReturned()
        {
            var logParser = GetAndInitLogParser(null, null);
            var actual = logParser.GetMessagesWithinRange("Proj3", new DateTime(2013, 2, 1), new DateTime(2013, 2, 2)).ToList();
            Assert.AreEqual(0, actual.Count);
        }
    }
}
