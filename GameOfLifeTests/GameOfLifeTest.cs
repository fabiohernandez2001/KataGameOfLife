using FluentAssertions;
using KataGameOfLife;
using NUnit.Framework;

namespace KataGameOfLifeTests
{
    public class GameOfLifeTest
    {
        [Test]
        public void given_neigborhood_should_return_more()
        {
            bool[,] ecosystem = new bool[,] {
                {  false, true, false},
                { true, true, true},
                { false, true, false } };
            GameOfLife board = new GameOfLife(ecosystem);

            board.Next();

            bool[,] next_ecosystem_expected = new bool[,] {
                {  true, true, true},
                { true, false, true},
                { true, true, true } };
            var expectedBoard = new GameOfLife(next_ecosystem_expected);
            board.Equals(expectedBoard).Should().BeTrue();
        }
        [Test]
        public void given_empty_neigborhood_should_return_same()
        {
            bool[,] ecosystem = new bool[,] {
                {  false, false, false},
                { false, false, false},
                { false, false, false } };
            
            

            GameOfLife board = new GameOfLife(ecosystem);
            board.Next();


            bool[,] next_ecosystem_expected = new bool[,] {
                {  false, false, false},
                { false, false, false},
                { false, false, false } };
            var expectedBoard = new GameOfLife(next_ecosystem_expected);
            board.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void given_neigborhood_should_return_lower()
        {
            bool[,] ecosystem = new bool[,] {
                {  true, true, true},
                { true, false, true},
                { true, true, true } };

            GameOfLife board = new GameOfLife(ecosystem);
            board.Next();

            bool[,] next_ecosystem_expected = new bool[,] {
                {  true, false, true},
                { false, false, false},
                { true, false, true } };
            var expectedBoard = new GameOfLife(next_ecosystem_expected);
            board.Should().BeEquivalentTo(expectedBoard);
        }
    }
}
