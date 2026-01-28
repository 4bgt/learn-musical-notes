using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button StartButton;
    public Button Midi;
    public Button InputMidi;
    public Button InputKeyboard;
    public Button InputButtons;

    public SliderController sliderController;

    // Start is called before the first frame update
    void Start()
    {
        MenuEvents.menuEvents.OnUpdateEverything += UpdateMainMenu;


        //mark buttons as selected
        MenuEvents.menuEvents.UpdateEverything();
    }

    public void UpdateMainMenu()
    {
        ButtonInput(GameSettings.input);
    }

    public void ButtonStart()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Training");
    }

    public void ButtonMidi()
    {
        Debug.Log("Start Midi");
        SceneManager.LoadScene("Midi");
    }

    public void ButtonInput(string input)
    {
        if (input == "keyboard")
        {
            InputKeyboard.Select();
        }
        if (input == "buttons")
        {
            InputButtons.Select();
        }
        if (input == "midi")
        {
            InputMidi.Select();
        }
        GameSettings.input = input;
    }
}
