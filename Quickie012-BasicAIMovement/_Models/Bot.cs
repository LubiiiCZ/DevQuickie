namespace Quickie012;

public class Bot : Sprite
{
    public MovementAI MoveAI { get; set; }

    public Bot(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = 250;
    }

    public void Update()
    {
        MoveAI.Move(this);
    }
}
