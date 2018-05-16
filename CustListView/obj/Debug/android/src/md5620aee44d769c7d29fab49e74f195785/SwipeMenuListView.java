package md5620aee44d769c7d29fab49e74f195785;


public class SwipeMenuListView
	extends android.widget.ListView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setAdapter:(Landroid/widget/ListAdapter;)V:GetSetAdapter_Landroid_widget_ListAdapter_Handler\n" +
			"n_getAdapter:()Landroid/widget/ListAdapter;:GetGetAdapterHandler\n" +
			"n_onInterceptTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Wahid.SwipemenuListview.SwipeMenuListView, CustListView", SwipeMenuListView.class, __md_methods);
	}


	public SwipeMenuListView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SwipeMenuListView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuListView, CustListView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SwipeMenuListView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SwipeMenuListView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuListView, CustListView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SwipeMenuListView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SwipeMenuListView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuListView, CustListView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SwipeMenuListView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SwipeMenuListView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuListView, CustListView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void setAdapter (android.widget.ListAdapter p0)
	{
		n_setAdapter (p0);
	}

	private native void n_setAdapter (android.widget.ListAdapter p0);


	public android.widget.ListAdapter getAdapter ()
	{
		return n_getAdapter ();
	}

	private native android.widget.ListAdapter n_getAdapter ();


	public boolean onInterceptTouchEvent (android.view.MotionEvent p0)
	{
		return n_onInterceptTouchEvent (p0);
	}

	private native boolean n_onInterceptTouchEvent (android.view.MotionEvent p0);


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

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
