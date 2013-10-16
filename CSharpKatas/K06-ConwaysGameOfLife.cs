using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharpKatas
{
    public class Cell
    {
    }

    public class Board
    {
        public Cell GetCell(int x, int y)
        {
            return null;
        }

        public bool IsAlive(int x, int y)
        {
            return true;
        }

        public void SetAlive(int x, int y)
        {
        }

        public void IncrementGeneration()
        {
            // todo #1: Remove the ignore attribute and get all tests passing
        }

        public IEnumerable<Board> GetAllFutureGenerations()
        {
            // todo #2: Implementing this correctly and understanding how it works is key to understanding LINQ and deferred execution. It feels like you're writing an infinite loop, but it isn't, why?
            return null;
            
            // todo #3: Refactor until you have a beautiful solution e.g. 1-3 lines per method, very few loops (if any), very few if's (if any), descriptive method and variable names, etc
        }
    }

    [TestFixture]
    [Ignore]
    public class TestGameOfLife
    {
        [Test]
        public void Constructor_EmptyBoard_RandomCellIsNotAlive()
        {
            Board board = new Board();
            AssertCellIsDead(board, 0, 0);
            AssertCellIsDead(board, 100, 100);
        }

        [Test]
        public void IncrementGeneration_EmptyBoard_RandomCellIsNotAlive()
        {
            Board board = new Board();
            board.IncrementGeneration();
            AssertCellIsDead(board, 0, 0);
            AssertCellIsDead(board, -100, -100);
        }

        [Test]
        public void GetCell_SetCellAlive_ValuePersists()
        {
            Board board = new Board();
            board.SetAlive(0, 0);
            AssertCellIsAlive(board, 0, 0);
        }

        [Test]
        public void IncrementGeneration_AnyLiveCellWithZeroLiveNeighbours_Dies()
        {
            Board board = new Board();
            board.SetAlive(0, 0);
            board.IncrementGeneration();
            AssertCellIsDead(board, 0, 0);
        }

        [Test]
        public void IncrementGeneration_AnyLiveCellWithOneLiveNeighbor_Dies()
        {
            Board board = new Board();
            // 1  X  .  .
            // 0  X  .  .
            //    0  1  2
            board.SetAlive(0, 0);
            board.SetAlive(0, 1);
            board.IncrementGeneration();
            AssertCellIsDead(board, 0, 0);
            AssertCellIsDead(board, 0, 1);
        }

        [Test]
        public void IncrementGeneration_AnyLiveCellWithTwoLiveNeighbours_LivesOnToTheNextGeneration()
        {
            Board board = new Board();
            // 1  .  .  .
            // 0  X  X  X
            //    0  1  2
            board.SetAlive(0, 0);
            board.SetAlive(1, 0);
            board.SetAlive(2, 0);
            board.IncrementGeneration();
            AssertCellIsAlive(board, 1, 0);
        }
        
        [Test]
        public void IncrementGeneration_AnyLiveCellWithThreeLiveNeighbours_LivesOnToTheNextGeneration()
        {
            Board board = new Board();

            // 1  .  X  .
            // 0  X  X  X
            //    0  1  2
            board.SetAlive(0, 0);
            board.SetAlive(1, 0);
            board.SetAlive(2, 0);
            board.SetAlive(1, 1);
            board.IncrementGeneration();
            AssertCellIsAlive(board, 1, 0);
        }

        [Test]
        public void IncrementGeneration_AnyLiveCellWithFourLiveNeighbors_Dies()
        {
            // 2  .  X  .
            // 1  X  X  X
            // 0  .  X  .
            //    0  1  2
            Board board = new Board();
            board.SetAlive(1, 0);
            board.SetAlive(0, 1);
            board.SetAlive(1, 1);
            board.SetAlive(2, 1);
            board.SetAlive(1, 2);
            board.IncrementGeneration();
            AssertCellIsDead(board, 1, 1);
        }

        [Test]
        public void IncrementGeneration_AnyDeadCellWithExactlyThreeLiveNeighbours_BecomesAlive()
        {
            // 2  .  X  .
            // 1  X  .  X
            //    0  1  2
            Board board = new Board();
            board.SetAlive(1, 2);
            board.SetAlive(0, 1);
            board.SetAlive(2, 1);
            board.IncrementGeneration();
            AssertCellIsAlive(board, 1, 1);
        }

        [Test]
        public void GetAllFutureGenerations_OscillatorsPatternAfterManyGenerations_ContinuesToOscilate()
        {
            // 1  .  .  .
            // 0  X  X  X
            // -1 .  .  .
            //    0  1  2
            Board board = new Board();
            board.SetAlive(0, 0);
            board.SetAlive(1, 0);
            board.SetAlive(2, 0);
            var generation101 = board.GetAllFutureGenerations()
                .Skip(100)
                .First();

            // 1  .  X  .
            // 0  .  X  .
            // -1 .  X  .
            //    0  1  2
            AssertCellIsAlive(generation101, 1, 0);
            AssertCellIsAlive(generation101, 1, 1);
            AssertCellIsAlive(generation101, 1, -1);
        }

        private void AssertCellIsAlive(Board board, int x, int y)
        {
            Assert.AreEqual(true, board.IsAlive(x, y));
        }

        private void AssertCellIsDead(Board board, int x, int y)
        {
            Assert.AreEqual(false, board.IsAlive(x, y));
        }
    }
}
