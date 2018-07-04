package md58bf456a1c93cc3169473a0efaabb6946;


public class TokenService
	extends com.microsoft.appcenter.push.TokenService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Microsoft.AppCenter.Push.TokenService, Microsoft.AppCenter.Push.Android.Bindings", TokenService.class, __md_methods);
	}


	public TokenService ()
	{
		super ();
		if (getClass () == TokenService.class)
			mono.android.TypeManager.Activate ("Microsoft.AppCenter.Push.TokenService, Microsoft.AppCenter.Push.Android.Bindings", "", this, new java.lang.Object[] {  });
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
