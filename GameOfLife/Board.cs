namespace KataGameOfLife
{
    public class Board
    {
        private List<Cell> cells;
        public Board(bool[,] initialState) 
        {
            cells = new List<Cell>();
            for (int i = 0; i < initialState.GetLength(0); i++)
            {
                for (int j = 0; j < initialState.GetLength(1); j++)
                {
                    cells.Add(new Cell(initialState[i, j], i, j));
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Board)) return false;
            return Equals(obj as Board);
        }

        private bool Equals(Board other)
        {
            return cells.SequenceEqual(other.cells);
        }

        public void Next()
        {
            var nextGen = cells.Select(cell => (Cell) cell.Clone()).ToList();
            for (int i = 0; i < cells.Count; i++)
            {
                int population = Neighborhood(cells[i]);
                nextGen[i].UpdateState(population);
            }
            cells = nextGen;
        }
        private int Neighborhood(Cell cell)
        {
            int NeighbohrdsAlive = 0;

            foreach (Cell possible_neighborh in cells)
            {
                if (possible_neighborh == cell) continue;
                if (possible_neighborh.IsAlive())
                {
                    if (cell.IsNeighbohr(possible_neighborh)) { NeighbohrdsAlive++; }
                }
            }
            return NeighbohrdsAlive;
        }
    }
}
