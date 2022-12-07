using Android.App;
using Android.Runtime;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2;
using ExoTestApp.Platforms.Android;

namespace ExoTestApp;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp()
	{
        var HttpDataSourceFactory = new DefaultHttpDataSource.Factory().SetAllowCrossProtocolRedirects(true);
        var MainDataSource = new ProgressiveMediaSource.Factory(HttpDataSourceFactory);
        var Exoplayer = new IExoPlayer.Builder(Context).SetMediaSourceFactory(MainDataSource).Build();
        Exoplayer.AddListener(new ExoListener());

        MediaItem mediaItem = MediaItem.FromUri(Android.Net.Uri.Parse("https://ia800806.us.archive.org/15/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3"));

        Exoplayer.AddMediaItem(mediaItem);
        Exoplayer.Prepare();
        Exoplayer.PlayWhenReady = true;

        return MauiProgram.CreateMauiApp();
	}
}
