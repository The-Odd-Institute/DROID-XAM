﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Net;

using Android.Support.V4;
using Android.Content.PM;

using Android.Provider;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
//using Java.Util;
using Android.Views;
using Java.IO;
using System.Globalization;
//using System;

namespace ImageSelection
{
    [Activity(Label = "ImageSelection", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
		public static readonly int PickImageId = 1000;
		Button btnupload;
        ImageView profimg1, profimg2, profimg3,profimg4;
		Uri file;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

	            
			if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != Permission.Granted)
            {
            
				ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera, Manifest.Permission.WriteExternalStorage }, 0);
            }

			btnupload = FindViewById<Button>(Resource.Id.btniploadpic);
            profimg1 = FindViewById<ImageView>(Resource.Id.profimg1);
            profimg2 = FindViewById<ImageView>(Resource.Id.profimg2);
            profimg3 = FindViewById<ImageView>(Resource.Id.profimg3);
            profimg4 = FindViewById<ImageView>(Resource.Id.profimg4);
			btnupload.Click +=
			(sender, e) =>
			{
				Intent intent;

				string[] items = { "Take Photo", "Choose from Library", "Cancel" };

				PackageManager pm = this.PackageManager;
                

                using (var dialogBuilder = new AlertDialog.Builder(this))
                {
					
                    dialogBuilder.SetTitle("Add Photo");
                    dialogBuilder.SetItems(items, (d, args) => {
                        //Take photo
						if (args.Which == 0)
                        {

							TakePicture(profimg1);
                        }

                        //Choose from gallery
                        else if (args.Which == 1)
                        {
							intent = new Intent(Intent.ActionPick, MediaStore.Images.Media.ExternalContentUri);
                                           
							intent.SetType("image/*");
                            intent.PutExtra(Intent.ExtraAllowMultiple, true);
                            //intent.SetAction(Intent.ActionGetContent);

                            this.StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 1);
                        }
                    });

                    dialogBuilder.Show();
                }
                   
			};
        }


		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{

			if (requestCode == 100)
            {
				if (resultCode == Result.Ok)
                {
					profimg1.SetImageURI(file);
                }
            }


			else if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
			{
				ClipData clipData = data.ClipData;
				if (clipData != null)
				{
					for (int i = 0; i < clipData.ItemCount; i++)
					{
						ClipData.Item item
						= clipData.GetItemAt(i);
						Uri uri = item.Uri;
						if (i == 0)
						{
							profimg1.SetImageURI(uri);
						}
						else if (i == 1)
						{
							profimg2.SetImageURI(uri);
						}
						else if (i == 2)
						{
							profimg3.SetImageURI(uri);
						}
						else if (i == 3)
						{
							profimg4.SetImageURI(uri);
						}
					}
				}
				//Uri
				// uri = data.Data; for single images
				//profimg1.SetImageURI(uri);
			}
		}
        

        
		public void TakePicture(View view)
        {
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			file = Uri.FromFile(GetOutputMediaFile());
			intent.PutExtra(MediaStore.ExtraOutput, file);

            StartActivityForResult(intent, 100);
        }


		private File GetOutputMediaFile()
		{
			
			File mediaStorageDir = new File(Environment.GetExternalStoragePublicDirectory(
				Environment.DirectoryPictures), "CameraDemo");

			if (!mediaStorageDir.Exists())
            {
				if (!mediaStorageDir.Mkdirs())
                {
                    return null;
                }
            }

            
			string timeStamp = (new System.DateTime()).ToString("ddd, dd MMM yyyy HH:mm:ss z", new CultureInfo("en-US"));

            
			//string timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
			return new File(mediaStorageDir.Path + File.Separator +
                        "IMG_" + timeStamp + ".jpg");
         
        }

        
    }

}

