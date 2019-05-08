using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolylineAlgorithmEncodeDecoder;

namespace PolylineAlgorithmEncodeDecoderTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestEncode()
        {
            List<CoordinateEntity> points = new List<CoordinateEntity>();
            points.Add(new CoordinateEntity(38.5, -120.2));
            points.Add(new CoordinateEntity(40.7, -120.95));
            points.Add(new CoordinateEntity(43.252, -126.453));

            string result = PolylineAlgoritm.Encode(points);
            System.Console.WriteLine(result);
            Assert.IsTrue(result == "_p~iF~ps|U_ulLnnqC_mqNvxq`@", @"convertion incorrect");
        }

        [TestMethod]
        public void TestDecode()
        {
            List<CoordinateEntity> points_to_control = new List<CoordinateEntity>();
            points_to_control.Add(new CoordinateEntity(38.5, -120.2));
            points_to_control.Add(new CoordinateEntity(40.7, -120.95));
            points_to_control.Add(new CoordinateEntity(43.252, -126.453));

            IEnumerable<CoordinateEntity> points = PolylineAlgoritm.Decode(@"_p~iF~ps|U_ulLnnqC_mqNvxq`@");

            int lineNumber = 0;
            foreach(CoordinateEntity point in points)
            {
                Assert.IsTrue((point.Latitude == points_to_control[lineNumber].Latitude) && (point.Longitude == points_to_control[lineNumber].Longitude), @"convertion incorrect. Wrong first lat and lon.");               
                lineNumber++;
            }
        }
    }
}
