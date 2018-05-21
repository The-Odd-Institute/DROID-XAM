using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Java.IO;

namespace AlertDialog
{
    [Activity(Label = "AlertDialog", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button showAlertButton = FindViewById<Button>(Resource.Id.showAlert);
            showAlertButton.Click += ShowAlertButton_Click;
        }



		void ShowAlertButton_Click(object sender, System.EventArgs e)
		{
            
			AlertFragment fragment = new AlertFragment();

			FragmentManager.BeginTransaction()
			               .Add(Resource.Id.fragmentContainer, fragment, "frag")
			               .SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out)
			               .Commit();

			fragment.GoToProperty += Fragment_GoToProperty;
         
		}

		void Fragment_GoToProperty(object sender, OnClickEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(e.PropertyNumber);
		}

    }
}

