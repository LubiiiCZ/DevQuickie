using System;
namespace Quickie006;

public class Ship : Sprite
{
    private float _rotation;
    private readonly float _rotationSpeed;

    public Ship(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _rotation = 0;
        _rotationSpeed = 3f;
    }

    public void Update()
    {
        _rotation += InputManager.DirectionArrows.X * _rotationSpeed * Globals.TotalSeconds;
        Vector2 direction = new((float)Math.Sin(_rotation), -(float)Math.Cos(_rotation));
        position += InputManager.DirectionArrows.Y * direction * speed * Globals.TotalSeconds;
    }

    public override void Draw()
    {
        Globals.SpriteBatch.Draw(texture, position, null, Color.White, _rotation, origin, 1, SpriteEffects.None, 1);
    }
}
