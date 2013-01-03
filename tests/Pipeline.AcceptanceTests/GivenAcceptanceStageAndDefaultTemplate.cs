using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace Pipeline.AcceptanceTests
{
    [TestFixture]
    public class GivenAcceptanceStageAndDefaultTemplate : BaseDefaultTemplateTest
    {
        [TestFixtureSetUp]
        public void WhenBuildIsRun()
        {
            // Arrange
            var stage = "Acceptance";

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
                "ConfigureEnvironment",
                "DeployPackage",
                "SmokeTest",
                "AcceptanceTest"
            };

            AssertPipelineTargets(targets);
        }
    }
}
