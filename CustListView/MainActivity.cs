using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V4;
using Android.Support.V4.Widget;

using Wahid.SwipemenuListview;
using Android.Graphics.Drawables;
using Android.Graphics;
using System.Collections.Generic;

namespace CustListView
{
    [Activity(Label = "CustListView", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            

			ListFragment fragment = new ListFragment();
            //fragment.frameLayout = FindViewById<FrameLayout>(Resource.Id.frameLayout1);

            FragmentManager.BeginTransaction()
                           .Add(Resource.Id.container, fragment, "frag")
                           .SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out)
              .Commit();


 
        }
              
    }
}

