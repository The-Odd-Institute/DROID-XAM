package dk.ostebaronen.droid.viewpagerindicator;


public class LinePageIndicator_LineSavedState
	extends android.view.View.BaseSavedState
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler\n" +
			"n_InitializeCreator:()Ldk/ostebaronen/droid/viewpagerindicator/LinePageIndicator_LineSavedState_LineSavedStateCreator;:__export__\n" +
			"";
		mono.android.Runtime.register ("DK.Ostebaronen.Droid.ViewPagerIndicator.LinePageIndicator+LineSavedState, DK.Ostebaronen.Droid.ViewPagerIndicator", LinePageIndicator_LineSavedState.class, __md_methods);
	}


	public LinePageIndicator_LineSavedState (android.os.Parcel p0)
	{
		super (p0);
		if (getClass () == LinePageIndicator_LineSavedState.class)
			mono.android.TypeManager.Activate ("DK.Ostebaronen.Droid.ViewPagerIndicator.LinePageIndicator+LineSavedState, DK.Ostebaronen.Droid.ViewPagerIndicator", "Android.OS.Parcel, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public LinePageIndicator_LineSavedState (android.os.Parcel p0, java.lang.ClassLoader p1)
	{
		super (p0, p1);
		if (getClass () == LinePageIndicator_LineSavedState.class)
			mono.android.TypeManager.Activate ("DK.Ostebaronen.Droid.ViewPagerIndicator.LinePageIndicator+LineSavedState, DK.Ostebaronen.Droid.ViewPagerIndicator", "Android.OS.Parcel, Mono.Android:Java.Lang.ClassLoader, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public LinePageIndicator_LineSavedState (android.os.Parcelable p0)
	{
		super (p0);
		if (getClass () == LinePageIndicator_LineSavedState.class)
			mono.android.TypeManager.Activate ("DK.Ostebaronen.Droid.ViewPagerIndicator.LinePageIndicator+LineSavedState, DK.Ostebaronen.Droid.ViewPagerIndicator", "Android.OS.IParcelable, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public static dk.ostebaronen.droid.viewpagerindicator.LinePageIndicator_LineSavedState_LineSavedStateCreator CREATOR = InitializeCreator ();


	public void writeToParcel (android.os.Parcel p0, int p1)
	{
		n_writeToParcel (p0, p1);
	}

	private native void n_writeToParcel (android.os.Parcel p0, int p1);

	public static dk.ostebaronen.droid.viewpagerindicator.LinePageIndicator_LineSavedState_LineSavedStateCreator InitializeCreator ()
	{
		return n_InitializeCreator ();
	}

	private static native dk.ostebaronen.droid.viewpagerindicator.LinePageIndicator_LineSavedState_LineSavedStateCreator n_InitializeCreator ();

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
