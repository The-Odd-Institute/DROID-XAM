using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Views.Animations;

namespace NavAndSegment
{
    [Activity(Label = "Nav+Segment", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
       


        RadioGroup mapListRadioGroup;
        RadioButton mapButton;
        RadioButton listButton;

        TextView tempLabel;
        Button navigateButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.Main);
         
            Toolbar topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbar);
            Button backButton = FindViewById<Button>(Resource.Id.backButton);

            navigateButton = FindViewById<Button>(Resource.Id.navigateButton);
            navigateButton.Click += NavigateButton_Click;

            tempLabel = FindViewById<TextView>(Resource.Id.tempTextView);


            CreateSegmentControl();
           
        }




        void NavigateButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));

            StartActivity(intent);

            OverridePendingTransition(Resource.Animation.activity_slide_from_right, Resource.Animation.activity_slide_to_left);
         
        }


        void CreateSegmentControl()
        {
            mapListRadioGroup = FindViewById<RadioGroup>(Resource.Id.mapListRadioGroup);
            mapButton = FindViewById<RadioButton>(Resource.Id.mapButton);
            listButton = FindViewById<RadioButton>(Resource.Id.listButton);

			mapButton.Checked = true;

            mapListRadioGroup.CheckedChange += MapListRadioGroup_CheckedChanged;
         
        }


        void MapListRadioGroup_CheckedChanged(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            //bring in map/list
            if (listButton.Checked)
            {
                tempLabel.Text = "In ListView";
            }

            else if (mapButton.Checked)
            {
                tempLabel.Text = "In MapView";
            }
         
        }

    }

}

