using UnityEngine;

/// <summary>
/// Class <c>inputSettings</c> to manage which input is used (buttons, keyboard or midi)
/// </summary>
public class inputSettings : MonoBehaviour
{
    GameObject keyboard, buttons, midi;

    // Start is called before the first frame update
    void Start()
    {
        buttons = this.gameObject.transform.GetChild(0).gameObject;
        keyboard = this.transform.GetChild(1).gameObject;
        midi = this.transform.GetChild(2).gameObject;

        if (GameSettings.input == "buttons")
        {
            keyboard.SetActive(false);
            midi.SetActive(false);
        }
        if (GameSettings.input == "keyboard")
        {
            buttons.SetActive(false);
            midi.SetActive(false);
        }
    }
}
