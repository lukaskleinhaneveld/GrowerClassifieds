package md5c4c2665eac7ccf1aa51407de3da2046a;


public class ScrollingTextView
	extends android.widget.TextView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFocusChanged:(ZILandroid/graphics/Rect;)V:GetOnFocusChanged_ZILandroid_graphics_Rect_Handler\n" +
			"n_onWindowFocusChanged:(Z)V:GetOnWindowFocusChanged_ZHandler\n" +
			"n_isFocused:()Z:GetIsFocusedHandler\n" +
			"";
		mono.android.Runtime.register ("MonoDroidToolkit.ScrollingTextView, MonoDroidToolkit", ScrollingTextView.class, __md_methods);
	}


	public ScrollingTextView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ScrollingTextView.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.ScrollingTextView, MonoDroidToolkit", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ScrollingTextView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ScrollingTextView.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.ScrollingTextView, MonoDroidToolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ScrollingTextView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ScrollingTextView.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.ScrollingTextView, MonoDroidToolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ScrollingTextView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ScrollingTextView.class)
			mono.android.TypeManager.Activate ("MonoDroidToolkit.ScrollingTextView, MonoDroidToolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onFocusChanged (boolean p0, int p1, android.graphics.Rect p2)
	{
		n_onFocusChanged (p0, p1, p2);
	}

	private native void n_onFocusChanged (boolean p0, int p1, android.graphics.Rect p2);


	public void onWindowFocusChanged (boolean p0)
	{
		n_onWindowFocusChanged (p0);
	}

	private native void n_onWindowFocusChanged (boolean p0);


	public boolean isFocused ()
	{
		return n_isFocused ();
	}

	private native boolean n_isFocused ();

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
