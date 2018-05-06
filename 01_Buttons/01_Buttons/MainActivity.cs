using Android.App;
using Android.Widget;
using Android.OS;

namespace _Buttons
{
    [Activity(Label = "01_Buttons", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        void ButtonClickedAction (object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Hello", ToastLength.Long).Show();
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button tempButton = FindViewById<Button>(Resource.Id.);

            tempButton.Click += ButtonClickedAction;
        }
    }
}

