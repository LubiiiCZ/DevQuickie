using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace LiveProject001;

[Activity(
    Label = "@string/app_name",
    MainLauncher = true,
    Icon = "@drawable/icon",
    Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    ScreenOrientation = ScreenOrientation.Portrait,
    ConfigurationChanges = ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
)]

public class Activity1 : AndroidGameActivity
{
    private Game1 _game;
    private View _view;

    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);

        _game = new Game1();
        _view = _game.Services.GetService(typeof(View)) as View;

        SetContentView(_view);
        _game.Run();
    }
}
