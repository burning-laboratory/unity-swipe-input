# Swipe Input

A component containing logic for calculating the direction of swipes.

### Settings:

- **-** **`Swipe Detection Mode (DetectionMode)`** - Swipe recognition mode. Completed or incomplete swipe.

- **-** **`Detect multiple swipes (bool)`** - Enable it if you need to recognize multiple swipes without taking your finger off the screen.

- **-** **`Handle Keyboard Arrows Clicks (bool)`** - Enable it if you need to trigger swipe processing events when pressing the arrows on the keyboard.

- **-** **`Min Swipe Distance (float)`** - Minimum swipe length.

- **-** **`Is Paused (bool)`** - Pause. If the value is `true`, the component does not process swipes and does not raise events.

### Events:
- **-** **`On Swipe Start (UnityEvent<Vector2>)`** - An event that is triggered when the user touches the screen.

- **-** **`On Swipe End (UnityEvent<Vector2>)`** - An event that is triggered when the user releases the screen.

- **-** **`On Swipe Detected (SwipeDirection)`** - Called when the swipe is recognized.

### Methods:
- **-** **`SwipeInput.SetPause()`** **`void`** - Sets the pause.

- **-** **`SwipeInput.UnsetPause()`** **`void`** - Removes the pause.

### Developer contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**
