using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cocbasebuilder.BaseGrabber;
using cocbasebuilder.BaseGrabber.Interface;
using cocbasebuilder.Model;
using System.Collections.Generic;

namespace cocbasebuilder.UnitTest.BaseGrabberTests
{
    [TestClass]
    public class coctoolsTests
    {
        [TestMethod]
        public void TestSmallBase()
        {
            string url = "Builder#5aa-...-g-a17";
            List<Building> expectedResult = new List<Building>();
            #region prepare result
            expectedResult.Add(new Building
            {
                Damage = 0,
                Health = 0,
                Height = 0,
                Left = 1,
                MaxRange = 0,
                MinRange = 0,
                Name = "cannon",
                Top = 1,
                Width = 0
            });

            #endregion

            IBaseGrabber bg = new BaseGrabber.coctools.BaseGrabber(url);
            var actualResult = bg.ParseData();

            CollectionAssert.AreEqual(expectedResult, actualResult);
            
        }

    }
}
