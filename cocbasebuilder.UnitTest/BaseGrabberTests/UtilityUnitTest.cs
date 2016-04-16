using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cocbasebuilder.BaseGrabber;

namespace cocbasebuilder.UnitTest.BaseGrabberTests
{
    [TestClass]
    public class UtilityUnitTest
    {
        [TestMethod]
        public void TestExpand1()
        {
            string input = "a2"; //ab2c3defg3
            string expectedOutput = "aaa"; //abbbccccdefgggg
            string actualOutput = string.Empty;

            actualOutput = Utility.Expand(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }


        [TestMethod]
        public void TestExpand2()
        {
            string input = "ab2c3defg3"; //
            string expectedOutput = "abbbccccdefgggg"; //
            string actualOutput = string.Empty;

            actualOutput = Utility.Expand(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestGetHash1()
        {
            string input = "123#abc#123";
            string expectedOutput = "abc#123";
            string actualOutput = string.Empty;

            actualOutput = Utility.GetHashTag(input);

            Assert.AreEqual(expectedOutput, actualOutput);



        }

        [TestMethod]
        public void TestGetHash2()
        {
            string input = "123abc123";
            string expectedOutput = null;
            string actualOutput = string.Empty;

            actualOutput = Utility.GetHashTag(input);

            Assert.AreEqual(expectedOutput, actualOutput);



        }
    }
}
