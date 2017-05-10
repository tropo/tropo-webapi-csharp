using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how use redirect.
	/// </summary>
    public partial class RedirectTest : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                Tropo tropo = new Tropo();

                try
                {
                    IEnumerable<string> redirect2 = new string[] { "sip:9995844724@10.140.254.62" };
                    IEnumerable<string> redirect1 = new string[] { "sip:9996254688@10.140.254.62:5678" };
                    IEnumerable<string> redirectfrank = new string[] { "sip:frank@172.16.22.128:5678" };
                    string too = "sip:frank@172.16.22.128:5678";    // in my test, X-Lite client did not success
                    string too2 = "sip:9995844724@10.140.254.62:5678";  // use another application success
                    tropo.Redirect(too2, "redirectwindows", null);

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
