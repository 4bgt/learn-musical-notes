using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>KeyTraining</c> for key training
/// </summary>
public class KeyTraining : MonoBehaviour
{

    /// <summary>
    /// Method <c>ButtonMenu</c> 
    /// </summary>
    public void ButtonMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }


    /// <summary>
    /// Method <c>Response</c> 
    /// </summary>
    public void Response(string responseName)
    {

    }


    /// <summary>
    /// Method <c>NextTrial</c> 
    /// </summary>
    public void NextTrial()
    {
    
    }

    /// <summary>
    /// Method <c>GetNewKey</c> 
    /// </summary>
    public Key GetNewKey(Key previous)
    {
        Key newKey = new Key("C");
        return newKey;
    }


    /// <summary>
    /// Method <c>Start</c> 
    /// </summary>
    void Start()
    {
        
    }
}
