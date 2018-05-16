using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace FlipAnimation
{
    [Activity(Label = "FlipAnimation", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
		private bool showingRegister;

		FrameLayout fragmentFrame;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
           
            Button flipButton = FindViewById<Button>(Resource.Id.flipButton);

			flipButton.Click += FlipButton_Click;

            
			fragmentFrame = FindViewById<FrameLayout>(Resource.Id.frameLayout);


            //present register first
			RegisterFragment registerFragment = new RegisterFragment();

            FragmentManager.BeginTransaction()
			               .Add(Resource.Id.frameLayout, registerFragment, "frag")
              .Commit();

			showingRegister = true;
        }

       



		void FlipButton_Click(object sender, System.EventArgs e)
		{

			if(showingRegister) {
				FragmentManager.PopBackStack();

				showingRegister = false;
			}
			else {

				FragmentTransaction transaction = FragmentManager.BeginTransaction();

				transaction.SetCustomAnimations(Resource.Animation.flip_right_in, Resource.Animation.flip_right_out,
				                                    Resource.Animation.flip_left_in, Resource.Animation.flip_left_out);
                
				transaction.Replace(Resource.Id.frameLayout, new LoginFragment());
				transaction.AddToBackStack(null);
				transaction.Commit();

				showingRegister = true;

			}


		}

    }


	public class RegisterFragment: Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.Register, container, false);

			return view;
            
		}

	}

	public class LoginFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Login, container, false);

            return view;
            

        }


    }
}

