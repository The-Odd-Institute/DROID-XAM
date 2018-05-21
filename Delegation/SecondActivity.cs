
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Delegation
{
    
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

		int count = 0;
  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Second);


			Button clickButton = FindViewById<Button>(Resource.Id.button1);
			clickButton.Click += Button_Click;

			Button backButton = FindViewById<Button>(Resource.Id.button2);
			backButton.Click += BackButton_Click;
        }

		void Button_Click(object sender, EventArgs e)
		{
            
			count++;
		}
        
        void BackButton_Click(object sender, EventArgs e)
		{
         
            Intent returnIntent = new Intent(this, typeof(MainActivity));
            returnIntent.PutExtra("clicks", count);
            SetResult(Result.Ok, returnIntent);
            Finish();

		}

    }
}
