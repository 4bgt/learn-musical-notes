using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>SharpOrB</c> set scene for # or b
/// </summary>
public class SharpOrB : MonoBehaviour
{
    public string currentSign;

    public GameObject fullNotes;
    public GameObject halfNotes;

    public GameObject[] buttonsFull;
    public GameObject[] buttonsHalf;
    string[] namesFull = { "c", "d", "e", "f", "g", "a", "b" };
    string[] bNamesHalf = { "db", "eb", "gb", "ab", "bb" };
    string[] sharpNamesHalf = { "c#", "d#", "f#", "g#", "a#" };

    string[] namesFullGerman = { "C", "D", "E", "F", "G", "A", "H" };
    string[] bNamesHalfGerman = { "Des", "Es", "Ges", "As", "b" };
    string[] sharpNamesHalfGerman = { "Cis", "Dis", "Fis", "Gis", "Ais" };

    public Training training;

    bool init = false;


    void Start()
    {
        TrainingEvents.trainingEvents.OnNewNote += SwitchInputLabel;
    }

    void Init()
    {
        Debug.Log("Init buttons");
        buttonsFull = new GameObject[fullNotes.transform.childCount];
        buttonsHalf = new GameObject[halfNotes.transform.childCount];


        //full notes = 0,2,4,5,7,9,11
        for (int i = 0; i < fullNotes.transform.childCount; i++)
        {
            buttonsFull[i] = fullNotes.transform.GetChild(i).gameObject;
        }
        //half notes = 1,3,6,8,10
        for (int i = 0; i < halfNotes.transform.childCount; i++)
        {
            buttonsHalf[i] = halfNotes.transform.GetChild(i).gameObject;
        }
        currentSign = "";
        init = true; // buttons have been set at least once
    }

    /// <summary>
    /// Function <c>SwitchInputLabel</c> to switch note from b to #
    /// </summary>
    void SwitchInputLabel(Note newNote)
    {
        Debug.Log(newNote.name);
        //Debug.Log(newNote.sign);

        if (!init | (newNote.sign != "" & currentSign != newNote.sign)) // check if button label change is necessary? did sign change?
        {
            if (!init) //make sure buttons have been set at least once
            {
                Init();
            }

            Debug.Log("Switching button Labels");

            for (int i = 0; i < buttonsFull.Length; i++)  // update full buttons
            {
                string currentLabel = "";
                string currentName = "";
                switch (GameSettings.language) //set labels based on language
                {
                    case "de":
                        currentLabel = namesFullGerman[i];
                        break;
                    default:
                        currentLabel = namesFull[i];
                        break;
                }
                currentName = namesFull[i]; // currentName is also the button identifier
                //Debug.Log(currentName);
                buttonsFull[i].name = currentLabel; // label is name of the gameobject
                buttonsFull[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentLabel; // and also what is visible on the button
                buttonsFull[i].transform.GetComponent<Button>().onClick.RemoveAllListeners(); // remove old listeners
                buttonsFull[i].transform.GetComponent<Button>().onClick.AddListener(delegate { training.Response(currentName); }); //add new listeners based on currentName
                Debug.Log(currentName + " set");
            }


            for (int i = 0; i < buttonsHalf.Length; i++)  // update half buttons
            {
                string currentLabel = "";
                string currentName = "";

                switch (GameSettings.language) //set labels based on language
                {
                    case "de":
                        if (newNote.sign == "b")
                        {
                            currentLabel = bNamesHalfGerman[i];
                        }
                        if (newNote.sign == "#" | !init)
                        {
                            currentLabel = sharpNamesHalfGerman[i];
                        }
                        if (newNote.sign == "")
                        {
                            currentLabel = sharpNamesHalfGerman[i];
                        }
                        break;
                    default:
                        if (newNote.sign == "b")
                        {
                            currentLabel = bNamesHalf[i];
                        }
                        if (newNote.sign == "#" | !init)
                        {
                            currentLabel = sharpNamesHalf[i];
                        }
                        if (newNote.sign == "")
                        {
                            currentLabel = sharpNamesHalf[i];
                        }
                        break;
                }
                Debug.Log(newNote.name);
                Debug.Log(newNote.sign);
                //currentName = sharpNamesHalf[i];

                if (newNote.sign == "b")
                {
                    currentSign = "b";
                    currentName = bNamesHalf[i];
                }
                if (newNote.sign == "#" )
                {
                    currentSign = "#";
                    currentName = sharpNamesHalf[i];
                }
                if (newNote.sign == "") // make sure keys also get labels if note is not b or #
                {
                    currentSign = "#";
                    currentName = sharpNamesHalf[i];
                }

                buttonsHalf[i].name = currentLabel;
                buttonsHalf[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentLabel;
                buttonsHalf[i].transform.GetComponent<Button>().onClick.RemoveAllListeners();
                //Debug.Log(currentName);
                buttonsHalf[i].transform.GetComponent<Button>().onClick.AddListener(delegate { training.Response(currentName); });
                Debug.Log(currentName + " set");
            }
        }
    }
}
