Unity Note Trainer

An event-driven music theory android application built in Unity 2023.3 LTS for learning how to read musical notes using a touchscreen or Midi devices.


Technical Architecture

The project utilizes a decoupled, event-based architecture to manage the state between the musical logic and the UI rendering. This ensures that the notation engine remains independent of the input method.

Key Components:
	1) Event System (TrainingEvents, keyTrainingEvents): Implements a Singleton-like pattern using C# Action delegates to broadcast state changes (e.g., OnClefChange, OnNewNote) across the application.
	
	2) Input: A unified interface supporting three distinct input streams: Touchscreen Buttons, Touchscreen Keyboard, and android midi devices

	3) Sound engine: Uses a regex-based folder scanning system to load audio samples from StreamingAssets to play notes at runtime.
	
	4)  Notation Engine: Dynamically calculates note placement in UI based on MIDI indices and standard sheet mapping.


Installation & Running

    Environment: Developed with Unity 2022.3.LTS
    Dependencies: Requires the TextMeshPro package (available via Unity Package Manager).
    Setup: * Clone the repository.
        Open the project in Unity.
        Open the Menu scene and press Play.
        
      Alternatively the pre-builds from the build folder can be tested on android devices.

To-Dos / Future Enhancements    
    	0.6 all Notes visuals complete and tested		
	0.7 add Learning Enginge: clever Key Training algorithm, maybe based on REL to systematically improve a users weaknesses		
	0.8 Stats & Statview	to show user progress
	0.9 Full Midi Input Support	 (right now only midi debugger is implemented and tested)	
	1.0 Chordmode + series of notes-mode. So UI can display multiple notes at the same time instead of one note after the other.			
								
					
Known Bugs:					
	click sound when sound ends

Screenshots:
![Starting Screen](/Screenshots/start.jpg?raw=true "Starting Screen")
![Menu View](/Screenshots/menu.jpg?raw=true "Main Menu")
![Training View](/Screenshots/training.jpng?raw=true "Training View")
![Midi Menu View](/Screenshots/midi.jpg?raw=true "Midi Debugging View")
