using Android.App;
using Android.Widget;
using Android.OS;

namespace Borders
{
    [Activity(Label = "Borders", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 0;

		FrameLayout frameLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			frameLayout = FindViewById<FrameLayout>(Resource.Id.frameLayout);

			MyFragment fragment = new MyFragment();

            FragmentManager.BeginTransaction()
                           .Add(Resource.Id.frameLayout, fragment, "frag")
                           .SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out)
              .Commit();

   
            Button showABorder = FindViewById<Button>(Resource.Id.showBorder);

			showABorder.Click += ShowABorder_Click;
        }

		void ShowABorder_Click(object sender, System.EventArgs e)
		{
			if (count == 5)
            {
                count = 0;
            }
		
			switch (count){
				case 0: drawTopBorder();
					break;
				case 1: drawLeftBorder();
					break;
				case 2:
                    drawRightBorder();
                    break;
				case 3:
                    drawBottomBorder();
                    break;
				case 4:
					drawAllBorders();
					break;
				default: break;
					
			}
    
			    

			count++;
			
		}


		protected void drawTopBorder()
		{
			
			frameLayout.SetBackgroundResource(Resource.Drawable.TopBorder);
		}

		protected void drawLeftBorder()
        {
			frameLayout.SetBackgroundResource(Resource.Drawable.LeftBorder);
        }

		protected void drawRightBorder()
        {
			frameLayout.SetBackgroundResource(Resource.Drawable.RightBorder);
        }

		protected void drawBottomBorder()
        {
			frameLayout.SetBackgroundResource(Resource.Drawable.BottomBorder);
        }

		protected void drawAllBorders()
        {
            frameLayout.SetBackgroundResource(Resource.Drawable.AllBorders);
        }


    }
}

