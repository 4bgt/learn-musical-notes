using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>SliderController</c> to control the slide for settings of keyboard
/// </summary>
public class SliderController : MonoBehaviour
{
    public Image handle,background;
   
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        MenuEvents.menuEvents.OnUpdateEverything += UpdateColors;
        UpdateColors();
    }

    /// <summary>
    /// Method <c>UpdateColors</c> for keyboard slider settings, turns grey when keyboard is not chosen + background color for keyboard label
    /// </summary>
    public void UpdateColors()
    {
        if (GameSettings.input != "keyboard")
        {
            handle.color = Color.grey;
            background.color = Color.grey;
        }
        else
        {
            background.color = Color.white;

            if (GameSettings.keyboardLabel)
            {
                handle.color = Color.green;
                slider.value = 1;
            }
            else
            {
                handle.color = Color.red;
                slider.value = 0;
            }
        }
    }

    /// <summary>
    /// Method <c>ButtonPress</c> to manage button press on the slider
    /// </summary>
    public void ButtonPress()
    {
        slider.value = 1 - slider.value;
        if (slider.value == 0)
        {
            GameSettings.keyboardLabel = false;
        }
        else
        {
            GameSettings.keyboardLabel = true;
        }
        Debug.Log("Slider changed to: " + slider.value);
        UpdateColors();
    }


    /// <summary>
    /// Method <c>LabelSliderChange</c> to change color based on value
    /// </summary>
    public void LabelSliderChange(float value)
    {
        if (value == 0)
        {
            GameSettings.keyboardLabel = false;
            handle.color = Color.red;
        }
        else
        {
            GameSettings.keyboardLabel = true;
            handle.color = Color.green;
        }
        Debug.Log("Slider changed to: " + value);
    }
}
