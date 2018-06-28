package md5c4c2665eac7ccf1aa51407de3da2046a;


public class GridViewNoScroll
	extends android.widget.GridView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"";
		mono.android.Runtime.register ("MonoDroidToolkit.GridViewNoScroll, MonoDroidToolkit", GridViewNoScroll.class, __md_methods);
	}


	public GridViewNoScroll (android.content.Context p0)
	{
		super (p0);
		if (getClass () == GridViewNoScroll.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.GridViewNoScroll, MonoDroidToolkit", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public GridViewNoScroll (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == GridViewNoScroll.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.GridViewNoScroll, MonoDroidToolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public GridViewNoScroll (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == GridViewNoScroll.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.GridViewNoScroll, MonoDroidToolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public GridViewNoScroll (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == GridViewNoScroll.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.GridViewNoScroll, MonoDroidToolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);

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
