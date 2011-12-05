using System;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// An example showing how to collect input from a caller.
    /// </summary>
    public partial class GetZipCode : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object
            Tropo tropo = new Tropo();
            
            // Set the grammar to use when collecting input.
            Choices choices = new Choices("[5 DIGITS]");
            
            // Create an event handler for when the input collection is finished. Tropo will POST Result object JSON.
            On on = new On(Event.Continue, "http://my-web-application-url/post", new Say("Please hold."));

            // Call the ask method of the Tropo object and pass in values. 
            tropo.Ask(3, false, choices, null, "zip", true, new Say("Please enter your 5 digit zip code"), 5);
            tropo.On(on);

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
