using System.Diagnostics;

namespace Project001;

public class MenuState : GameState
{
    private readonly List<Button> _buttons = new();
    private readonly List<RotatingSprite> _sprites = new();

    public MenuState(GameManager gm)
    {
        var r = new Random();
        var x = Globals.Bounds.X / 2;
        var y = Globals.Bounds.Y / 2;

        AddButton(new(Globals.Content.Load<Texture2D>("Menu/easy"), new(x - 300, y))).OnClick += gm.StartEasy;
        AddButton(new(Globals.Content.Load<Texture2D>("Menu/medium"), new(x, y))).OnClick += gm.StartMedium;
        AddButton(new(Globals.Content.Load<Texture2D>("Menu/hard"), new(x + 300, y))).OnClick += gm.StartHard;
        AddButton(new(Globals.Content.Load<Texture2D>("Menu/youtube"), new(Globals.Bounds.X - 70, 50))).OnClick += OpenYouTube;
        AddButton(SoundManager.MusicBtn);
        AddButton(SoundManager.SoundBtn);

        foreach (var item in Board.CardTextures)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 pos = new(r.Next(0, Globals.Bounds.X), r.Next(0, Globals.Bounds.Y));
                Vector2 dir = new(((float)r.NextDouble() * 2) - 1, ((float)r.NextDouble() * 2) - 1);
                dir.Normalize();
                _sprites.Add(new(item, pos, dir));
            }
        }
    }

    private static void OpenYouTube(object sender, EventArgs e)
    {
        ProcessStartInfo psi = new()
        {
            UseShellExecute = true,
            FileName = "https://www.youtube.com/playlist?list=PLkEsuRhhI3nf2HW0af8fgGHK-kFZV_3sF",
        };
        Process.Start(psi);
    }

    private Button AddButton(Button button)
    {
        _buttons.Add(button);
        return button;
    }

    public override void Update(GameManager gm)
    {
        foreach (var item in _sprites)
        {
            item.Update();
        }

        foreach (var button in _buttons)
        {
            button.Update();
        }
    }

    public override void Draw(GameManager gm)
    {
        foreach (var item in _sprites)
        {
            item.Draw();
        }

        foreach (var button in _buttons)
        {
            button.Draw();
        }

        ScoreManager.DrawHighScores();
    }
}
