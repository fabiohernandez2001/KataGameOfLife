using System;
using System.Dynamic;
using System.Runtime.Serialization.Formatters;
using KataGameOfLife;
public class GameOfLife
{
	private List<Cell> ActualGen = new List<Cell>();
    private List<Cell> NextGen = new List<Cell>();
    Board board;
    public GameOfLife(bool[,] ecosystem)
	{
		for (int i = 0; i < ecosystem.GetLength(0); i++)
		{
			for(int j = 0; j < ecosystem.GetLength(1); j++) 
			{
                if (ecosystem[i, j]) ActualGen.Add(new Cell(State.Alive, i, j));
                else { ActualGen.Add(new Cell(State.Dead, i, j)); }
            }
		}
        board = new Board(ActualGen);
	}
    
    
    public List<Cell> next()
	{
        NextGen.Clear();
        foreach (Cell cell in ActualGen)
        {
            int population = board.Neighborhood(cell);
            if(cell.IsAlive==State.Dead)
            {
                if(population == 3) 
                { 
                    NextGen.Add(new Cell(State.Alive,cell.X,cell.Y));
                }
                else
                {
                    NextGen.Add(cell);
                }
            }
            else
            {
                if(population < 2 || population > 3)
                {
                    NextGen.Add(new Cell(State.Dead, cell.X, cell.Y));
                }
                else
                {
                    NextGen.Add(new Cell(State.Alive, cell.X, cell.Y));
                }
            }
        }
        board.updateBoard(NextGen);
        return NextGen;
    }
}
