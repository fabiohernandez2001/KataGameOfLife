using System;
using System.Dynamic;
using System.Runtime.Serialization.Formatters;
using GameOfLife;
public class GameOfLifeBoard
{
	private List<Cell> ActualGen = new List<Cell>();
    private List<Cell> NextGen = new List<Cell>();
    public GameOfLifeBoard(bool[,] ecosystem)
	{
		for (int i = 0; i < ecosystem.GetLength(0); i++)
		{
			for(int j = 0; j < ecosystem.GetLength(1); j++) 
			{
                if (ecosystem[i, j]) ActualGen.Add(new Cell(State.Alive, i, j));
                else { ActualGen.Add(new Cell(State.Dead, i, j)); }
            }
		}
	}
    private int Neighborhood(Cell cell)
    {
        int NeighbohrdsAlive = 0;
        
        foreach(Cell possible_neighborh in ActualGen) 
        {
            if (possible_neighborh == cell) continue;
            if(possible_neighborh.IsAlive == State.Alive) 
            {
                if (cell.IsNeighbohr(possible_neighborh)) { NeighbohrdsAlive++; }
            }
        }
        return NeighbohrdsAlive;
    }
    
    public List<Cell> next()
	{
        NextGen.Clear();
        foreach (Cell cell in ActualGen)
        {
            int population = Neighborhood(cell);
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
                Console.WriteLine($"population: {population.ToString()}");
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
        ActualGen = NextGen;
        return ActualGen;
    }
}
