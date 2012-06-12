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

Framework
---------
* All pipeline files are MSBuild v4.0 compatible project files
* **build.xml** defines your "package specific" build, test and release processes
* **pipeline.xml** (imported by build.xml) defines the "teams" general build, test and release processes
* **pipeline.template.default.xml** (imported by pipeline.xml) defines a general purpose template of build, test and release processes
* **pipeline.core.xml** (imported by pipeline.template.default.xml) defines the core pipeline stages and steps

The example pipeline given in pipeline.template.default.xml, recognises the following stages:
* Local
* Commit
* Acceptance
* QA (Quality Assurance)
* UAT (User Acceptance Testing)
* Production

Usage Scenarios
---------------

## Commit Build
A CI (Continuous Integration) Tool is configured to run a Commit job.

The Commit job:
* Polls a source repository for changes
* Job triggered when a change in the source is detected
* When a change is detected:
	* The "workspace" for the job is emptied
	* The source is fetched from the repository into the workspace
	* The job runs MSBuild with the following arguments

			msbuild build.xml /t:Commit
			
	* The job reports on the outcome of msbuild
	* The job zips the output of the Commit job (the "Artefact")
	* The job copies the Artefact to the "Artefact Repository"
	* The job automatically runs the Acceptance job

## Acceptance Build
A CI (Continuous Integration) Tool is configured to run an Acceptance job.

The Acceptance job:
* Is triggered by an "upstream" Commit job
* When triggered:
	* The job empties the "workspace" for the job
	* The job fetches the source from the repository associated with the Commit job (this retrieves the pipeline files)
	* The job retrives the artefact from the "last stable build" of the associated Commit job
	* The job runs MSBuild with the following arguments

			msbuild build.xml /t:Acceptance

	* The job reports on the outcome of msbuild

Contributors
------------
 - [paulmarshall](https://github.com/paulmarshall) (Paul Marshall)
 - Prashant Tyagi