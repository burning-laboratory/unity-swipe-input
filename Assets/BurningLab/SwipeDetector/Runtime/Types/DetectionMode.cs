namespace BurningLab.SwipeDetector.Types
{
    /// <summary>
    /// Swipe detection mode enumeration.
    /// </summary>
    public enum DetectionMode
    {
        /// <summary>
        /// Completed swipe detection mode. Wait finger release.
        /// </summary>
        Completed = 0,
            
        /// <summary>
        /// Uncompleted swipe detection mode. No wait finger release.
        /// </summary>
        Uncompleted = 1
    }
}