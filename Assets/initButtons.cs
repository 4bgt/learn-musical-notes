using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class <c>initButtons</c> to initialize buttons and keys of the keyboard
/// </summary>
public class initButtons : MonoBehaviour
{
    public GameObject[] buttons; // contains all children Gameobjects (all buttons/ keys)
    
    public Training training;  // acces to training to link buttons to response function
    public KeyTraining keyTraining;  // acces to training to link buttons to response function


    // Start is called before the first frame update
    void Start()
    {
        buttons = new GameObject[transform.childCount]; //init

        for (int i = 0; i < transform.childCount; i++) // go through all children
        {
            buttons[i] = transform.GetChild(i).gameObject; // put them in array

            string response = buttons[i].name; // use name of the child for the response function

            buttons[i].transform.GetComponent<Button>().onClick.RemoveAllListeners(); // remove previous functions on this button
            if (training != null)
            {

            }
            if (keyTraining != null)
            {
                buttons[i].transform.GetComponent<Button>().onClick.AddListener(delegate { keyTraining.Response(response); });  // add response (name) as function for this button
            }
        }
    }
}
