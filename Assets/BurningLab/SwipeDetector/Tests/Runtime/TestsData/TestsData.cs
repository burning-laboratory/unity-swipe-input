using BurningLab.SwipeDetector.Types;
using UnityEngine;

namespace SwipeDetector.RuntimeTests.BurningLab.SwipeDetector.Tests.Runtime.TestsData
{
    /// <summary>
    /// Tests data.
    /// </summary>
    public static class TestsData
    {
        #region Swipe Detection Tests Data
        
        /// <summary>
        /// Swipe up tests data.
        /// </summary>
        public static readonly SwipeData SwipeUpData = new SwipeData
        {
            positionStart = new Vector2(1267.8f, 246.8f),
            positionEnd = new Vector2(1267.8f, 431.9f)
        };
        
        /// <summary>
        /// Swipe right tests data.
        /// </summary>
        public static readonly SwipeData SwipeRightData = new SwipeData
        {
            positionStart = new Vector2(1256.6f, 573.5f),
            positionEnd = new Vector2(1415.6f, 682.9f)
        };
        
        /// <summary>
        /// Swipe down tests data.
        /// </summary>
        public static readonly SwipeData SwipeDownData = new SwipeData
        {
            positionStart = new Vector2(1400f, 779.2f),
            positionEnd = new Vector2(1418.7f, 598.4f)
        };
        
        /// <summary>
        /// Swipe left tests data.
        /// </summary>
        public static readonly SwipeData SwipeLeftData = new SwipeData
        {
            positionStart = new Vector2(2216.6f, 342.9f),
            positionEnd = new Vector2(1919.7f, 317.9f)
        };

        #endregion

        #region Swipe Distance Tests Data
        
        /// <summary>
        /// Short minimal swipe distance.
        /// </summary>
        public static readonly float ShortSwipeDistance = 50;
        
        /// <summary>
        /// Long minimal swipe distance.
        /// </summary>
        public static readonly float LongSwipeDistance = 500;

        #endregion
        
    }
}