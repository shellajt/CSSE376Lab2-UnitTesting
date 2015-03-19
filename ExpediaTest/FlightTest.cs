using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime start = new DateTime(2015, 05, 18);
        private readonly DateTime end = new DateTime(2015, 05, 19);
        private readonly DateTime badStart = new DateTime(2015, 05, 20);

		[Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(start, end, 500);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatInvalidOperationExceptionIsThrown()
        {
            new Flight(badStart, end, 500);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTheArguementOutOfRangeExceptionIsThrown()
        {
            new Flight(start, end, -500);
        }

        [Test()]
        public void TestThatMilesIsSetCorrectly()
        {
            var target = new Flight(start, end, 500);
            Assert.AreEqual(500, target.Miles);
        }

        [Test()]
        public void TestBasePriceWith1Day()
        {
            var target = new Flight(start, end, 500);
            Assert.AreEqual(220, target.getBasePrice());

        }

        [Test()]
        public void TestBasePriceWith3Day()
        {
            var target = new Flight(start, new DateTime(2015, 05, 21), 500);
            Assert.AreEqual(260, target.getBasePrice());
        }

        [Test()]
        public void TestBasePriceWith5Day()
        {
            var target = new Flight(start, new DateTime(2015, 05, 23), 500);
            Assert.AreEqual(300, target.getBasePrice());
        }

        [Test()]
        public void TestBasePriceWith12Day()
        {
            var target = new Flight(start, new DateTime(2015, 05, 30), 500);
            Assert.AreEqual(440, target.getBasePrice());
        }
	}
}
