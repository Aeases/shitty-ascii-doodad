// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Collections;



class Program
{
    public static void Main()
    {
			ASCIIScene	renderer = new ASCIIScene(10, 10);
			Sprite mySprite = new Sprite("free");
			renderer.addSpriteToScene(mySprite);
			renderer.RenderFrame();
    }
}

struct Cell
{
	public int Col;
	public int Lin;
	public char symbol;
}

class ASCIIScene 
{
	public int wCols{get;}
	public int wLines{get;}
	private List<Sprite> sprites;
	public ASCIIScene(int wColsParam, int wLinesParam) 
	{
		wCols = wColsParam;
		wLines = wLinesParam;
		sprites = new List<Sprite>();
	}

	public void addSpriteToScene(Sprite spr) {
		sprites.Add(spr);
	}


	public void RenderFrame() 
	{
		Cell[] cellsToDraw = sprites[0].getCellsToDraw(this);
		Console.Write(cellsToDraw[0].symbol);
	}
}

class Sprite 
{
	protected int x, y; // x = Column, y = line
	protected string content;

	public Sprite(string displayThis) 
	{
		content = displayThis;
	}

	public Sprite(string displayThis, int px, int py)
	{
		content = displayThis;
		this.x = px;
		this.y = py;
	}

	public Cell[] getCellsToDraw(ASCIIScene scene)
	{
		Cell[] cells = new Cell[content.Length];
		int currentX = this.x;
		int currentY = this.y;

		for (int i = 0; i < content.Length && i < scene.wCols; i++) {
			cells[i] = new Cell{Col = currentX, Lin = 0, symbol = content[i]};
		}
		return cells;
	}
}
