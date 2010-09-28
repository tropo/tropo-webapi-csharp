using System;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    public partial class GetZipCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object
            Tropo tropo = new Tropo();
            
            // Set the grammar to use when collecting input.
            Choices choices = new Choices("[5 DIGITS]");
            
            // Create an event handler for when the input collection is finished.
            On on = new On(Event.@continue, "http://thisisafakeurl.com/post", new Say("Please hold."));

            // Call the ask method of the Tropo object and pass in values. 
            tropo.ask(3, false, choices, null, "zip", true, new Say("Please enter your 5 digit zip code"), 5);
            tropo.on(on);

            // Render the JSON for Tropo to consume.
            Response.Write(TropoJSON.render(tropo));
        }
    }
}
