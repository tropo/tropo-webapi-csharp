Conference Call Example
=======================

This WebAPI conference example has three components.

1. The conference dialog. This is the JSON dialog that holds instructions for Tropo to create the conference. You can use the CreateConference.aspx sample in the TropoSamples directory for this.
2. The Program.cs console application.
3. A very simple JavaScript file containing a prompt to play to the conference attendees.

How does it work?
-----------------

* Create a new Tropo WebAPI app and use the URL to the conference dialog (#1) above as the start URL for the application.
* When your application is created, copy the Voice Token string and paste the value into the Program.cs file (assign it to the variable called 'token').
* Create a new Tropo scripting application, and create a new JavaScript file for this app with the following contents:

	say('There are 5 minutes left in the conference'); // Content can be tailored as needed.
	
* Copy the Tropo SIP address assigned to this application into the Program.cs file (assign it to the variable called 'conferenceTimer').
* Modify the phone numbers to use in the conference by editing the Program.cs file.
* Launh the Program.cs file (F5).