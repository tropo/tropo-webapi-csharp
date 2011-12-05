using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TropoCSharp.Tropo;

namespace TropoCollectDigits
{
    public partial class Error : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Play an error message to the caller.
            tropo.Say("I'm sorry, there was an error. Please try you call again later.");

            // End the current session.
            tropo.Hangup();

            // Render JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
