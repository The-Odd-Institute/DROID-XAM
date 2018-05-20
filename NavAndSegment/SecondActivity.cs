
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

using SupportFragment = Android.Support.V4.App.Fragment;

namespace NavAndSegment
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

		Button backButton;
       
		private FrameLayout mFragmentContainer;
		private Fragment mCurrentFragment;
		private SecondFragment mFragment2;
	
		private Stack<Fragment> mStackFragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			Window.RequestFeature(WindowFeatures.NoTitle);

			SetContentView(Resource.Layout.SecondActivity);

			mFragmentContainer = FindViewById<FrameLayout>(Resource.Id.frameLayout1);
            
            Toolbar topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbar);

            backButton = FindViewById<Button>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;

			mFragment2 = new SecondFragment();
         
			mStackFragments = new Stack<Fragment>();

			var trans =  FragmentManager.BeginTransaction();
			trans.Add(Resource.Id.frameLayout1, mFragment2, "Fragment2");
            trans.Commit();

            mCurrentFragment = mFragment2;
    
        }

		public void ShowFragment (Fragment fragment)
        {
            if (fragment.IsVisible){
                return;
            }
            
            var trans = FragmentManager.BeginTransaction();

			trans.SetCustomAnimations(Resource.Animation.fragment_enter_from_left,
			                          Resource.Animation.fragment_enter_from_right, Resource.Animation.fragment_exit_from_right,
			                          Resource.Animation.fragment_exit_from_left);
         
            trans.Hide(mCurrentFragment);
			trans.Add(Resource.Id.frameLayout1, fragment, "Fragment");
            trans.Show(fragment);

            trans.AddToBackStack(null);
            mStackFragments.Push(mCurrentFragment);
            trans.Commit();

            mCurrentFragment = fragment;
        }
        

		void BackButton_Click(object sender, EventArgs e)
		{
            

			if (FragmentManager.BackStackEntryCount > 0)
            {
				FragmentManager.PopBackStack();
                mCurrentFragment = mStackFragments.Pop();
            }

            else
            {
                base.OnBackPressed();

				Finish();
              
                OverridePendingTransition(Resource.Animation.activity_slide_from_left, Resource.Animation.activity_slide_to_right);
            
            }   


		}

    }
}
