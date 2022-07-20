using UnityEngine;

namespace BurningLab.SwipeDetector.Types
{
    /// <summary>
    /// Swipe data structure.
    /// </summary>
    public struct SwipeData
    {
        /// <summary>
        /// Swipe position start.
        /// </summary>
        public Vector2 positionStart;
        
        /// <summary>
        /// Swipe position end.
        /// </summary>
        public Vector2 positionEnd;
        
        /// <summary>
        /// Reset swipe data.
        /// </summary>
        public void Reset()
        {
            positionStart = Vector2.zero;
            positionEnd = Vector2.zero;
        }
    }
}