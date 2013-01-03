using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace Pipeline.AcceptanceTests
{
    [TestFixture]
    public class GivenNoStageAndDefaultTemplate : BaseDefaultTemplateTest
    {
        [TestFixtureSetUp]
        public void WhenBuildIsRun()
        {
            // Arrange
            var stage = string.Empty;

            // Act
            output = RunPipelineBuildFile(stage);
        }

        [Test]
        public void ThenPipelineShowsError()
        {
            AssertOutputIsFailure("No stage specified");
        }
    }
}
