Overview
========

TropoCSharp is a set of C# classes for working with the [Tropo cloud communication service](http://tropo.com/). Tropo allows a developer to create applications that run over the phone, IM, SMS, and Twitter using web technologies. This library communicates with Tropo over JSON.

Usage
=====

Download the latest version of Json.NET from http://json.codeplex.com/

Extract the following two files from this download:

Bin\DotNet\Newtonsoft.Json.dll
Bin\DotNet\Newtonsoft.Json

To the following directories (Each project in the TropoCSharp solution uses these files):
<pre>
TropoCSharp\TropoClassesTests\bin\Debug
TropoCSharp\TropoCSharp\bin\Debug
TropoCSharp\TropoSample\bin
</pre>
You may also set up references to a common location where these files reside (e.g., in the GAC). You may also designate an alternate build location for assemblies in this solution and place these files there.  The choice is yours.

Build the solution.

You can test samples in the TropoSamples solution by viewing them in a web browser, or via HTTP POST (which is how the Tropo WebAPI interacts with web applications).

Tests for various Tropo action classes are in the TropoClassesTests soltuon.

Project with samples (ASP.NET web application) will use a directory called TropoSample (e.g., http://localhost/TropoSample)

Example
=======

<pre>
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
            tropo.say("Hello, World!");

            // Render the JSON for Tropo to consume.
            Response.Write(TropoJSON.render(tropo));
		}
	}
}
</pre>
