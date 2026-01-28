Unity Note Trainer

An event-driven music theory Android application built in Unity 2023.3 LTS for learning how to read musical notes using a touchscreen or MIDI devices.
Technical Architecture

The project utilizes a decoupled, event-based architecture to manage the state between the musical logic and the UI rendering. This ensures that the notation engine remains independent of the input method.
Key Components

    Event System (TrainingEvents, keyTrainingEvents): Implements a Singleton-like pattern using C# Action delegates to broadcast state changes (e.g., OnClefChange, OnNewNote) across the application.

    Input: A unified interface supporting three distinct input streams: Touchscreen Buttons, Touchscreen Keyboard, and Android MIDI devices.

    Sound Engine: Uses a regex-based folder scanning system to load audio samples from StreamingAssets to play notes at runtime.

    Notation Engine: Dynamically calculates note placement in UI based on MIDI indices and standard sheet mapping.

Installation & Running

    Environment: Developed with Unity 2022.3 LTS.

    Dependencies: Requires the TextMeshPro package (available via Unity Package Manager).

    Setup: 1. Clone the repository. 2. Open the project in Unity. 3. Open the Menu scene and press Play.

    [!TIP] Alternatively, the pre-builds from the build folder can be tested directly on Android devices.

To-Dos / Future Enhancements

    [x] 0.6: All Notes visuals complete and tested.

    [ ] 0.7: Add Learning Engine: Clever Key Training algorithm (possibly based on REL) to systematically improve user weaknesses.

    [ ] 0.8: Stats & Statview to show user progress.

    [ ] 0.9: Full MIDI Input Support (currently only MIDI debugger is implemented and tested).

    [ ] 1.0: Chord mode + series of notes mode (UI support for multiple simultaneous notes).

Known Bugs

    Click sound when sound ends.

Screenshots
Starting Screen	Menu View
<img src="/Screenshots/start.jpg?raw=true" width="400">	<img src="/Screenshots/menu.jpg?raw=true" width="400">
Training View	MIDI Menu View
<img src="/Screenshots/training.jpng?raw=true" width="400">	<img src="/Screenshots/midi.jpg?raw=true" width="400">