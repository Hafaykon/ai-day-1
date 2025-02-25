using aiexercise.core.Game;

public class Obstacle : GameObject
{
    public bool IsScored { get; set; }

    public Obstacle(int x, int y)
    {
        this.X = x;
        this.Y = y;
        this.IsScored = false;
    }

    public void Update()
    {
        X -= 2; // Increase the speed of the obstacles
    }

    public override void Draw()
    {
        string[] cactus = new string[]
        {
            "  |",
            " _|_",
            "  |",
            "  |"
        };

        for (int i = 0; i < cactus.Length; i++)
        {
            Console.SetCursorPosition(X, Y + i);
            Console.Write(cactus[i]);
        }
    }
}


