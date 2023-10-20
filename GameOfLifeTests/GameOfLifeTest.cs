using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataGameOfLife;

namespace KataGameOfLifeTests
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void given_neigborhood_should_return_more()
        {
            bool[,] ecosystem = new bool[,] {
                {  false, true, false},
                { true, true, true},
                { false, true, false } };
            List<Cell> list = new List<Cell>();

            bool[,] netx_ecosystem_expected = new bool[,] {
                {  true, true, true},
                { true, false, true},
                { true, true, true } };
            for (int i = 0; i < netx_ecosystem_expected.GetLength(0); i++)
            {
                for (int j = 0; j < netx_ecosystem_expected.GetLength(1); j++)
                {
                    if (netx_ecosystem_expected[i, j]) list.Add(new Cell(State.Alive, i, j));
                    else { list.Add(new Cell(State.Dead, i, j)); }
                }
            }

            GameOfLife board = new GameOfLife(ecosystem);
            List<Cell> next = board.next();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(next.ElementAt(i), list.ElementAt(i));
            }
        }
        [TestMethod]
        public void given_empty_neigborhood_should_return_same()
        {
            bool[,] ecosystem = new bool[,] {
                {  false, false, false},
                { false, false, false},
                { false, false, false } };
            List<Cell> list = new List<Cell>();

            bool[,] netx_ecosystem_expected = new bool[,] {
                {  false, false, false},
                { false, false, false},
                { false, false, false } };
            for (int i = 0; i < netx_ecosystem_expected.GetLength(0); i++)
            {
                for (int j = 0; j < netx_ecosystem_expected.GetLength(1); j++)
                {
                    if (netx_ecosystem_expected[i, j]) list.Add(new Cell(State.Alive, i, j));
                    else { list.Add(new Cell(State.Dead, i, j)); }
                }
            }

            GameOfLife board = new GameOfLife(ecosystem);
            List<Cell> next = board.next();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(next.ElementAt(i), list.ElementAt(i));
            }
        }
        [TestMethod]
        public void given_neigborhood_should_return_lower()
        {
            bool[,] ecosystem = new bool[,] {
                {  true, true, true},
                { true, false, true},
                { true, true, true } };
            List<Cell> list = new List<Cell>();

            bool[,] netx_ecosystem_expected = new bool[,] {
                {  true, false, true},
                { false, false, false},
                { true, false, true } };
            for (int i = 0; i < netx_ecosystem_expected.GetLength(0); i++)
            {
                for (int j = 0; j < netx_ecosystem_expected.GetLength(1); j++)
                {
                    if (netx_ecosystem_expected[i, j]) list.Add(new Cell(State.Alive, i, j));
                    else { list.Add(new Cell(State.Dead, i, j)); }
                }
            }

            GameOfLife board = new GameOfLife(ecosystem);
            List<Cell> next = board.next();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(next.ElementAt(i), list.ElementAt(i));
            }
        }
    }
}
