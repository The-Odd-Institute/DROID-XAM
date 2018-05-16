package md5620aee44d769c7d29fab49e74f195785;


public class SwipeMenuListView_MyAdapter
	extends md5620aee44d769c7d29fab49e74f195785.SwipeMenuAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Wahid.SwipemenuListview.SwipeMenuListView+MyAdapter, CustListView", SwipeMenuListView_MyAdapter.class, __md_methods);
	}


	public SwipeMenuListView_MyAdapter ()
	{
		super ();
		if (getClass () == SwipeMenuListView_MyAdapter.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuListView+MyAdapter, CustListView", "", this, new java.lang.Object[] {  });
	}

	public SwipeMenuListView_MyAdapter (android.content.Context p0, android.widget.ListAdapter p1)
	{
		super ();
		if (getClass () == SwipeMenuListView_MyAdapter.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuListView+MyAdapter, CustListView", "Android.Content.Context, Mono.Android:Android.Widget.IListAdapter, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
