using System;
using System.Web;
using System.Web.UI;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how to say Hello World to a user.
	/// </summary>
    public partial class HelloWorld : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Call the say method of the Tropo object and give it a prompt to say.
            tropo.Say("Hello World!");
            tropo.Say("hello London", null, null, "shname", null, null, null);
            tropo.Say("hello Tokyo", null, null, "shname", null, null, "none");
            tropo.Say("hello Moscow", null, null, "shname", null, null, "suppress");

            HttpContext.Current.Trace.Warn("tropo.JSONToTe666666xt() is " + tropo.JSONToText());

            tropo.RenderJSON(Response);
		}
	}
}
