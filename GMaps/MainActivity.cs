using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Net.Http;
using System.Net;
using System;
using Android.Locations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using System.Linq;
using Android;
using System.IO;  

namespace GMaps
{
	[Activity(Label = "GMaps", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, IOnMapReadyCallback
	{

		private GoogleMap myMap;
		LatLng latLngSource;
		LatLng latLngDestination;

		SearchView searchView;

		LatLng fairviewCoordinates;
		LatLng capilanoCoordinates;

		PolylineOptions polylineoption;

		Button directionsButton;
		Button removeDirectionsButton;

		internal static string strGoogleServerKey = "AIzaSyAGcrxCjVg9I4KnkofLvCpqbpeh5kxer8A";
		internal static string strGoogleServerDirKey = "AIzaSyAGcrxCjVg9I4KnkofLvCpqbpeh5kxer8A";
		internal static string strGoogleDirectionUrl = "https://maps.googleapis.com/maps/api/directions/json?origin=";
		internal static string strGeoCodingUrl = "https://maps.googleapis.com/maps/api/geocode/json?{0}&key=" + strGoogleServerKey + "";
       
		internal static string strException = "Exception";
		internal static string strTextSource = "Source";
		internal static string strTextDestination = "Destination";

		internal static string strNoInternet = "No online connection. Please review your internet connection";
		internal static string strPleaseWait = "Please wait...";
		internal static string strUnableToConnect = "Unable to connect server!,Please try after sometime";

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
           
            fairviewCoordinates = new LatLng(49.262676, -123.133396);
            capilanoCoordinates = new LatLng(49.341072, -123.106519);
            
			SetupMap();

			searchView = FindViewById<SearchView>(Resource.Id.SearchView);

			directionsButton = FindViewById<Button>(Resource.Id.DirectionsButton);
			directionsButton.Click += DirectionsButton_Click;

			removeDirectionsButton = FindViewById<Button>(Resource.Id.RemoveDirectionsButton);
			removeDirectionsButton.Click += RemoveDirectionsButton_Click;
		}


		private void SetupMap()
		{
			if (myMap == null)
			{
				FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
			}
		}


		public void OnMapReady(GoogleMap googleMap)
		{
			myMap = googleMap;
			AddMarkers();
		}


        void AddMarkers()
		{
			//for (int i = 0; i <= 10; i++)
            //{

            //  LatLng latLng = new LatLng((49.2 + (i / 10)), (-123.1 + (i / 10)));
            //  MarkerOptions options = new MarkerOptions()
            //      .SetPosition(latLng);

            //  myMap.AddMarker(options);

            //}

            MarkerOptions fairviewOptions = new MarkerOptions().SetPosition(fairviewCoordinates);
            myMap.AddMarker(fairviewOptions);

            MarkerOptions capilanoOptions = new MarkerOptions().SetPosition(capilanoCoordinates);
            myMap.AddMarker(capilanoOptions);
		}

		void DirectionsButton_Click(object sender, System.EventArgs e)
		{

			LatLng midpoint = GetMidpoint(capilanoCoordinates, fairviewCoordinates);
			UpdateCameraPosition(midpoint);
			DrawPath(capilanoCoordinates, fairviewCoordinates);

			GetPathDistance(capilanoCoordinates, fairviewCoordinates);
          
		}

		LatLng GetMidpoint(LatLng source, LatLng destination)
		{

			Double lon1 = source.Longitude * Math.PI / 180;
			Double lon2 = destination.Longitude * Math.PI / 180;
            
			Double lat1 = source.Latitude * Math.PI / 180;
			Double lat2 = destination.Latitude * Math.PI / 180;
			Double dLon = lon2 - lon1;
			Double x = Math.Cos(lat2) * Math.Cos(dLon);
			Double y = Math.Cos(lat2) * Math.Sin(dLon);

			Double lat3 = Math.Atan2(Math.Sin(lat1) + Math.Sin(lat2), Math.Sqrt((Math.Cos(lat1) + x) * (Math.Cos(lat1) + x) + y * y));
			Double lon3 = lon1 + Math.Atan2(y, Math.Cos(lat1) + x);

			LatLng center = new LatLng(lat3 * 180 / Math.PI, lon3 * 180 / Math.PI);

			return center;
               
		}
          
       
		void RemoveDirectionsButton_Click(object sender, EventArgs e)
		{
			if (myMap != null)
            {
                myMap.Clear();
				AddMarkers();
            }

			directionsButton.Text = "Show Directions";
		}


		void UpdateCameraPosition(LatLng point)
		{
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
			builder.Target(point);
			builder.Zoom(10);
			//builder.Bearing(45);
			//builder.Tilt(10);
			CameraPosition cameraPosition = builder.Build();
			CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
			myMap.AnimateCamera(cameraUpdate);
		}




        //Polyline methods
		async void DrawPath(LatLng source, LatLng destination)
		{
			string strFullDirectionURL = strGoogleDirectionUrl + source.Latitude + "," + source.Longitude + "&destination=" + destination.Latitude + "," + destination.Longitude + "&sensor=true&mode=driving&key=" + strGoogleServerDirKey + "";

			string strJSONDirectionResponse = await HttpRequest(strFullDirectionURL);

			if (strJSONDirectionResponse != strException)
			{
				RunOnUiThread(() =>
				{
					if (myMap != null)
					{
						myMap.Clear();
    
						MarkerOptions sourceMarkerOptions = new MarkerOptions()
							.SetPosition(capilanoCoordinates);

						myMap.AddMarker(sourceMarkerOptions);

						MarkerOptions destMarkerOptions = new MarkerOptions()
							.SetPosition(fairviewCoordinates);

						myMap.AddMarker(destMarkerOptions);
                       
					}
				});
				SetDirectionQuery(strJSONDirectionResponse);
			}
			else
			{
				RunOnUiThread(() =>
				   Toast.MakeText(this, strUnableToConnect, ToastLength.Short).Show());
			}

		}
		void SetDirectionQuery(string strJSONDirectionResponse)
		{
			var objRoutes = JsonConvert.DeserializeObject<GoogleDirectionClass>(strJSONDirectionResponse);
			//objRoutes.routes.Count  --may be more then one 
			if (objRoutes.routes.Count > 0)
			{
				string encodedPoints = objRoutes.routes[0].overview_polyline.points;

				var lstDecodedPoints = DecodePolylinePoints(encodedPoints);
				//convert list of location point to array of latlng type
				var latLngPoints = new LatLng[lstDecodedPoints.Count];
				int index = 0;
				foreach (Location loc in lstDecodedPoints)
				{
					latLngPoints[index++] = new LatLng(loc.Latitude, loc.Longitude);
				}

				polylineoption = new PolylineOptions();
				polylineoption.InvokeColor(Android.Graphics.Color.Red);
				polylineoption.Geodesic(true);
				polylineoption.Add(latLngPoints);
				RunOnUiThread(() =>
							  myMap.AddPolyline(polylineoption));
			}
		}

		List<Location> DecodePolylinePoints(string encodedPoints)
		{
			if (string.IsNullOrEmpty(encodedPoints))
				return null;
			var poly = new List<Location>();
			char[] polylinechars = encodedPoints.ToCharArray();
			int index = 0;

			int currentLat = 0;
			int currentLng = 0;
			int next5bits;
			int sum;
			int shifter;

			try
			{
				while (index < polylinechars.Length)
				{
					// calculate next latitude
					sum = 0;
					shifter = 0;
					do
					{
						next5bits = (int)polylinechars[index++] - 63;
						sum |= (next5bits & 31) << shifter;
						shifter += 5;
					} while (next5bits >= 32 && index < polylinechars.Length);

					if (index >= polylinechars.Length)
						break;

					currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

					//calculate next longitude
					sum = 0;
					shifter = 0;
					do
					{
						next5bits = (int)polylinechars[index++] - 63;
						sum |= (next5bits & 31) << shifter;
						shifter += 5;
					} while (next5bits >= 32 && index < polylinechars.Length);

					if (index >= polylinechars.Length && next5bits >= 32)
						break;

					currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
					Location loc = new Location("");
            
					loc.Latitude = Convert.ToDouble(currentLat) / 100000.0;
					loc.Longitude = Convert.ToDouble(currentLng) / 100000.0;
					poly.Add(loc);
				}
			}
			catch
			{
				RunOnUiThread(() =>
				  Toast.MakeText(this, strPleaseWait, ToastLength.Short).Show());
			}
			return poly;
		}


        //Path Distance method
		async void GetPathDistance(LatLng sourceCoordinate, LatLng destinationCoordinate)
		{            
		         
			Double distance;
            
            String url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + sourceCoordinate.Latitude + "," + sourceCoordinate.Longitude + "&destination=" + destinationCoordinate.Latitude + "," + destinationCoordinate.Longitude + "&sensor=true&mode=driving&key=" + strGoogleServerDirKey;
           
			string strJSONDirectionResponse = await HttpRequest(url);

            if (strJSONDirectionResponse != strException)
            {
				var objRoutes = JsonConvert.DeserializeObject<GoogleDirectionClass>(strJSONDirectionResponse);
                if (objRoutes.routes.Count > 0)
                {
					distance = objRoutes.routes.Sum(r => r.legs.Sum(l => l.distance.value));

                    if (distance == 0.00)
                    {
                        throw new Exception("Google cannot find road route");
                    }

					else {
						RunOnUiThread(() =>
						              directionsButton.Text = distance/1000 + " Kms");
					}

                }
                else
                {
                    throw new Exception("Unable to get location from google");
                }

            }
            
            else
            {
                RunOnUiThread(() =>
                   Toast.MakeText(this, strUnableToConnect, ToastLength.Short).Show());
            }
   
        }  
  
  

        //making Https requests
		WebClient webclient;
		async Task<string> HttpRequest(string strUri)
		{
			webclient = new WebClient();
			string strResultData;
			try
			{
				strResultData = await webclient.DownloadStringTaskAsync(new Uri(strUri));
				Console.WriteLine(strResultData);
			}
			catch
			{
				strResultData = strException;
			}
			finally
			{
				if (webclient != null)
				{
					webclient.Dispose();
					webclient = null;
				}
			}

			return strResultData;
		}

		string HttpRequestOnMainThread(string strUri)
		{
			webclient = new WebClient();
			string strResultData;
			try
			{
				strResultData = webclient.DownloadString(new Uri(strUri));
				Console.WriteLine(strResultData);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				strResultData = strException;
			}
			finally
			{
				if (webclient != null)
				{
					webclient.Dispose();
					webclient = null;
				}
			}

			return strResultData;
		}
	}
}
      

