# Swipe Input

A component containing logic for calculating the direction of swipes.

### Settings:
- **-** **`Swipe Detection Mode (DetectionMode)`** - Swipe detection mode.

- **-** **`Detect Multiple Swipes (bool)`** - Enable if need detection more 1 swipe directions before user release touch.

- **-** **`Min Swipe Distance (float)`** - Minimum swipe length. If the swipe length is less than the specified one, the swipe will not be recognized.

- **-** **`Is Paused (bool)`** - Pause. If the value is `true`, the component does not process swipes and does not trigger events.

### Events:
- **-** **`On Swipe Start (UnityEvent<Vector2>)`** - An event that is triggered when the user touches the screen. The touch position is passed as a parameter.

- **-** **`On Swipe End (UnityEvent<Vector2>)`** - An event that is triggered when the user releases the screen. The position in which the user released the finger is passed as a parameter.

- **-** **`On Swipe Detected (UnityEvent<SwipeDirection>)`** - The swipe detected event.

### Methods:
**1.-** **`SwipeInput.SetPause()`** **`void`** - Disable swipe detection.

**2.-** **`SwipeInput.UnsetPause()`** **`void`** - Enable swipe detection.

### Examples:
- **-** **`BurningLab/SwipeDetector/Examples/Scenes/SwipeInputDemoScene`**

### Developer contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**
