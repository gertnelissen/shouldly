#if net40
using System;
using System.Threading;
using System.Threading.Tasks;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldNotThrow
{
    public class TaskOfTScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            var task = Task.Factory.StartNew<string>(() => { throw new RankException(); },
                CancellationToken.None, TaskCreationOptions.None,
                TaskScheduler.Default);

            task.ShouldNotThrow("Some additional context");
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return "Task `task` should not throw but threw System.RankException with message \"Attempted to operate on an array with the incorrect number of dimensions.\"" +
                        " Additional Info:" +
                        " Some additional context";
            }
        }

        protected override void ShouldPass()
        {
            var task = Task.Factory.StartNew(() => "foo",
                CancellationToken.None, TaskCreationOptions.None,
                TaskScheduler.Default);

            var result = task.ShouldNotThrow();
            result.ShouldBe("foo");
        }
    }
}
#endif