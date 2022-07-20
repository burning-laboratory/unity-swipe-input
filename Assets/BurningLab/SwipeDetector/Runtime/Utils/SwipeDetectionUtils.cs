using BurningLab.SwipeDetector.Types;
using UnityEngine;

namespace BurningLab.SwipeDetector.Utils
{
    /// <summary>
    /// Utils for swipe detection system.
    /// </summary>
    public static class SwipeDetectionUtils
    {
        /// <summary>
        /// Compute swipe direction.
        /// </summary>
        /// <param name="swipe">Swipe data.</param>
        /// <returns>Computed swipe direction.</returns>
        public static SwipeDirection ComputeSwipeDirection(SwipeData swipe)
        {
            Vector2 delta = swipe.positionStart - swipe.positionEnd;
            
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                if (delta.x < 0)
                {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                    UnityConsole.PrintLog("SwipeDetectionUtils", "ComputeSwipeDirection","Swipe right detected");   
#endif
                    return SwipeDirection.Right;
                }
                else
                {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                    UnityConsole.PrintLog("SwipeDetectionUtils", "ComputeSwipeDirection","Swipe left detected.");   
#endif
                    return SwipeDirection.Left;
                }
            }
            else
            {
                if (delta.y < 0)
                {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                    UnityConsole.PrintLog("SwipeDetectionUtils", "ComputeSwipeDirection","Swipe up detected.");
#endif
                    return SwipeDirection.Up;
                }
                else
                {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SWIPE_DETECTOR
                    UnityConsole.PrintLog("SwipeDetectionUtils", "ComputeSwipeDirection","Swipe down detected.");
#endif
                    return SwipeDirection.Down;
                }
            }
        }
        
        /// <summary>
        /// Check swipe a long minimal swipe distance.
        /// </summary>
        /// <param name="swipe">Swipe data.</param>
        /// <param name="minSwipeDistance">Minimal swipe distance.</param>
        /// <returns>True if swipe a longer minimal distance. False if swipe shorter minimal distance.</returns>
        public static bool IsSwipeALongMinDistance(SwipeData swipe, float minSwipeDistance)
        {
            Vector2 delta = swipe.positionStart - swipe.positionEnd;
            return Mathf.Abs(delta.magnitude) > minSwipeDistance;
        }
    }
}