using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>keyboardSettings</c> to manage the keyboard and its labels
/// </summary>
public class keyboardSettings : MonoBehaviour
{
    public List<GameObject> texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = new List<GameObject>();
        for (int childIdx =0; childIdx < this.transform.childCount; childIdx++) //full and half notes
        {
            for (int grandChildIdx =0; grandChildIdx < this.transform.GetChild(childIdx).childCount;grandChildIdx++) // notes
            {
                texts.Add(this.transform.GetChild(childIdx).GetChild(grandChildIdx).GetChild(0).gameObject);
                if (!GameSettings.keyboardLabel)
                {
                    texts[texts.Count-1].SetActive(false);
                }
            }
        }
    }
}
