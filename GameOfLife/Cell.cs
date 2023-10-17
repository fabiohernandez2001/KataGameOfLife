using System;

public class Cell
{
	private bool isAlive;
	private int x;
	private int y;
	private Board board;
	public Cell(Board board, int x, int y, bool isAlive)
	{
		this.isAlive = isAlive;
		this.x = x;	
		this.y = y;
		this.board = board;
	}
	public bool IsAlive { get { return isAlive; } }
	private void changeState() { isAlive = !isAlive; }
	private int X { get{ return this.x; } }
    private int Y { get { return this.y; } }
    public void check()
	{
		int neighborhood = this.neighborhood();

        if (!this.isAlive)
		{
			if (neighborhood == 3)
			{
				this.changeState();
			}
		}
		else
		{
			if (neighborhood <2 || neighborhood>3 ) 
			{ 
				this.changeState();
			}
		}
	}
	private int neighborhood()
	{
		int NeighbohrdsAlive = 0;
		int startX, startY, endX, endY;

        if (this.y == 0) { startY = 0; }
		else { startY = -1; }

        if (this.x == 0) { startX = 0; }
		else {  startX = -1; }

        if (this.y == this.board.GetLength()[1])
        {
            endY = this.board.GetLength()[1];
        }
		else { endY = 2; }
        
		if (this.x == this.board.GetLength()[0])
		{
			endX = this.board.GetLength()[0];
            
        }
        else { endX = 2; }

        
        for (int i = startX; i < endX; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                if (i == 0 && j == 0) continue;
                if (this.board.GetCell(i + this.x, j + this.x).IsAlive)
                {
                    NeighbohrdsAlive++;
                }
            }
        }
		return NeighbohrdsAlive;
	}
}
