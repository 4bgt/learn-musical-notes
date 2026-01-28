using System;
using UnityEngine;

/// <summary>
/// Class <c>MenuEvents</c> for all events in the menu
/// </summary>
public class MenuEvents : MonoBehaviour
{
    public static MenuEvents menuEvents;

    private void Awake()
    {
        menuEvents = this;
    }
    public event Action OnUpdateEverything;

    public void UpdateEverything()
    {
        if (OnUpdateEverything != null)
        {
            OnUpdateEverything();
        }
    }
}
