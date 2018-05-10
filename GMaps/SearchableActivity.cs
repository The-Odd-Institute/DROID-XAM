
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

namespace GMaps
{
    [Activity(Label = "SearchableActivity")]
    public class SearchableActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
			//// Get the intent, verify the action and get the query
             //Intent intent = GetIntent();
             //if (Intent.ActionSearch.Equals(intent.getAction())) {
				
             //String query = intent.GetStringExtra(SearchManager.QUERY);
             //doMySearch(query);
            // }
        }
    }
}
