# SwipeInput

### Description:
**SwipeInput** - A component that contains logic for calculating the direction of swipes.

---

### Settings:
- **-** **`Min Swipe Distance (float)`** - Minimum swipe length. If the swipe length is less than the specified one, the swipe will not be recognized.

- **-** **`Is Paused (bool)`** - Pause. If the value is `true`, the component does not process swipes and does not raise events.

- **-** **`Show Debug Logs (bool)`** - Specifies whether to output logs for developers. To output logs, use `Debug.Log`.

---

### Events:
- **-** **`Swipe Start (UnityEvent<Vector2>)`** - An event that is triggered when the user touches the screen. The touch position is passed as a parameter.

- **-** **`Swipe End (UnityEvent<Vector2>)`** - An event that is triggered when the user releases the screen. The position at which the user released his finger is passed as a parameter.

- **-** **`Swipe Up (UnityEvent)`** - An event that is triggered when a player makes an up swipe.

- **-** **`Swipe Right (UnityEvent)`** - The event that is triggered when the player makes a swipe to the right.

- **-** **`Swipe Down (UnityEvent)`** - The event that is triggered when the player makes a swipe down.

- **-** **`Swipe Left (UnityEvent)`** - The event that is triggered when the player makes a swipe to the left.

---

### Methods:
**1.-** **`SwipeInput.SetPause()`** **`void`** - Sets the pause.

**2.-** **`SwipeInput.UnsetPause()`** **`void`** - Removes the pause.

---

### Examples:
- **-** **`BurningLab/SwipeDetector/Examples/Scenes/SwipeInputDemoScene`**

---

### Author Contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**

---

###### Component Developed By Nikita Fridman (Copyright Free)

---
