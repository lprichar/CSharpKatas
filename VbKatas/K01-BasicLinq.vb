Imports NUnit.Framework

Public Class Calculator
    Public Function SumNumbers(start, count)
        ' todo #1: Remove the Ignore attribute and get all the tests passing
        ' todo #2: Refactor so there are no loops or if statements (this is the functional approach and is idiomatic for C#)
        ' todo #3: Refactor to use the Aggregate() LINQ method (see 101 Linq Samples: http://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b)
        Return 0
    End Function
End Class

<TestFixture(), Ignore()> _
Public Class Test
    <Test()> _
    Public Sub SumNumbers_StartAt100SumNext1_TotalIs100()
        Dim kata = New Calculator()
        Assert.AreEqual(100, kata.SumNumbers(100, 1))
    End Sub

    <Test()> _
    Public Sub SumNumbers_StartAt100SumNext2_TotalIs201()
        Dim kata = New Calculator()
        Assert.AreEqual(201, kata.SumNumbers(100, 2))
    End Sub

    <Test()> _
    Public Sub SumNumbers_StartAt100SumNext0_TotalIs0()
        Dim kata = New Calculator()
        Assert.AreEqual(0, kata.SumNumbers(100, 0))
    End Sub

    <Test()> _
    Public Sub SumNumbers_StartAt0SumNext0_TotalIs0()
        Dim kata = New Calculator()
        Assert.AreEqual(0, kata.SumNumbers(0, 0))
    End Sub

    <Test()> _
    Public Sub SumNumbers_StartAt0SumNext3_TotalIs3()
        Dim kata = New Calculator()
        Assert.AreEqual(3, kata.SumNumbers(0, 3))
    End Sub

    <Test()> _
    Public Sub SumNumbers_StartAt0SumNext100_TotalIs5050()
        Dim kata = New Calculator()
        Assert.AreEqual(5050, kata.SumNumbers(1, 100))
    End Sub

End Class
