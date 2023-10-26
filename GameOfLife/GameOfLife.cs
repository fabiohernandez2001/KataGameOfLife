using KataGameOfLife;
public class GameOfLife
{
    private Board board;

    public GameOfLife(bool[,] ecosystem)
	{
        board = new Board(ecosystem);
	}

    public void Next()
    {
        board.Next();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(GameOfLife)) return false;
        return Equals(obj as GameOfLife);
    }

    private bool Equals(GameOfLife other)
    {
        return this.board.Equals(other.board);
    }
}
