using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife
{
    internal class Board
    {
        List<Cell> ActualGen;
        public Board(List<Cell> cells) 
        {
            this.ActualGen=cells;
        }
        public int Neighborhood(Cell cell)
        {
            int NeighbohrdsAlive = 0;

            foreach (Cell possible_neighborh in this.ActualGen)
            {
                if (possible_neighborh == cell) continue;
                if (possible_neighborh.IsAlive == State.Alive)
                {
                    if (cell.IsNeighbohr(possible_neighborh)) { NeighbohrdsAlive++; }
                }
            }
            return NeighbohrdsAlive;
        }
        public void updateBoard(List<Cell> New_Gen) { this.ActualGen = New_Gen; }
    }
}
