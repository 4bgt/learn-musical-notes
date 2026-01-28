using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>DrawNotes</c> to draw notes
/// </summary>
public class DrawNotes : MonoBehaviour
{
    public ClefController clefController;

    public GameObject quarterLow;
    public GameObject helperLine;
    public GameObject quarterHigh;

    public List<GameObject> currentNotes;

    float noteShiftX = 0.5f;
    float noteShiftY = 0.103125f;
    float middleCY = 3.075f;
    float quarterHighOffset = -0.5725f;
    int MidiMiddleC = 60;

    //Note[] violineLowLine = new Note[] { new Note("c1"), new Note("cis1") };
    //Note[] violineLow = new Note[] { new Note("des1"), new Note("d1"), new Note("dis1"), new Note("es1"), new Note("e1"), new Note("eis1"), new Note("fes1"), new Note("f1"), new Note("fis1"), new Note("ges1"), new Note("g1"), new Note("gis1"), new Note("as1"), new Note("a1"), new Note("ais1") };
    //Note[] violineHigh = new Note[] { new Note("hes1"), new Note("h1"), new Note("his1"), new Note("ces2"), new Note("c2"), new Note("cis2") };
    //Note[] violinHighLine = new Note[] { new Note("a2") };

    int midiThresholdViolinLow = 70;
    int midiThresholdBlow = 60; //check what the real value is....

    /// <summary>
    /// Method <c>Start</c> 
    /// </summary>
    void Start()
    {
        TrainingEvents.trainingEvents.OnDrawNotes += Draw;

        currentNotes = new List<GameObject>();
        
        //Note test = new Note(60);
        //test.clef = "violin";

        //Note test2 = new Note(65);
        //test2.clef = "violin";

        //Draw(new List <Note> { test , test2});
    }

