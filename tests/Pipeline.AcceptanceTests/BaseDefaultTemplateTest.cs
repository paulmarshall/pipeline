using System;
using System.Diagnostics;
using NUnit.Framework;
using System.Collections.Generic;

namespace Pipeline.AcceptanceTests
{
    public abstract class BaseDefaultTemplateTest
    {
        protected string output;

        protected void AssertOutputIsSuccessful()
        {
            Assert.IsFalse(output.Contains("Build FAILED"));
        }

        protected void AssertOutputIsFailure(string message)
        {
            Assert.IsTrue(output.Contains(message),"Message not present");
            Assert.IsTrue(output.Contains("Build FAILED"),"Failed message not present");
        }

        protected void AssertPipelineTargets(IEnumerable<string> expectedTargets)
        {
            var expectedTargetsExtendedWithBeginCoreAndAfter = new List<string>();

            var beginCoreAndAfter = new List<string>
            {
                "Before",
                "Core",
                "After"
            };

            foreach (var target in expectedTargets)
            {
                beginCoreAndAfter.ForEach(x=>expectedTargetsExtendedWithBeginCoreAndAfter.Add(x + target));
                expectedTargetsExtendedWithBeginCoreAndAfter.Add(target);
            }

            foreach (var target in expectedTargetsExtendedWithBeginCoreAndAfter)
            {
                Assert.IsTrue(output.Contains(target), target);
            }
        }

        protected string RunPipelineBuildFile(string stage)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Arguments = string.Format(string.IsNullOrEmpty(stage) ? @"/nologo build.xml" : @"/nologo build.xml /t:{0}", stage);

            p.Start();

            var output = p.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            return output;
        }
    }
}
