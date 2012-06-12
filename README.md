Pipeline is a simple, convention-based framework for building deployment pipelines for .NET/MSBuild.

To use:
* Git clone this repository
* Run Visual Studio Command Prompt (navigate to your local repository)
* Run the following command

		msbuild build.xml /t:Local



Concept
-------
This work is heavily influenced by the ideas and concepts from the book ["Continuous Delivery"](http://www.amazon.co.uk/Continuous-Delivery-Deployment-Automation-Addison-Wesley/dp/0321601912#) by Jez Humble and David Farley.

This book describes "an effective pattern for getting software from development to release". 

The pattern central to the book is the "deployment pipeline", an automated implementation of an application's build, deploy, test and release process.

Contributors
------------
 - [paulmarshall](https://github.com/paulmarshall) (Paul Marshall)
 - Prashant Tyagi