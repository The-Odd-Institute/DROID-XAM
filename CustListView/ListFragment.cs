using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Android.Support.V4;
using Android.Support.V4.Widget;

using Wahid.SwipemenuListview;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace CustListView
{
	public class ListFragment : Fragment, IOnMenuItemClickListener, ISwipeMenuCreator
	{

		List<string> namesArray;
		LinearLayout linearLayout;
		Context theContext;
		ArrayAdapter<string> arrayAdapter;
		public FrameLayout frameLayout;
		SwipeMenuListView listView;

        SwipeRefreshLayout refresher;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		}

		public override void OnAttach(Context context)
		{
			base.OnAttach(context);

			theContext = context;
         
		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
           
			View view = inflater.Inflate(Resource.Layout.ListFragment, container, false);
	
			namesArray = new List<string> { "James", "Frank", "David", "Toby", "Michael", "Pam", "Jim", "Dwight", "Kevin"  };
			namesArray.Add("John");

			arrayAdapter = new ArrayAdapter<string>(this.Activity, Android.Resource.Layout.SimpleListItem1, namesArray);

			listView = view.FindViewById<SwipeMenuListView>(Resource.Id.listView);

			listView.MenuCreator = this;
			listView.MenuItemClickListener = this;

			listView.Adapter = arrayAdapter;

			listView.SetOnScrollListener(new ScrollListener());

			refresher = view.FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            refresher.SetColorSchemeColors(Color.DarkBlue,
                                     Color.Purple,
                                     Color.Gray,
                                      Color.Green);


            refresher.Refresh += Refresher_Refresh;
         
			return view;
		}


        //PullToRefreshMethod
		async void Refresher_Refresh(object sender, System.EventArgs e)
        {
            //await fetching new items
            refresher.Refreshing = false;
        }



        //SwipeLeftToEdit stuff
		public void Create(SwipeMenu menu)
		{

			SwipeMenuItem copyItem = new SwipeMenuItem(this.Activity)
			{
				Background = new ColorDrawable(Color.Azure),
				Width = 200,
				IconRes = Resource.Mipmap.Icon
			};
			menu.AddMenuItem(copyItem);
		}

		public bool OnMenuItemClick(int position, SwipeMenu menu, int index)
		{
			
			switch (index)
			{
				case 0:
					if (menu.GetViewType() == 0)
					{
						DeleteItemAlert(position);
					}
					else
					{

					}
                   
					break;
			}
			return false;
		}





        //AlertDialog
		void DeleteItemAlert(int position)
		{

			string toRemove = namesArray[position];

			AlertDialog.Builder alert = new AlertDialog.Builder(this.Activity);
			alert.SetTitle("Do you want to delete or deactivate?");
			alert.SetMessage("Or cancel?");

			alert.SetPositiveButton("Delete", (senderAlert, eAlert) => DeleteString(toRemove));
			alert.SetNeutralButton("Deactivate", (senderAlert, eAlert) =>  DeactivateString(position) );
			alert.SetNegativeButton("Cancel", (senderAlert, eAlert) => { });

			Dialog dialog = alert.Create();
			dialog.Show();

		}

        //STRINGS ARENT BEING DELETED FOR SOME REASON!!!
		void DeleteString(string inpString)
		{
			//arrayAdapte
			//e.View.Animate()
			//.SetDuration(750)
			//.Alpha(0)
			//.WithEndAction(new Java.Lang.Runnable(() => {
        
           
			namesArray.Remove(inpString);

			arrayAdapter.NotifyDataSetChanged();
         
			//    e.View.Alpha = 1;
			//}));
            
		}
        
        void DeactivateString(int position)
		{


		}












        //SnapToRow stuff
		public class ScrollListener : Java.Lang.Object, AbsListView.IOnScrollListener
		{
	

			public void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
			{
			//	throw new NotImplementedException();
			}

			public void OnScrollStateChanged(AbsListView view, [GeneratedEnum] ScrollState scrollState)
			{
                  if (scrollState == 0)
                         {
                      View itemView = view.GetChildAt(0);
                      int top = Java.Lang.Math.Abs(itemView.Top);
                      int bottom = Java.Lang.Math.Abs(itemView.Bottom);
                             int scrollBy = top >= bottom ? bottom : -top;
                             if (scrollBy == 0)
                             {
                                 return;
                             }
                             SmoothScrollDeferred(scrollBy, (ListView)view);
                         }
            }

			private void SmoothScrollDeferred(int scrollByF,
                   ListView viewF)
            {
              Handler h = new Handler();
              h.Post(() =>
                  {
                      viewF.SmoothScrollBy(scrollByF, 200);
                  });
            }
		}
            
    }
}