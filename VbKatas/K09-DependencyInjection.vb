Imports System.IO
Imports System.Linq
Imports NUnit.Framework

Namespace CSharpKatas
    Public Class ProjectLog
        Public Sub New(logLine As String)
            Dim bits As String() = logLine.Split(",")
            EntryDate = DateTime.Parse(bits(0))
            Message = bits(1)
        End Sub

        Public Property EntryDate() As DateTime
        Public Property Message As String
    End Class

    Public Class LogParser
        Public Function GetMessagesWithinRange(projectName As String, startDate As DateTime, endDate As DateTime) As IEnumerable(Of String)
            Dim fileName As String = String.Format("C:\\temp\\Log-{0}.csv", projectName)

            If Not File.Exists(fileName) Then
                Return Enumerable.Empty(Of String)()
            End If

            Dim allLines = File.ReadAllLines(fileName)
            Return allLines _
                .Select(Function(i) New ProjectLog(i)) _
                .Where(Function(i) i.EntryDate > startDate And i.EntryDate < endDate) _
                .Select(Function(i) i.Message)
        End Function
    End Class

    <TestFixture(), Ignore()> _
    Public Class Test
        <Test()> _
        Public Sub GetRowsWithinRange_ThereIsARowWithinRange_ItsMessageIsReturned()
            ' todo #0: Remove the Ignore attribute
            ' todo #1: Start to clean up this disaster by focusing on LogParser. Extract out its File IO logic into a separate class so doesn't violate the single responsiblity principle (http://en.wikipedia.org/wiki/Solid_(object-oriented_design)).
            ' todo #2: Implement the Inversion of Control (IoC) pattern in LogParser so that you could potentially use a separate implementation for the File IO logic
            ' todo #3: Refactor the unit tests so that they never interact with the file system. Do this by subclassing the new class you created in #1 and injecting that into LogParser.
            ' todo #4: Now that you've done dependency injection manually, redo #3 with Moq.  Get it via nuget, read the examples in the documentation on their website.

            File.WriteAllText("C:\\temp\\Log-Proj1.csv", "1/1/2013 5:00 PM,Begin logging")
            Dim logParser = New LogParser()
            Dim actual = logParser.GetMessagesWithinRange("Proj1", New DateTime(2013, 1, 1), New DateTime(2013, 1, 2)).ToList()
            Assert.AreEqual(1, actual.Count)
            Assert.AreEqual("Begin logging", actual(0))
        End Sub

        <Test()> _
        Public Sub GetRowsWithinRange_ThereIsARowOutsideOfRange_NothingIsReturned()
            File.WriteAllText("C:\\temp\\Log-Proj2.csv", "1/1/2013 5:00 PM,User attempted to log in")
            Dim logParser = New LogParser()
            Dim actual = logParser.GetMessagesWithinRange("User attempted to log in", New DateTime(2013, 2, 1), New DateTime(2013, 2, 2)).ToList()
            Assert.AreEqual(0, actual.Count)
        End Sub

        <Test()> _
        Public Sub GetRowsWithinRange_ProjectDoesNotExist_NothingIsReturned()
            File.Delete("C:\\temp\\Log-Proj3.csv")
            Dim logParser = New LogParser()
            Dim actual = logParser.GetMessagesWithinRange("Proj3", New DateTime(2013, 2, 1), New DateTime(2013, 2, 2)).ToList()
            Assert.AreEqual(0, actual.Count)
        End Sub
    End Class
End Namespace