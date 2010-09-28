using System;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	public partial class HelloWorld : System.Web.UI.Page
	{
		
		public void Page_Load (object sender, EventArgs args)
		{
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Call the say method of the Tropo object and give it a prompt to say.
            tropo.say("Hello World!");

            // Render the JSON for Tropo to consume.
            Response.Write(TropoJSON.render(tropo));
		}
	}
}
