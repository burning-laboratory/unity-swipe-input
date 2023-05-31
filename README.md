<p align="center">
      <img src="https://i.ibb.co/WWFP44j/Git-Hub-Logo.png" alt="Project Logo" width="726">
</p>

<p align="center">
    <img src="https://build.burning-lab.com/app/rest/builds/buildType:id:UnityAssets_ComBurningLabSwipedetector_DevelopmentBuild/statusIcon.svg" alt="Build Status">
    <a href="https://burning-lab.youtrack.cloud/agiles/131-11/current"><img src="https://img.shields.io/badge/Roadmap-YouTrack-orange" alt="Roadmap Link"></a>
    <img src="https://img.shields.io/badge/Engine-2021.3-blueviolet" alt="Unity Version">
    <img src="https://img.shields.io/badge/Version-1.2.1-blue" alt="Game Version">
    <img src="https://img.shields.io/badge/License-MIT-success" alt="License">
</p>

## About

The swipe capture system was conceived as a separate module that could take over all the work on recognizing and processing swipes on mobile platforms. Interaction with the component is carried out using events. This approach completely separates the code of your project and the code of the component responsible for processing swipes, and a wide set of events will allow you to use this component in any projects and for any tasks.

## Installation

1. Add Burning-Lab registry to Unity Project.
2. Install `Swipe Detector` package via Unity Package Manager.

**Burning-Lab Registry:**
```json
    {
      "name": "Burning-Lab Registry",
      "url": "https://packages.burning-lab.com",
      "scopes": [
        "com.burning-lab"
      ]
    }
```

## Documentation

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

### Configuration defines:

- `DEBUG_BURNING_LAB_SDK` - Output all Burning-Lab sdk logs.

- `DEBUG_SWIPE_DETECTOR` - Output swipe detector logs only.

## Distribute

- [packages.burning-lab.com](https://packages.burning-lab.com/-/web/detail/com.burning-lab.swipedetector)

## Developers

- [n.fridman](https://github.com/n-fridman)

## License

Project Burning-Lab.SwipeDetector is distributed under the MIT license.
