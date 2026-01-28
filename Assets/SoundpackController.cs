using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

/// <summary>
/// Class <c>SoundpackController</c> to manage sounds 
/// </summary>
public class SoundpackController : MonoBehaviour
{
    TMP_Dropdown dropdown;
    List<string> availableSoundpacks;
    // Start is called before the first frame update
    void Start()
    {
        MenuEvents.menuEvents.OnUpdateEverything += UpdateSoundPack;
        UpdateSoundPack();
    }

    /// <summary>
    /// Method <c>UpdateSoundPack</c> to load soundpacks from streamingsassets and put them in the dopdown menu
    /// </summary>
    void UpdateSoundPack()
    {
        availableSoundpacks = new List<string>();

        List<string> soundpacks = new List<string>();
        TextAsset paths = Resources.Load<TextAsset>("StreamingAssetFolders"); // i.e. StreamingAssetPaths.txt

        string fs = paths.text;
        string[] fLines = Regex.Split(fs, "\n|\r|\r\n");

        foreach (string line in fLines)
        {
            if (line.Length > 0)
                soundpacks.Add(line);
        }

        dropdown = this.GetComponent<TMP_Dropdown>();
        dropdown.options.Clear();

        int currentSoundpack = 0;
        int soundpackIdx = 0;

        foreach (string soundpack in soundpacks)
        {
            string folder = soundpack.Replace("soundpacks" + @"\", "");
            availableSoundpacks.Add(folder);
            if (folder == GameSettings.soundPack)
            {
                currentSoundpack = soundpackIdx;
            }
            folder = UppercaseFirst(folder);
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(folder);
            dropdown.options.Add(optionData);
            soundpackIdx++;
        }
        dropdown.value = currentSoundpack;
        dropdown.RefreshShownValue();
        dropdown.onValueChanged.AddListener(delegate { DropDownValueChanged(dropdown); });
    }

    /// <summary>
    /// Method <c>UppercaseFirst</c> make first char in string uppercase
    /// </summary>
    string UppercaseFirst(string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;
        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }

    /// <summary>
    /// Method <c>DropDownValueChanged</c> change soundpack if chosen in dropdown menu
    /// </summary>
    void DropDownValueChanged(TMP_Dropdown change)
    {
        Debug.Log("DD index changed to: " + change.value.ToString());
        GameSettings.soundPack = availableSoundpacks[change.value];
    }
}
