﻿using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeNegative
{
    public class ZeroIntWithFunctionContextScenario : ShouldlyShouldFailureTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
           0.ShouldBeNegative(() => "Some additional context");
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get {
                return "0 was 0 and should be negative but wasn't" +
                       "Additional Info: " +
                       "Some additional context";
            }
        }
    }
}