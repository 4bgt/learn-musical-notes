using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>TrainingEvents</c> to manage all events during training
/// </summary>
public class TrainingEvents : MonoBehaviour
{
    public static TrainingEvents trainingEvents;
    private void Awake()
    {
        trainingEvents = this;
    }

    public event Action<Note> OnNewNote;
    public void NewNote(Note note)
    {
        if (OnNewNote != null)
        {
            OnNewNote(note);
        }
    }

    public event Action<string> OnClefChange;

    public void ClefChange(string clef)
    {
        if (OnClefChange != null)
        {
            OnClefChange(clef);
        }
    }

    public event Action<List<Note>,string> OnDrawNotes;

    public void DrawNotes(List<Note> notes, string clef)
    {
        if (OnDrawNotes != null)
        {
            OnDrawNotes(notes,clef);
        }
    }
}
