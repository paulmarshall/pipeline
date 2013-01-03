﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace Pipeline.AcceptanceTests
{
    [TestFixture]
    public class GivenQAStageAndDefaultTemplate : BaseDefaultTemplateTest
    {
        [TestFixtureSetUp]
        public void WhenBuildIsRun()
        {
            // Arrange
            var stage = "QA";

            // Act
            output = RunPipelineBuildFile(stage);
        }

        [Test]
        public void ThenPipelineRunsSuccessfully()
        {
            AssertOutputIsSuccessful();
        }

        [Test]
        public void ThenPipelineRunsRequiredTargets()
        {
            var targets = new List<string>
            {
                "GetPackageToDeploy",
                "ConfigureEnvironment",
                "DeployPackage",
                "SmokeTest"
            };

            AssertPipelineTargets(targets);
        }
    }
}
