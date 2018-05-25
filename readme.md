[![NuGet version (tropo-webapi-csharp)](https://img.shields.io/nuget/v/tropo-webapi-csharp.svg?style=flat-square)](https://www.nuget.org/packages/tropo-webapi-csharp/)
[![NuGet version (tropo-webapi-csharp)](https://img.shields.io/nuget/dt/tropo-webapi-csharp.svg?style=flat-square)](https://www.nuget.org/packages/tropo-webapi-csharp/)
[![GitHub license](https://img.shields.io/github/license/tropo/tropo-webapi-csharp.svg?style=for-the-badge)](https://github.com/tropo/tropo-webapi-csharp/blob/master/LICENSE)



Overview
========

TropoCSharp is a set of C# classes for working with the [Tropo cloud communication service](http://tropo.com/). Tropo allows a developer to create applications that run over the phone, IM, SMS, and Twitter using web technologies. This library communicates with Tropo over JSON.

Usage
=====
Build the solution.  External references are managed through NuGet.

You can test samples in the TropoSamples solution by viewing them in a web browser, or via HTTP POST (which is how the Tropo WebAPI interacts with web applications).

Tests for various Tropo action classes are in the TropoClassesTests soltuon.

Project with samples (ASP.NET web application) will use a directory called TropoSample (e.g., http://localhost/TropoSample).

Example
======

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
            tropo.Say("Hello World!");

            tropo.RenderJSON(Response);
		}
	}
}
</pre>
