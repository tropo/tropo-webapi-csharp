using System;
using System.Web;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
    /// 
	/// </summary>
    public partial class OnExample1 : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            
            On on_incomplete1 = new On();
            on_incomplete1.Event = Event.Incomplete;
            on_incomplete1.Say = new Say("this is incomplete 1");
            tropo.On(on_incomplete1);

            On on_incomplete2 = new On();
            on_incomplete2.Event = Event.Incomplete;
            on_incomplete2.Say = new Say("this is incomplete 2");
            tropo.On(on_incomplete2);

            On on_incomplete = new On();
            on_incomplete.Event = Event.Incomplete;
            on_incomplete.Next = "OnExample1Incomplete.aspx";
            tropo.On(on_incomplete);

            On on_incomplete3 = new On();
            on_incomplete3.Event = Event.Incomplete;
            on_incomplete3.Say = new Say("this is incomplete 3");
            tropo.On(on_incomplete3);

            On on_continue = new On();
            on_continue.Event = Event.Continue;
            on_continue.Next = "OnExample1Continue.aspx";
            //tropo.On(on_continue);

            On on_error = new On();
            on_error.Event = Event.Error;
            on_error.Next = "OnExample1Error.aspx";
            tropo.On(on_error);

            On on_hangup = new On();
            on_hangup.Event = Event.Hangup;
            on_hangup.Next = "OnExample1Hangup.aspx";
            tropo.On(on_hangup);


            Ask ask = new Ask();
            ask.Say = new TropoCSharp.Tropo.Say("Welcome to Tropo.  What's your birth year?");
            ask.Name = "year";
            ask.Required = true;
            ask.Choices = new Choices("[4 DIGITS]");
            tropo.Ask(ask);
            HttpContext.Current.Trace.Warn("tropo.RenderJSON() is " + tropo.RenderJSON());

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
		}
	}
}
