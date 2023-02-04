namespace Quickie017;

public class Gate : Sprite
{
    private readonly Texture2D _open;
    private readonly int _gems;
    private readonly Hero _hero;

    public Gate(Texture2D closed, Texture2D open, Vector2 pos, int gems, Hero hero) : base(closed, pos)
    {
        _open = open;
        _hero = hero;
        _gems = gems;
        _hero.OnCollect += ObserveGems;
    }

    private void ObserveGems(int gems)
    {
        if (gems >= _gems)
        {
            texture = _open;
            _hero.OnCollect -= ObserveGems;
        }
    }
}
