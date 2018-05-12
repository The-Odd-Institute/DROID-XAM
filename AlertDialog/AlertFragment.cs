
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

namespace AlertDialog
{

    //sends the property data back to the activity class
	public class OnClickEventArgs: EventArgs
	{

		private string propertyNumber;

		public string PropertyNumber {

			get { return propertyNumber; }
			set { propertyNumber = value; }
			
		}

		public OnClickEventArgs(string propertyNumber): base()
		{
			PropertyNumber = propertyNumber;
		}
		
	}
   

	public class AlertFragment : Fragment
    {

		public event EventHandler<OnClickEventArgs> GoToProperty;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);         
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
			View view =  inflater.Inflate(Resource.Layout.Alert, container, false);

			RelativeLayout relativeLayout = view.FindViewById<RelativeLayout>(Resource.Id.RelativeLayout);
			relativeLayout.Click += RelativeLayout_Click;

			TextView priceLabel = view.FindViewById<TextView>(Resource.Id.priceLabel);
			TextView sizeLabel = view.FindViewById<TextView>(Resource.Id.sizeLabel);
			TextView bedsLabel = view.FindViewById<TextView>(Resource.Id.bedsLabel);
			TextView bathsLabel = view.FindViewById<TextView>(Resource.Id.bathsLabel);
            
			Button cancelButton = view.FindViewById<Button>(Resource.Id.cancelButton);
            cancelButton.Click += CancelButton_Click;
          

			return view;

        }

		void CancelButton_Click(object sender, System.EventArgs e)
        {

			Console.WriteLine("Cancel");

			FragmentManager.BeginTransaction()
						   .Remove(this).Commit();

        }

		void RelativeLayout_Click(object sender, EventArgs e)
		{

			GoToProperty.Invoke(this, new OnClickEventArgs("property1"));

			FragmentManager.BeginTransaction()
                           .Remove(this).Commit();
			
		}
       
    }
}
