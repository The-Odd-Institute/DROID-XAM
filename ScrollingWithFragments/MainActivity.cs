using Android.App;
using Android.Widget;
using Android.OS;

namespace ScrollingWithFragments
{
    [Activity(Label = "ScrollingWithFragments", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			FrameLayout fragmentFrame1 = FindViewById<FrameLayout>(Resource.Id.frameLayout1);

			FirstFragment fragment1 = new FirstFragment();

            FragmentManager.BeginTransaction()
                           .Add(Resource.Id.frameLayout1, fragment1, "frag")
                           .SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out)
              .Commit();

			FrameLayout fragmentFrame2 = FindViewById<FrameLayout>(Resource.Id.frameLayout2);

			SecondFragment fragment2 = new SecondFragment();

            FragmentManager.BeginTransaction()
                           .Add(Resource.Id.frameLayout2, fragment2, "frag")
                           .SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out)
              .Commit();
                           
        }
    }
}

