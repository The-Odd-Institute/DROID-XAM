
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
using Android.Views.Animations;

namespace NavAndSegment
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

		Button backButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			Window.RequestFeature(WindowFeatures.NoTitle);

			SetContentView(Resource.Layout.Second);
            
            Toolbar topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbar);
            backButton = FindViewById<Button>(Resource.Id.backButton);

			backButton.Click += BackButton_Click;
           
        }

		void BackButton_Click(object sender, EventArgs e)
		{
            
			Finish();

    
			OverridePendingTransition(Resource.Animation.slide_from_left, Resource.Animation.slide_to_right);
		}

    }
}
