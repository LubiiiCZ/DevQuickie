using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Project001;

public static class SoundManager
{
    public static bool MusicOn { get; private set; }
    public static bool SoundsOn { get; private set; }

    private static SoundEffect _flipFX;
    private static SoundEffect _tearFX;
    private static SoundEffect _victoryFX;
    private static Song _music;
    public static Button MusicBtn { get; private set; }
    public static Button SoundBtn { get; private set; }

    public static void Init()
    {
        _music = Globals.Content.Load<Song>("Sound/music");
        _flipFX = Globals.Content.Load<SoundEffect>("Sound/flip");
        _tearFX = Globals.Content.Load<SoundEffect>("Sound/tear");
        _victoryFX = Globals.Content.Load<SoundEffect>("Sound/victory");

        MusicOn = true;
        SoundsOn = true;

        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.2f;
        MediaPlayer.Play(_music);

        MusicBtn = new(Globals.Content.Load<Texture2D>("Menu/music"), new(50, 50));
        MusicBtn.OnClick += SwitchMusic;
        SoundBtn = new(Globals.Content.Load<Texture2D>("Menu/sounds"), new(130, 50));
        SoundBtn.OnClick += SwitchSounds;
    }

    public static void SwitchMusic(object sender, EventArgs e)
    {
        MusicOn = !MusicOn;
        MediaPlayer.Volume = MusicOn ? 0.2f : 0f;
        MusicBtn.Disabled = !MusicOn;
    }

    public static void SwitchSounds(object sender, EventArgs e)
    {
        SoundsOn = !SoundsOn;
        SoundBtn.Disabled = !SoundsOn;
    }

    public static void PlayFlipFx()
    {
        if (!SoundsOn) return;
        _flipFX.Play(0.3f, 0, 0);
    }

    public static void PlayTearFX()
    {
        if (!SoundsOn) return;
        _tearFX.Play();
    }

    public static void PlayVictoryFX()
    {
        if (!SoundsOn) return;
        _victoryFX.Play();
    }
}
