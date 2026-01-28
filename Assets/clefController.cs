using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class <c>ClefController</c> to manage clefs
/// </summary>
public class ClefController : MonoBehaviour
{
    public List<GameObject> clefs;
    int clefIdx;
    public string currentClef;


    /// <summary>
    /// Function <c>Start</c> initialize clefs
    /// </summary>
    void Start()
    {
        if (TrainingEvents.trainingEvents != null)
        {
            TrainingEvents.trainingEvents.OnClefChange += ChangeClef;
        }
        if (keyTrainingEvents.keyEvents != null)
        {
            keyTrainingEvents.keyEvents.OnClefChange += ChangeClef;
        }

        for (int c = 0; c < this.transform.childCount; c++)
        {
            clefs.Add(this.transform.GetChild(c).gameObject);
        }

        for (int c = 0; c < clefs.Count(); c++) //find first active clef
        {
            if (clefs[c].activeSelf)
            {
                currentClef = clefs[c].name;
                clefIdx = c;
                break;
            }
        }

        for (int c = clefIdx; c < clefs.Count(); c++) //deactivate all others
        {
            if (clefs[c].activeSelf)
            {
                clefs[c].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Function <c>ChangeClef</c> gets clef name, activates this clef, deactivates all other clefs, returns string of current clef
    /// </summary>
    public void ChangeClef(string clefName)
    {
        Debug.Log("ClefChange" + clefs.Count);
        for (int c = 0; c < clefs.Count; c++) //find first active clef
        {
            Debug.Log(clefs[c]);
            if (clefs[c].name.ToLower() == clefName.ToLower())
            {
                Debug.Log(clefs[c]);
                clefs[c].SetActive(true);
                currentClef = clefs[c].name;
            }
            else
            {
                clefs[c].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Function <c>ChangeClef</c> gets clef index, activates this clef, deactivates all other clefs, returns string of current clef
    /// </summary>
    public string ChangeClef(int clefIdx)
    {
        for (int c = 0; c < clefs.Count(); c++) //find first active clef
        {
            if (c == clefIdx)
            {
                clefs[c].SetActive(true);
                currentClef = clefs[c].name;
            }
            else
            {
                clefs[c].SetActive(false);
            }
        }
        return currentClef;
    }
}
