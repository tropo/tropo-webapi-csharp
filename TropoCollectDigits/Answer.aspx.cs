using System;
using System.IO;
using System.Web.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TropoCSharp.Tropo;

namespace TropoCollectDigits
{
    public partial class Answer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                // Get the JSON submitted from Tropo. 
                string resultJSON = TropoUtilities.parseJSON(reader);

                // Create a new instance of the Tropo object.
                Tropo tropo = new Tropo();

                try
                {

                    // Create a new Result object and pass in the JSON submitted from Tropo.
                    Result tropoResult = new Result(resultJSON);

                    // Parse the Actions object and get the value property.
                    JContainer Actions = TropoUtilities.parseActions(tropoResult.Actions);

                    // Get the input submited by the user.
                    // This value can be used to query a database, hit a web service, etc.
                    // In the example, we'll simply read the number back to the caller.
                    string answer = TropoUtilities.removeQuotes(Actions["value"].ToString());
                    tropo.Say("You entered, " + TropoUtilities.addSpaces(answer) + ". Goodbye");

                }

                // In the event of an error in rendering the page, play an error message to the caller.
                catch (JsonReaderException ex)
                {
                    tropo.Say("An error occured. " + ex.Message);
                }

                catch (Exception ex)
                {
                    tropo.Say("An error occured. " + ex.Message);
                }

                finally
                {
                    // Render JSON for Tropo to consume.
                    tropo.Hangup();
                    Response.Write(tropo.RenderJSON());

                }
            }
        }
    }
}