    /// <summary>
    /// Method <c>Draw</c> Notes 
    /// </summary>
    public void Draw(List <Note> notes, string clef = "violin")
    {
        Debug.Log("Drawing...");
        foreach (GameObject currentNote in currentNotes)
        {
            Destroy(currentNote);
        }
        currentNotes = new List<GameObject>();
        if (notes.Count > 6)
        {
            Debug.LogWarning("More then 6 notes requested, not drawing!");
            return;
        }
        else
        {
            int noteIdx = 0;
            foreach (Note note in notes)
            {
                GameObject currentNote = null;

                Debug.Log(note.midiIdx);
                Debug.Log(clef);
                Debug.Log(note.sign);

                float notePositionX = noteShiftX * noteIdx;
                float notePositionY = 0;

                TrainingEvents.trainingEvents.ClefChange(clef);

                if (clef == "violin")
                {
                    if (note.sign == "b")
                    {
                        if (note.midiIdx > (midiThresholdViolinLow - 1))
                        {
                            Debug.Log("quarterHigh Violin");
                            currentNote = Instantiate(quarterHigh, new Vector3(0, 0, 0), Quaternion.identity);
                            int noteDistance = note.NoteDistance(MidiMiddleC);

                            notePositionY = ((noteDistance) * noteShiftY) + middleCY + quarterHighOffset;
                            Debug.Log("notePositionY: " + notePositionY);

                            //nur wenn abstand größer als x dann linien zeichnen
                            if (noteDistance > 9)
                            {
                                int nLines = (noteDistance-9) / 2;
                                Debug.Log("drawing "+nLines+ " helper lines");
                                for (int l = 0; l < nLines; l++)
                                {
                                    float linePositionY = notePositionY + ((l * -2) * 0.1f) - quarterHighOffset ;
                                    Debug.Log("Adding Higher Line" + l);
                                    GameObject currentHelperLine = Instantiate(helperLine, new Vector3(0, 0, 0), Quaternion.identity, this.transform);

                                    currentHelperLine.transform.localPosition = new Vector3(notePositionX+0.075f, 0, 0);
                                    currentHelperLine.transform.GetChild(0).transform.localPosition = new Vector3(0, linePositionY, 0);
                                    currentHelperLine.name = "helperLine " + l;
                                }      
                            }
                        }
                        else
                        {
                            Debug.Log("quarterLow Violin: " + note.midiIdx);
                            currentNote = Instantiate(quarterLow, new Vector3(0, 0, 0), Quaternion.identity);
                            int noteDistance = note.NoteDistance(MidiMiddleC);

                            notePositionY = ((noteDistance) * noteShiftY) + middleCY;
                            if (noteDistance < 0)
                            {
                                int nLines = Mathf.Abs(noteDistance) / 2;
                                Debug.Log("drawing "+nLines+ " helper lines");
                                for (int l = 0; l < nLines; l++)
                                {   
                                    float linePositionY = ((l * -2) * noteShiftY) + middleCY;
                                    Debug.Log("Adding Lower Line" + l);
                                    GameObject currentHelperLine = Instantiate(helperLine, new Vector3(0, 0, 0), Quaternion.identity, this.transform);

                                    currentHelperLine.transform.localPosition = new Vector3(notePositionX, 0, 0);
                                    currentHelperLine.transform.GetChild(0).transform.localPosition = new Vector3(0, linePositionY, 0);
                                    currentHelperLine.name = "helperLine " + l;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (note.midiIdx > midiThresholdViolinLow)
                        {
                            Debug.Log("quraterHigh Violin");
                            currentNote = Instantiate(quarterHigh, new Vector3(0, 0, 0), Quaternion.identity);
                            int noteDistance = note.NoteDistance(MidiMiddleC);

                            notePositionY = ((noteDistance) * noteShiftY) + middleCY + quarterHighOffset;
                            Debug.Log("notePositionY: " + notePositionY);

                            //nur wenn abstand größer als x dann linien zeichnen
                            if (noteDistance > 10)
                            {
                                int nLines = (noteDistance-10) / 2;
                                Debug.Log("drawing "+nLines+ " helper lines");
                                for (int l = 0; l < nLines; l++)
                                {
                                    float linePositionY = ((l * -2) * noteShiftY) + middleCY;
                                    Debug.Log("Adding Lower Line" + l);
                                    GameObject currentHelperLine = Instantiate(helperLine, new Vector3(0, 0, 0), Quaternion.identity, this.transform);

                                    currentHelperLine.transform.localPosition = new Vector3(notePositionX, 0, 0);
                                    currentHelperLine.transform.GetChild(0).transform.localPosition = new Vector3(0, linePositionY, 0);
                                    currentHelperLine.name = "helperLine " + l;
                                }      
                            }
                        }
                        else
                        {
                            Debug.Log("quarterLow Violin: " +note.midiIdx);
                            currentNote = Instantiate(quarterLow, new Vector3(0, 0, 0), Quaternion.identity);
                            notePositionY = ((note.NoteDistance(MidiMiddleC)) * noteShiftY) + middleCY;


                            if (note.midiIdx == (MidiMiddleC + 1))
                            {
                                if (note.sign == "#") //special case c#4
                                {
                                    //insert note distance function here
                                    Debug.Log("lower helper line needed");
                                    int nLines = 1;

                                    for (int l = 0; l < nLines; l++)
                                    {
                                        float linePositionY = ((l * -2) * noteShiftY) + middleCY;
                                        Debug.Log("Adding Lower Line" + l);
                                        GameObject currentHelperLine = Instantiate(helperLine, new Vector3(0, 0, 0), Quaternion.identity, this.transform);

                                        currentHelperLine.transform.localPosition = new Vector3(notePositionX, 0, 0);
                                        currentHelperLine.transform.GetChild(0).transform.localPosition = new Vector3(0, linePositionY, 0);
                                        currentHelperLine.name = "helperLine " + l;
                                    }
                                }
                            }

                            if (note.midiIdx < (MidiMiddleC + 1)) // lower helper lines for everything below c#4
                            {
                                //insert note distance function here
                                Debug.Log("lower helper line needed");
                                int noteDistance = note.NoteDistance(MidiMiddleC);
                                int nLines = noteDistance / 2;
                                Debug.Log(nLines);
                                for (int l = 0; l < nLines; l++)
                                {
                                    float linePositionY = ((l * -2) * noteShiftY) + middleCY;
                                    Debug.Log("Adding Lower Line" + l);
                                    GameObject currentHelperLine = Instantiate(helperLine, new Vector3(0, 0, 0), Quaternion.identity, this.transform);

                                    currentHelperLine.transform.localPosition = new Vector3(notePositionX, 0, 0);
                                    currentHelperLine.transform.GetChild(0).transform.localPosition = new Vector3(0, linePositionY, 0);
                                    currentHelperLine.name = "helperLine " + l;
                                }
                            }
                        }
                    }
                }
                if (clef == "bass")
                {
                    if (note.sign == "b")
                    {
                        if (note.midiIdx > (midiThresholdBlow - 1))
                        {
                            currentNote = Instantiate(quarterHigh, new Vector3(0, 0, 0), Quaternion.identity);
                        }
                        else
                        {
                            currentNote = Instantiate(quarterLow, new Vector3(0, 0, 0), Quaternion.identity);
                        }
                    }
                    else
                    {
                        if (note.midiIdx > midiThresholdBlow)
                        {
                            currentNote = Instantiate(quarterHigh, new Vector3(0, 0, 0), Quaternion.identity);
                        }
                        else
                        {
                            currentNote = Instantiate(quarterLow, new Vector3(0, 0, 0), Quaternion.identity);
                            notePositionY = ((note.midiIdx - MidiMiddleC) * noteShiftY) + middleCY;
                        }
                    }
                }
                currentNote.transform.parent = this.transform;
                currentNote.name = note.name;
                currentNote.transform.localPosition = new Vector3(notePositionX,0,0);
                currentNote.transform.GetChild(0).transform.localPosition = new Vector3(0,notePositionY,0);
                currentNote.transform.localScale = new Vector3(1, 1, 1);
                currentNotes.Add(currentNote);
                noteIdx++;
            }
        }
    }

}
