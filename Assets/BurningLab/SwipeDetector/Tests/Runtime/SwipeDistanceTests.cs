using BurningLab.SwipeDetector.Utils;
using NUnit.Framework;
using SwipeDetector.RuntimeTests.BurningLab.SwipeDetector.Tests.Runtime.TestsData;

namespace SwipeDetector.RuntimeTests
{
    /// <summary>
    /// Swipe lenght tests.
    /// </summary>
    public class SwipeDistanceTests
    {
        /// <summary>
        /// Try check a short swipe.
        /// </summary>
        [Test]
        public void ShortSwipeDistanceTest()
        {
            bool result = SwipeDetectionUtils.IsSwipeALongMinDistance(TestsData.SwipeUpData, TestsData.LongSwipeDistance);
            Assert.False(result);
        }
        
        /// <summary>
        /// Try check a long swipe.
        /// </summary>
        [Test]
        public void LongSwipeDistanceTest()
        {
            bool result = SwipeDetectionUtils.IsSwipeALongMinDistance(TestsData.SwipeUpData, TestsData.ShortSwipeDistance);
            Assert.True(result);
        }
    }
}
