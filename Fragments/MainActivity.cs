using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;


namespace Fragments
{
    [Activity(Label = "Fragments", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

		LinearLayout myLinearLayout;
		FrameLayout fragmentFrame;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			myLinearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout);
			fragmentFrame = FindViewById<FrameLayout>(Resource.Id.frameLayout);

			Button showFrag = FindViewById<Button>(Resource.Id.showFragment);
            
			showFrag.Click += ShowFrag_Click;
		}
        

        void ShowFrag_Click(object sender, System.EventArgs e)
		{
			
			MyFragment fragment = new MyFragment();

            FragmentManager.BeginTransaction()
                           .Add(Resource.Id.frameLayout, fragment, "frag")
			               .SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out)
              .Commit();

			fragment.ChangeToBlue += Fragment_ChangeToBlue;
			fragment.ChangeToOrange += Fragment_ChangeToOrange;
			fragment.ChangeFrame += Fragment_ChangeFrame;


		}

		void Fragment_ChangeToBlue(object sender, ColorChangeEventArgs e)
		{
			myLinearLayout.SetBackgroundColor(e.BackgroundColor);
            
		}
		void Fragment_ChangeToOrange(object sender, ColorChangeEventArgs e)
		{
			myLinearLayout.SetBackgroundColor(e.BackgroundColor);
		}

        
		void Fragment_ChangeFrame(object sender, FrameChangeEventArgs e)
		{
           
			ViewGroup.LayoutParams layoutParams = fragmentFrame.LayoutParameters;
     
			layoutParams.Width = e.FrameWidth;
			fragmentFrame.LayoutParameters = layoutParams;
		}

    }
}

