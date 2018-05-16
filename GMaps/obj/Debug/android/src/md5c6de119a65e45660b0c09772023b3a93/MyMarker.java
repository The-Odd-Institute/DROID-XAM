package md5c6de119a65e45660b0c09772023b3a93;


public class MyMarker
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.maps.android.clustering.ClusterItem
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getPosition:()Lcom/google/android/gms/maps/model/LatLng;:GetGetPositionHandler:Com.Google.Maps.Android.Clustering.IClusterItemInvoker, GoogleMapsUtilityBinding\n" +
			"n_getSnippet:()Ljava/lang/String;:GetGetSnippetHandler:Com.Google.Maps.Android.Clustering.IClusterItemInvoker, GoogleMapsUtilityBinding\n" +
			"n_getTitle:()Ljava/lang/String;:GetGetTitleHandler:Com.Google.Maps.Android.Clustering.IClusterItemInvoker, GoogleMapsUtilityBinding\n" +
			"";
		mono.android.Runtime.register ("GMaps.MyMarker, GMaps", MyMarker.class, __md_methods);
	}


	public MyMarker ()
	{
		super ();
		if (getClass () == MyMarker.class)
			mono.android.TypeManager.Activate ("GMaps.MyMarker, GMaps", "", this, new java.lang.Object[] {  });
	}

	public MyMarker (double p0, double p1)
	{
		super ();
		if (getClass () == MyMarker.class)
			mono.android.TypeManager.Activate ("GMaps.MyMarker, GMaps", "System.Double, mscorlib:System.Double, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public com.google.android.gms.maps.model.LatLng getPosition ()
	{
		return n_getPosition ();
	}

	private native com.google.android.gms.maps.model.LatLng n_getPosition ();


	public java.lang.String getSnippet ()
	{
		return n_getSnippet ();
	}

	private native java.lang.String n_getSnippet ();


	public java.lang.String getTitle ()
	{
		return n_getTitle ();
	}

	private native java.lang.String n_getTitle ();

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
