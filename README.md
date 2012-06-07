Pipeline
========

Pipeline is a simple, convention-based framework for building deployment pipelines for .NET/MSBuild.

Concept
-------
This work is heavily influenced by the ideas and concepts from the book ["Continuous Delivery"](http://www.amazon.co.uk/Continuous-Delivery-Deployment-Automation-Addison-Wesley/dp/0321601912#) by Jez Humble and David Farley.

This book describes "an effective pattern for getting software from development to release". 

The pattern central to the book is the "deployment pipeline", an automated implementation of an application's build, deploy, test and release process.

Design
------
# Framework
* The processes to automate the build, deploy, test and release an application are grouped into "stages". These stages form a "pipeline".
* A framework is to be provided to define the steps required at each stage of the pipeline.
* The framework enables teams to define specific implementations of each step whilst adhering to the coventions of the pipeline.
* The framework recognises the following key stages : Local, Commit and Acceptance.
* Teams may recognise additional stages in their own pipelines.

# Technologies
* XML
* .NET / C#
* MSBuild
* NUnit

Getting Started
---------------
TODO


Contributors
------------
 - [paulmarshall](https://github.com/paulmarshall) (Paul Marshall)
 - Prashant Tyagi