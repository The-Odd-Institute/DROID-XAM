
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Fragments
{

	//delegation back to the activity class
    public class ColorChangeEventArgs : EventArgs
    {

		private Color backgroundColor;

		public Color BackgroundColor
        {

			get { return backgroundColor; }
			set { backgroundColor = value; }

        }


		public ColorChangeEventArgs(Color bgColor) : base()
        {
			BackgroundColor = bgColor;
        }

    }


    public class FrameChangeEventArgs : EventArgs
    {

		private int frameWidth;

        public int FrameWidth
        {
			get { return frameWidth; }
			set { frameWidth = value; }
        }

		public FrameChangeEventArgs(int width) : base()
        {
			FrameWidth = width;
        }

    }



    public class MyFragment : Fragment
    {

		public event EventHandler<ColorChangeEventArgs> ChangeToBlue;
		public event EventHandler<ColorChangeEventArgs> ChangeToOrange;
		public event EventHandler<FrameChangeEventArgs> ChangeFrame;


   
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

			View view = inflater.Inflate(Resource.Layout.MyFragment, container, false);

            Button changeBackgroundToBlue = view.FindViewById<Button>(Resource.Id.changeBgColorToBlue);
			changeBackgroundToBlue.Click += ChangeBackgroundToBlue_Click;
            
			Button changeBackgroundToOrange = view.FindViewById<Button>(Resource.Id.changeBgColorToOrange);
			changeBackgroundToOrange.Click += ChangeBackgroundToOrange_Click;

			Button changeFrame = view.FindViewById<Button>(Resource.Id.changeFrameButton);
			changeFrame.Click += ChangeFrame_Click;
			return view;
        }

		void ChangeBackgroundToBlue_Click(object sender, EventArgs e)
		{
			ChangeToBlue.Invoke(this, new ColorChangeEventArgs(Color.Blue));
		}

		void ChangeBackgroundToOrange_Click(object sender, EventArgs e)
        {
			ChangeToOrange.Invoke(this, new ColorChangeEventArgs(Color.Orange));
        }

		void ChangeFrame_Click(object sender, EventArgs e)
		{

			ChangeFrame.Invoke(this, new FrameChangeEventArgs(this.View.Width / 2));

		}

    }
}
