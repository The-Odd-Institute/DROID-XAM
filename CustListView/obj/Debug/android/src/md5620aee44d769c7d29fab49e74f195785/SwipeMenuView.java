package md5620aee44d769c7d29fab49e74f195785;


public class SwipeMenuView
	extends android.widget.LinearLayout
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Wahid.SwipemenuListview.SwipeMenuView, CustListView", SwipeMenuView.class, __md_methods);
	}


	public SwipeMenuView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SwipeMenuView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuView, CustListView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SwipeMenuView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SwipeMenuView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuView, CustListView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SwipeMenuView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SwipeMenuView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuView, CustListView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SwipeMenuView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SwipeMenuView.class)
			mono.android.TypeManager.Activate ("Wahid.SwipemenuListview.SwipeMenuView, CustListView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
