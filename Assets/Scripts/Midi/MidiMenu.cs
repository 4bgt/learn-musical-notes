using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidiMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }
}
