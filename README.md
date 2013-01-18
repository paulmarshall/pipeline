Pipeline is a simple, convention-based framework for building deployment pipelines for .NET/MSBuild.

Quick Start
-----------
1. Git clone this repository
2. Run Visual Studio Command Prompt (navigate to your local repository)
3. Run the following command:

		msbuild build.xml /t:Local

4. This generates the following output:

		Microsoft (R) Build Engine version 4.0.30319.17379
		[Microsoft .NET Framework, version 4.0.30319.17379]
		Copyright (C) Microsoft Corporation. All rights reserved.

		Build started 12/06/2012 22:24:05.
		Project "C:\Users\Paul\Documents\GitHub\pipeline\build.xml" on node 1 (Local target(s)).
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
		Done Building Project "C:\Users\Paul\Documents\GitHub\pipeline\build.xml" (Local target(s)).

		Build succeeded.
		    0 Warning(s)
		    0 Error(s)

		Time Elapsed 00:00:01.23

Concept
-------
This work is heavily influenced by the ideas and concepts from the book ["Continuous Delivery"](http://www.amazon.co.uk/Continuous-Delivery-Deployment-Automation-Addison-Wesley/dp/0321601912#) by Jez Humble and David Farley.

This book describes "an effective pattern for getting software from development to release". 

The pattern central to the book is the "deployment pipeline", an automated implementation of an application's build, deploy, test and release process.

Overview
--------

Implementation
--------
The Pipeline framework is built upon MSBuild v4.0 and is comprised of the following files:

* Core
	* pipeline.xml
		Defines core concepts of steps in a deployment pipeline
* Pipeline templates
	* pipeline.template.default.xml
		Provides an example deployment pipeline
* Pipeline plugins
	* pipeline.plugin.version.xml
		Reads version information from an XML file
	* pipeline.plugin.nunit.xml
		Runs nunit tests
	* pipeline.plugin.nunit.config.xml
		Implements an inline task to update
* Sample project build file
	* build.xml
* Sample version file (for use with pipeline.plugin.version.xml)
	* version.xml

Because the framework using MSBuild, many of the aspects are open for extension.

History
-------
This framework was built to provide a build, test and deployment framework for a client. The client had SVN for a SCM and Hudson as a CI server.

Jobs were created in Hudson to represent each stage in the pipeline. The Commit job monitored changes to a SVN repository. When a change was detected, the job ran a MSBuild action that loaded build.xml, and calling the "Commit" target. The output of this job was an artifact. In addition, the job triggered the Acceptance job.

The Acceptance job retrieved the "last stable" artifact from the Commit job and once again ran a MSBuild action that loaded build.xml but this time calling the Acceptance target.

How to use this framework
-------------------------
Clone this git repository and "override" targets in the pipeline framework to perform custom steps to meet your requirements.

External Libraries Used
-----------------------
[MSBuildTasks] (https://github.com/loresoft/msbuildtasks)

Support
-------
Check out the [wiki](https://github.com/paulmarshall/pipeline/wiki)

Contributors
------------
 - [paulmarshall](https://github.com/paulmarshall) (Paul Marshall)
 - Prashant Tyagi