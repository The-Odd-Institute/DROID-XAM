
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

using Android.Gms.Maps.Model;
//using Com.Google.Maps.Android.Clustering;

namespace GMaps
{

	public class MyMarker : Java.Lang.Object//, IClusterItem
    {

        public LatLng Position { get; set; }

		public string Snippet => throw new NotImplementedException();

		public string Title => throw new NotImplementedException();

		public MyMarker(double lat, double lng)
        {
            Position = new LatLng(lat, lng);
        }


	}
}
