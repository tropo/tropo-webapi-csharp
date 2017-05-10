using System;
using System.IO;
using System.Web.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TropoCSharp.Tropo;
using System.Web;
using System.Collections.Generic;

namespace TropoSamples
{
    /// <summary>
    /// An example of how to receive and process the Tropo Result object.
    /// </summary>
    public partial class TropoResult : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {               
                // Get the JSON submitted from Tropo. 
                string resultJSON = TropoUtilities.parseJSON(reader);
                Console.WriteLine("resultJSONis:" + resultJSON);
                HttpContext.Current.Trace.Warn(DateTime.Now.ToString() + " I Made It HerresultJSONis" + resultJSON);

                // Create a new instance of the Tropo class.
                Tropo tropo = new Tropo();

                try
                {
                    // Create a new Result object and pass in the JSON submitted from Tropo.
                    Result tropoResult = Result.getResult(resultJSON);

                    // Get Actions container and parse.
                    List<TropoCSharp.Tropo.Action> Actions = tropoResult.Actions;

                    tropo.Say("session id is beijing " + tropoResult.SessionId);

                    foreach (TropoCSharp.Tropo.Action item in Actions)
                    {
                        tropo.Say("action Name is: " + item.Name);
                        tropo.Say("attempts is " + item.Attempts);
                        tropo.Say("disposition is " + item.Disposition);
                        tropo.Say("ConnectedDuration is " + item.ConnectedDuration);
                        tropo.Say("Duration is " + item.Duration);
                        tropo.Say("confidence is " + item.Confidence);
                        tropo.Say("interpretation is " + item.Interpretation);
                        tropo.Say("utterance is " + item.Utterance);
                        tropo.Say("value is " + item.Value);
                        tropo.Say("concept is: " + item.Concept);
                        //tropo.Say("xml is " + item.xml);
                        tropo.Say("uploadStatus is " + item.UploadStatus);
                        tropo.Say("inner user type is " + item.UserType);
                    }
                    tropo.Say("user type is " + tropoResult.UserType);
                }

                catch (JsonReaderException)
                {
                    tropo.Say("Sorry, an error occured. I choked on some JSON");
                }

                catch (Exception ex)
                {
                    tropo.Say("Sorry, an error occured. " + ex.Message);
                }

                finally
                {
                    tropo.RenderJSON(Response);
                }
            }
        }
    }
}
