using System;
using System.Web;
using System.Web.UI;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how to say Hello World to a user.
	/// </summary>
    public partial class OnExample1Error : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Call the say method of the Tropo object and give it a prompt to say.
            tropo.Say("Hello I am On Example 1 Error!");

            HttpContext.Current.Trace.Warn("tropo.RenderJSON() is " + tropo.RenderJSON());

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
		}
	}
}
