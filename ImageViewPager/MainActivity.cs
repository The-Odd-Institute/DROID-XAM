using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V4.View;
using DK.Ostebaronen.Droid.ViewPagerIndicator;

namespace ImageViewPager
{
	[Activity(Label = "ImageViewPager", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
		ScrollView scrollView;
  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

			scrollView = FindViewById<ScrollView>(Resource.Id.scrollView1);

			var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

			ImageAdapter imageAdapter = new ImageAdapter(this);

			viewPager.Adapter = imageAdapter;
     
            //Bind the title indicator to the adapter
			var titleIndicator = FindViewById<CirclePageIndicator>(Resource.Id.pageIndicator);
			titleIndicator.SetViewPager(viewPager);
   
        }
      
    }
   
}

