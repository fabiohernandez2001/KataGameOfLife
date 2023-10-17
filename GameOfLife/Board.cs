using System;

public class Board
{
	private Cell[,] cells = new Cell[9, 9]; 
	public Board()
	{
		 for (int i = 0; i < cells.GetLength(0); i++)
		{
			for(int j = 0; j < cells.GetLength(1); j++) 
			{
				if (i > 3  && j < 9)
				{
                    cells[i, j] = new Cell(this, i, j, true);
                }
				cells[i, j] = new Cell(this, i, j, false); 
			
			}
		}
	}
	public Cell GetCell(int i, int j)
	{
		return cells[i, j];
	}
	public int[] GetLength()
	{
		int[] lengths = new int[2];
		lengths[0] = cells.GetLength(0);
		lengths[1] = cells.GetLength(1);
		return lengths;
	}
	public void next()
	{
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++) { cells[i, j].check(); }
        }
    }
}
