using GameOfLife;
using System;

public class Cell
{
	private State isAlive;
	private int x;
	private int y;
	public Cell(State isAlive, int x, int y)
	{
		this.isAlive = isAlive;
		this.x = x;	
		this.y = y;
	}
	public State IsAlive { get { return this.isAlive; } }
	public int X { get{ return this.x; } }
    public int Y { get { return this.y; } }
	public bool IsNeighbohr(Cell cell)
	{
		int distx = Math.Abs(cell.X - this.X);
		int disty = Math.Abs(cell.Y - this.Y);
		if (distx <= 1 && disty <= 1) { return true; }
		return false;
	}
    public override bool Equals(object? cell)
    {
		if (cell == null || cell.GetType() != typeof(Cell)) return false;
		Cell cell_cast = (Cell)cell;
		if (cell_cast.X == this.x && cell_cast.Y == this.y && cell_cast.isAlive == this.isAlive) {  return true; }
		else {  return false; }
    }
}
