using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Delegation
{
    [Activity(Label = "Delegation", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
    {
      

		TextView textView;



		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
			button.Click += Button_Click;

			textView = FindViewById<TextView>(Resource.Id.textView1);
			textView.Text = "2nd activity Button hasnt been clicked yet";

        }

		void Button_Click(object sender, System.EventArgs e)
		{
          
			Intent intent = new Intent(this, typeof(SecondActivity));

			StartActivityForResult(intent, 0);
 
           
		}

		public void UpdateText(int clicks)
        {
            textView.Text = "2nd activity's button has been clicked: " + clicks + " times";
        }




		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
				int intRetFromResult = data.GetIntExtra("clicks", 0);
				UpdateText(intRetFromResult);
            }
        }

    }
}

