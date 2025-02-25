using aiexercise.core.Game;

public class Player : GameObject
{
    public bool IsJumping { get; set; }
    private int jumpHeight;
    private int groundLevel;
    private int jumpDuration;
    private int jumpCounter;
    private bool isFalling;

    public Player(int groundLevel, int startX)
    {
        this.groundLevel = groundLevel;
        this.Y = groundLevel;
        this.X = startX;
        this.jumpHeight = 10; // Jump height
        this.jumpDuration = 10; // Decrease jump duration to make it faster
        this.jumpCounter = 0;
        this.isFalling = false;
    }

    public void Jump()
    {
        if (!IsJumping)
        {
            IsJumping = true;
            isFalling = false;
            jumpCounter = 0;
        }
    }

    public void Update()
    {
        if (IsJumping)
        {
            if (!isFalling)
            {
                Y -= jumpHeight / (jumpDuration / 2);
                jumpCounter++;
                if (jumpCounter >= jumpDuration / 2)
                {
                    isFalling = true;
                }
            }
            else
            {
                Y += jumpHeight / (jumpDuration / 2);
                jumpCounter--;
                if (jumpCounter <= 0)
                {
                    IsJumping = false;
                    Y = groundLevel;
                }
            }
        }
    }

    public override void Draw()
    {
        string[] dinosaur = new string[]
        {
            "  __",
            " / _)",
            "|/ / ",
            "||  "
        };

        for (int i = 0; i < dinosaur.Length; i++)
        {
            Console.SetCursorPosition(X, Y + i);
            Console.Write(dinosaur[i]);
        }
    }
}


