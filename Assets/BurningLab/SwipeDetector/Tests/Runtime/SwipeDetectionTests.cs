using BurningLab.SwipeDetector.Types;
using BurningLab.SwipeDetector.Utils;
using NUnit.Framework;
using SwipeDetector.RuntimeTests.BurningLab.SwipeDetector.Tests.Runtime.TestsData;

namespace SwipeDetector.RuntimeTests
{
    /// <summary>
    /// Swipe direction detection tests.
    /// </summary>
    public class SwipeDetectionTests
    {
        /// <summary>
        /// Try detect up swipe.
        /// </summary>
        [Test]
        public void SwipeUpDetectionTest()
        {
            SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(TestsData.SwipeUpData);
            Assert.True(swipeDirection == SwipeDirection.Up);
        }
        
        /// <summary>
        /// Try detect right swipe.
        /// </summary>
        [Test]
        public void SwipeRightDetectionTest()
        {
            SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(TestsData.SwipeRightData);
            Assert.True(swipeDirection == SwipeDirection.Right);
        }
        
        /// <summary>
        /// Try detect down swipe.
        /// </summary>
        [Test]
        public void SwipeDownDetectionTest()
        {
            SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(TestsData.SwipeDownData);
            Assert.True(swipeDirection == SwipeDirection.Down);
        }
        
        /// <summary>
        /// Try detect left swipe.
        /// </summary>
        [Test]
        public void SwipeLeftDetectionTest()
        {
            SwipeDirection swipeDirection = SwipeDetectionUtils.ComputeSwipeDirection(TestsData.SwipeLeftData);
            Assert.True(swipeDirection == SwipeDirection.Left);
        }
    }
}
