<p align="center">
      <img src="https://i.ibb.co/WWFP44j/Git-Hub-Logo.png" alt="Project Logo" width="726">
</p>

<p align="center">
    <img src="https://build.burning-lab.com/app/rest/builds/buildType:UnitySwipeInput_ProductionBuildAndPublish/statusIcon" alt="Build Status">
    <a href="https://n-fridman.myjetbrains.com/youtrack/agiles/121-18/current"><img src="https://img.shields.io/badge/Roadmap-YouTrack-orange" alt="Roadmap Link"></a>
    <img src="https://img.shields.io/badge/Engine-{unity_version}-blueviolet" alt="Unity Version">
    <img src="https://img.shields.io/badge/Version-{package_version}-blue" alt="Game Version">
    <img src="https://img.shields.io/badge/License-MIT-success" alt="License">
</p>

## About

The swipe capture system was conceived as a separate module that could take over all the work on recognizing and processing swipes on mobile platforms. Interaction with the component is carried out using events. This approach completely separates the code of your project and the code of the component responsible for processing swipes, and a wide set of events will allow you to use this component in any projects and for any tasks.

## Documentation

### Settings:
- **-** **`Swipe Detection Mode (DetectionMode)`** - Swipes detection mode.

- **-** **`Min Swipe Distance (float)`** - Minimum swipe length.

- **-** **`Is Paused (bool)`** - Pause. If the value is `true`, the component does not process swipes and does not raise events.

### Events:
- **-** **`Swipe Start (UnityEvent<Vector2>)`** - An event that is triggered when the user touches the screen.

- **-** **`Swipe End (UnityEvent<Vector2>)`** - An event that is triggered when the user releases the screen.

- **-** **`Swipe Up (UnityEvent)`** - An event that is triggered when a player makes an up swipe.

- **-** **`Swipe Right (UnityEvent)`** - The event that is triggered when the player makes a swipe to the right.

- **-** **`Swipe Down (UnityEvent)`** - The event that is triggered when the player makes a swipe down.

- **-** **`Swipe Left (UnityEvent)`** - The event that is triggered when the player makes a swipe to the left.

### Methods:
- **-** **`SwipeInput.SetPause()`** **`void`** - Sets the pause.

- **-** **`SwipeInput.UnsetPause()`** **`void`** - Removes the pause.

### Configuration defines:

- `DEBUG_BURNING_LAB_SDK` - Output all Burning-Lab sdk logs.

- `DEBUG_SWIPE_DETECTOR` - Output swipe detector logs only.

### Examples:
- **-** **`BurningLab/SwipeDetector/Examples/Scenes/SwipeInputDemoScene`**

## Distribute

- Download Burning-Lab.SwipeDetector on [Itch.io](https://nfridman.itch.io/goto-apps-swipe-input)

## Developers

- [n.fridman](https://github.com/n-fridman)

## License

Project Burning-Lab.SwipeDetector is distributed under the MIT license.
