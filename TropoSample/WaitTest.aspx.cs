using System;
using System.IO;
using System.Web;
using System.Web.UI;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how to say Hello World to a user.
	/// </summary>
    public partial class WaitTest : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{
            // Create a new instance of the Tropo class.
            Tropo tropo = new Tropo();

            // A prompt to use with the Ask.On.
            Say sayon = new Say("This is an wait test on say");

            // Call the say method of the Tropo object and give it a prompt to say.
            tropo.Say("Connected!");
            tropo.Say("Fourscore and seven years ago our fathers brought forth, on this continent, a new nation, conceived in liberty, and dedicated to the proposition that all men are created equal. Now we are engaged in a great civil war, testing whether that nation, or any nation so conceived, and so dedicated, can long endure. We are met on a great battle-field of that war. We have come to dedicate a portion of that field, as a final resting-place for those who here gave their lives, that that nation might live. It is altogether fitting and proper that we should do this. But, in a larger sense, we cannot dedicate, we cannot consecrate謡e cannot hallow葉his ground. The brave men, living and dead, who struggled here, have consecrated it far above our poor power to add or detract. ", new string[] { "e3eeexit" }, "DATE", "say1", null);
            //tropo.Say("3642854534 ", new string[] { "exit" }, "TIME", "say1", null);
            tropo.Say("The world will little note, nor long remember what we say here, but it can never forget what they did here. It is for us the living, rather, to be dedicated here to the unfinished work which they who fought here have thus far so nobly advanced. It is rather for us to be here dedicated to the great task remaining before us葉hat from these honored dead we take increased devotion to that cause for which they here gave the last full measure of devotion葉hat we here highly resolve that these dead shall not have died in vain葉hat this nation, under God, shall have a new birth of freedom, and that government of the people, by the people, for the people, shall not perish from the earth.");
            //tropo.Wait(33333, new string[] { "exit" });
            tropo.Say("Bye!");

            tropo.On("continue", "TropoResult.aspx", sayon);

            HttpContext.Current.Trace.Warn("tropo.RenderJSON() is " + tropo.RenderJSON());

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
		}
	}
}
