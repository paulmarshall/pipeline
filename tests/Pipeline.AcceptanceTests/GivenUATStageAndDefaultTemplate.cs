using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace Pipeline.AcceptanceTests
{
    [TestFixture, Ignore("UAT Stage not supported yet")]
    public class GivenUATStageAndDefaultTemplate : BaseDefaultTemplateTest
    {
        [TestFixtureSetUp]
        public void WhenBuildIsRun()
        {
            // Arrange
            var stage = "UAT";

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
