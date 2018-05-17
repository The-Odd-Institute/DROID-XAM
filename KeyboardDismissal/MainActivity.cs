using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using Android.Support.V4.View;
using static Android.Views.View;
using Android.Views;

namespace KeyboardDismissal
{
    [Activity(Label = "KeyboardDismissal", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, IOnFocusChangeListener
    {
             
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
         
            Button button = FindViewById<Button>(Resource.Id.button);
			button.Click += Button_Click;
            
			EditText bottom = FindViewById<EditText>(Resource.Id.editText1);
			bottom.OnFocusChangeListener = this;


			EditText top = FindViewById<EditText>(Resource.Id.editText2);
			top.OnFocusChangeListener = this;
             
        }
        
		void Button_Click(object sender, System.EventArgs e)
        {
			HideSoftKeyBoard((View) sender);
        }

      


		public void OnFocusChange(View v, bool hasFocus)
        {
			if (!hasFocus) {
				HideSoftKeyBoard(v);
            }
        }



		private void HideSoftKeyBoard(View view)
        {
			InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);

			if (imm.IsAcceptingText)
            { // verify if the soft keyboard is open                      
				imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }
        

              
      
	}
}

