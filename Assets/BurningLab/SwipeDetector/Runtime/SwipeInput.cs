using UnityEngine;
using UnityEngine.Events;

namespace BurningLab.SwipeDetector
{
    [AddComponentMenu("Burning-Lab/Swipe Detector/Swipe Input")]
    public class SwipeInput : MonoBehaviour
    {
        [System.Serializable]
        private struct InputEvents
        {
            public UnityEvent<Vector2> swipeStart;
            public UnityEvent<Vector2> swipeEnd;
            public UnityEvent swipeUp;
            public UnityEvent swipeRight;
            public UnityEvent swipeDown;
            public UnityEvent swipeLeft;
        }
        
        private Vector2 _posIn;
        private Vector2 _posOut;

        [Header("Settings")] 
        [Tooltip("Minimal swipe lenght.")] 
        [SerializeField] [Range(0, 1000)] private float _minSwipeDistance;
        
        [Tooltip("Pause. If the value is 'true', the component does not process swipes and does not trigger events.")]
        [SerializeField] private bool _isPaused;

        [Tooltip("Specifies whether to output logs for developers. To output logs, use `Debug. Log'.")]
        [SerializeField] private bool _showDebugLogs;
        
        [Tooltip("Swipe input events.")]
        [SerializeField] private InputEvents _events;

        /// <summary>
        ///  Create Swipe Input.
        /// </summary>
        public SwipeInput()
        {
            _showDebugLogs = true;
        }
        
        /// <summary>
        /// Draw log record to console.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="message">Message</param>
        private void Log(string className, string methodName, string message)
        {
#if UNITY_EDITOR
            Debug.Log($"{{<b><color=white>Burning-</color><color=lime>Lab</color></b>}} => [{className}] - (<color=yellow>{methodName}</color>) -> {message}", gameObject);
#else
            Debug.Log($"{{Burning-Lab}} => [{className}] - ({methodName}) -> {message}");
#endif
        }
        
        private void Update()
        {
            if (_isPaused) return;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _posIn = Input.mousePosition;
                _events.swipeStart.Invoke(_posIn);
            }
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _posOut = Input.mousePosition;

                _events.swipeEnd.Invoke(_posOut);

                Vector2 delta = _posIn - _posOut;
                if (Mathf.Abs(delta.magnitude) < _minSwipeDistance) return;
                
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                {
                    if (delta.x < 0)
                    {
                        if (_showDebugLogs) Log("SwipeInput", "Update", "Swipe right detected");
                        _events.swipeRight.Invoke();
                    }
                    else
                    {
                        if(_showDebugLogs) Log("SwipeInput", "Update", "Swipe left detected");
                        _events.swipeLeft.Invoke();
                    }
                }
                else
                {
                    if (delta.y < 0)
                    {
                        if (_showDebugLogs) Log("SwipeInput", "Update", "Swipe up detected");
                        _events.swipeUp.Invoke();
                    }
                    else
                    {
                        if (_showDebugLogs) Log("SwipeInput", "Update", "Swipe down detected");
                        _events.swipeDown.Invoke();
                    }
                }
            }
        }
        
        /// <summary>
        /// Set Pause (No recognize swipes).
        /// </summary>
        public void SetPause() => _isPaused = true;
        
        /// <summary>
        /// Unset Pause (Recognize swipes).
        /// </summary>
        public void UnsetPause() => _isPaused = false;
    }
}
