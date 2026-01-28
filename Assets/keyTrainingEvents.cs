using System;
using UnityEngine;

/// Class <c>keyTrainingEvents</c> to manage all events during keyTraining
public class keyTrainingEvents : MonoBehaviour
{
    public static keyTrainingEvents keyEvents;

    private void Awake()
    {
        keyEvents = this;
    }

    public event Action<Key, string> OnDrawSigns;

    public void DrawSigns(Key key,string clef)
    {
        if (OnDrawSigns != null)
        {
            OnDrawSigns(key,clef);
        }
    }

    public event Action<string> OnClefChange;

    public void ClefChange(string clef)
    {
        Debug.Log("Clef Change called");
        if (OnClefChange != null)
        {
            OnClefChange(clef);
        }
    }
}
