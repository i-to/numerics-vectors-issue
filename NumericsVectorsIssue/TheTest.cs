﻿using FluentAssertions;
using NUnit.Framework;

namespace StandaloneReproduction
{
    [TestFixture]
    public class TheTest
    {
        // To make sure the issue reproduces:
        //  1. Run the test in Release configuration.
        //  2. The test will fail, complaining that the actual value is below the expected threshold of 0.9.
        //  3. Run the test in Debug configuration. The test will pass.

        // To debug the issue:
        //  1. Uncomment the while loop below.
        //  2. Run the unit test.
        //  3. Place a breakpoint somewhere in the code below.
        //  4. Attach the debugger to a test runner process. Once the debugger is attached, the while loop will break
        // and the breakpoint will be triggered.

        [Test]
        public void ExecuteStandaloneReproduction()
        {
            // while (!Debugger.IsAttached) ;

            var reproduction_sequence = new ReproductionSequence();
            var length = reproduction_sequence.GetLengthOfTheNormalizedVector();
            length.Should().BeGreaterThan((float) 0.9);
            length.Should().BeLessThan((float) 1.1);
        }
    }
}
