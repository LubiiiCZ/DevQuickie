namespace Quickie017;

public class SoundManager
{
    private readonly SoundEffect _collectGemFx;

    public SoundManager(Hero hero)
    {
        _collectGemFx = Globals.Content.Load<SoundEffect>("sfx");
        hero.OnCollect += ObserveGems;
    }

    private void ObserveGems(int gems)
    {
        _collectGemFx.Play();
    }
}
