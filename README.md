Pipeline is a simple, convention-based framework for building deployment pipelines for .NET/MSBuild.

Quick Start
-------
1. Git clone this repository
2. Run Visual Studio Command Prompt (navigate to your local repository)
3. Run the following command

		msbuild build.xml /t:Local
4. This generates the following output:

		Microsoft (R) Build Engine version 4.0.30319.17379
		[Microsoft .NET Framework, version 4.0.30319.17379]
		Copyright (C) Microsoft Corporation. All rights reserved.

		Build started 12/06/2012 21:59:05.
		Project "D:\Projects\Wavecrest\git\pipeline\src\build.xml" on node 1 (Local target(s)).
		SetPipelineStageToLocal:
		  SetPipelineStageToLocal
		GetVersionFromFile:
		  GetVersionFromFile (pipeline.plugin.version)
		  Reading Xml Document "version.xml".
		    1 node(s) selected for read.
		  XmlRead Result: "1"
		  Reading Xml Document "version.xml".
		    1 node(s) selected for read.
		  XmlRead Result: "0"
		  Reading Xml Document "version.xml".
		    1 node(s) selected for read.
		  XmlRead Result: "0"
		BeforeBuild:
		  BeforeBuild (pipeline.plugin.version)
		CoreBuild:
		  CoreBuild
		AfterBuild:
		  AfterBuild
		Build:
		  Build
		BeforeUnitTest:
		  BeforeUnitTest
		RunUnitTest:
		  RunUnitTest (pipeline.plugin.nunit)
		CoreUnitTest:
		  CoreUnitTest (pipeline.plugin.nunit)
		AfterUnitTest:
		  AfterUnitTest
		UnitTest:
		  UnitTest
		BeforePackage:
		  BeforePackage
		CorePackage:
		  CorePackage
		AfterPackage:
		  AfterPackage
		Package:
		  Package
		BeforeConfigureEnvironment:
		  BeforeConfigureEnvironment
		CoreConfigureEnvironment:
		  CoreConfigureEnvironment
		AfterConfigureEnvironment:
		  AfterConfigureEnvironment
		ConfigureEnvironment:
		  ConfigureEnvironment
		BeforeDeployPackage:
		  BeforeDeployPackage
		CoreDeployPackage:
		  CoreDeployPackage
		AfterDeployPackage:
		  AfterDeployPackage
		DeployPackage:
		  DeployPackage
		UpdateSmokeTestConfiguration:
		  UpdateSmokeTestConfiguration (pipeline.plugin.nunit)
		BeforeSmokeTest:
		  BeforeSmokeTest (pipeline.plugin.nunit)
		CoreSmokeTest:
		  CoreSmokeTest
		AfterSmokeTest:
		  AfterSmokeTest
		SmokeTest:
		  SmokeTest
		Local:
		  Local
		Done Building Project "D:\Projects\Wavecrest\git\pipeline\src\build.xml" (Local target(s)).

		Build succeeded.
		    0 Warning(s)
		    0 Error(s)

		Time Elapsed 00:00:10.35


Concept
-------
This work is heavily influenced by the ideas and concepts from the book ["Continuous Delivery"](http://www.amazon.co.uk/Continuous-Delivery-Deployment-Automation-Addison-Wesley/dp/0321601912#) by Jez Humble and David Farley.

This book describes "an effective pattern for getting software from development to release". 

The pattern central to the book is the "deployment pipeline", an automated implementation of an application's build, deploy, test and release process.

Contributors
------------
 - [paulmarshall](https://github.com/paulmarshall) (Paul Marshall)
 - Prashant Tyagi