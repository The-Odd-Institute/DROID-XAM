
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NavAndSegment
{
	public class SecondFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
                    
			View view = inflater.Inflate(Resource.Layout.Fragment2, container, false);

			Button next = view.FindViewById<Button>(Resource.Id.nextButton);
			next.Click += Next_Click;
      
            return view;
        }

		void Next_Click(object sender, EventArgs e)
		{

			ThirdFragment mFragment3 = new ThirdFragment();

			SecondActivity myActivity = (NavAndSegment.SecondActivity)this.Activity;
			myActivity.ShowFragment(mFragment3);

		}

    }
}
