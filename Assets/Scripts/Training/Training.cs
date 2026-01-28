using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>Training</c> to Note learning training
/// </summary>
public class Training : MonoBehaviour
{
    public string currentResponse;
    public Note currentNote, currentNoteSharpSimple;
    int trialIdx;
    public TextMeshProUGUI text;

    public string timeLeft;

    double startUpTime;
    int errors;

    public AudioSource audioSource;

    Dictionary<string,int> responses;


    void Start()
    {
        responses = new Dictionary<string, int>// this list contains all buttons/ display keys and allows us to easily get the distance to c in half tones.
        {
            { "c" ,0},
            { "c#" ,1},
            { "db" ,1},
            { "d" ,2},
            { "d#" ,3},
            { "eb" ,3},
            { "e" ,4},
            { "f" ,5},
            { "f#" ,6},
            { "gb" ,6},
            { "g" ,7},
            { "g#" ,8},
            { "ab" ,8},
            { "a" ,9},
            { "a#" ,10},
            { "bb" ,10},
            { "h" ,11},
            { "b" ,11},
        };
        


        startUpTime = Time.realtimeSinceStartup;

        trialIdx = 0;
        currentNote = new();
        //text.text = currentNote.name;
        //Debug.Log(currentNote.name);
        //Debug.Log(currentNote.sign);

        audioSource = this.GetComponent<AudioSource>();

        //if (GameSettings.sound == "note" | GameSettings.sound == "note&input")
        //{
        //    Play(currentNote, audioSource);
        //}
        NextTrial();
    }


    private void Update()
    {
        timeLeft = (GameSettings.trainingTime-(Time.realtimeSinceStartup - startUpTime)).ToString();
    }

    /// <summary>
    /// This function creates the path to the needed sound file and starts a coroutine to play it
    /// </summary>
    public void Play(Note note, AudioSource audioSource)
    {
        Debug.Log("Playing Note:" + note.name + " Midi-ID: " + note.midiIdx);
        string pathToCurrentSound = Path.Combine(StreamingAssetsPath.StreamingAssetPathForWWW(), "soundpacks", GameSettings.soundPack, note.midiIdx+ ".ogg");
        //Debug.Log(pathToCurrentSound);
        StartCoroutine(RequestAndPlay(pathToCurrentSound, audioSource));
    }

    /// <summary>
    /// This function sends a web request to play a soundfile with the given audioSource and path. It seems to be way to complicated, but this is how you play sounds on android.... (also works on windows...)
    /// </summary>
    IEnumerator RequestAndPlay(string path, AudioSource audioSource)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(path);
                AudioClip currentSound = DownloadHandlerAudioClip.GetContent(www);
                audioSource.PlayOneShot(currentSound);
            }
        }
    }




    public void ButtonMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// This function handles the responses that come in via buttons/ keys on the display
    /// </summary>
    public void Response(string responseName)
    {
        Debug.Log("response:" + responseName);
        currentResponse = responseName;

        int i = responses[responseName]; // get index of response == half tone distance to c

        Note response = new Note((currentNote.midiIdx - currentNote.baseIdx + i));  //define a new response note based on the half tone distance and the baseIdx (octave) of the current note 

        Debug.Log("Response: "+response.name + " Midi-ID: "+response.midiIdx +  " Incoming responseName: " +responseName);

        if (GameSettings.sound == "input" | GameSettings.sound == "note&input")
        {
            Play(response, audioSource);            //Play the sound
        }

        if (GameSettings.trainingTime > (Time.realtimeSinceStartup - startUpTime))
        {

            if (currentNote.midiIdx == response.midiIdx)
            {
                Debug.Log("Correct: response: " + response.name + " note: " + currentNote.name);
                NextTrial();
            }
            else
            {
                Debug.Log("Error: response: " + response.name + "(midi:"+response.midiIdx+") " + " note: " + currentNote.name + "(midi:" + currentNote.midiIdx + ") ");
                errors++;
            }
        }
        else
        {
            text.text = "Training beendet. \n" + (trialIdx * 10 - errors * 5) + " Punkte!";
            return;
        }
    }

    /// <summary>
    /// Method <c>NextTrial</c> starts the next trial
    /// </summary>
    public void NextTrial()
    {
        trialIdx++;
        Debug.Log("new Trial: " + trialIdx);
        List<Note> currentNotes = new List<Note>();
        text.text = "";
        for (int n = 0; n < GameSettings.nNotes; n++)
        {
            Note tempNote = GetNewNote(currentNote);
            currentNotes.Add(tempNote);
            text.text = text.text + tempNote.name + ",";
        }
        currentNote = currentNotes.First();
        Debug.Log("New Note Event");
        TrainingEvents.trainingEvents.NewNote(currentNote);

        Debug.Log("Draw Event");
        TrainingEvents.trainingEvents.DrawNotes(currentNotes,"violin");


        if (GameSettings.sound == "note" | GameSettings.sound == "note&input")
        {
            StartCoroutine(PlayNotes(currentNotes));
        }

    }

    /// <summary>
    /// Function <c>PlayNotes</c> plays sound for a list of Notes
    /// </summary>
    IEnumerator PlayNotes(List<Note> currentNotes)
    {
        for (int n = 0; n < GameSettings.nNotes; n++)
        {
            Play(currentNotes[n], audioSource);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    /// <summary>
    /// Function <c>GetNewNote</c> Gets a new note based on GameSettings.trainingMode
    /// </summary>
    public Note GetNewNote(Note previous)
    {
        Debug.Log("GetNewNote");
        Note note = new Note();

        string targetClef = "";

        switch (GameSettings.trainingMode)
        {
            case "random":
                targetClef = GameSettings.clefs[Random.Range(0, GameSettings.clefs.Length)];
                int minNote;
                int maxNote;
                switch (targetClef)
                {
                    case "violin":
                        minNote = GameSettings.minNoteViolin;
                        maxNote = GameSettings.maxNoteViolin;
                        break;
                    case "bass":
                        minNote = GameSettings.minNoteBass;
                        maxNote = GameSettings.maxNoteBass;
                        break;
                    default:
                        break;
                }

                while (note.midiIdx == previous.midiIdx | note.possibleClefs.Length < 1 | !note.possibleClefs.Contains(targetClef))
                {
                    note = new Note();
                }
                break;
            case "testing":
                note = new Note(85,"b");
                targetClef = "violin";
                break;
            case "stats": //clever algo based on previous errors
                break;
            case "ml": //machine learning algo based on previous errors
                break;
            case "default":
                break;
        }

        Debug.Log(note.name);
       // Debug.Log(note.sign);
        Debug.Log("previous Note: "+previous.name);
        
        note.clef = targetClef;
        return note;
    }
}
