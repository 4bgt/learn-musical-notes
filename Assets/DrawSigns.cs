using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>DrawSigns</c> to draw b and #
/// </summary>
public class DrawSigns : MonoBehaviour
{
    public List<GameObject> currentSigns;
    public GameObject bSign;
    public GameObject sharpSign;

    int[] bPos = { 11, 14, 10, 13, 9, 12, 8 };
    int[] sharpPos = { 15, 12, 16, 13, 10, 14, 11 };

    float signShiftX = 0.5f;
    float signShiftY = 0.1f;
    float middleCY = 3.075f;

    void Start()
    {
        Draw(new Key("###","major"), "violin");

        keyTrainingEvents.keyEvents.OnDrawSigns += Draw;
        currentSigns = new List<GameObject>();

    }

    /// <summary>
    /// Method <c>Draw</c> clefs and destroy old notes
    /// </summary>
    public void Draw(Key key, string clef = "")
    {
        if (clef != "")
        {
            Debug.Log(clef);
            keyTrainingEvents.keyEvents.ClefChange(clef);
            Debug.Log("Clef Change to: " + clef);
        }

        //destroy old signs
        for (int k = 0; k < currentSigns.Count; k++)
        {
            Destroy(currentSigns[k]);
        }
        currentSigns.Clear();

        GameObject currentSign = null;
        float signPositionX = 0, signPositionY = 0;

        //draw #s
        for (int s = 0; s < key.sharp; s++)
        {
            signPositionX = signShiftX * s;
            signPositionY = (sharpPos[s] * signShiftY) + middleCY;

            currentSign = Instantiate(sharpSign);
        }

        //draw bs
        for (int b = 0; b < key.b; b++)
        {
            signPositionX = signShiftX * b;
            signPositionY = (bPos[b] * signShiftY) + middleCY;

            currentSign = Instantiate(bSign);
        }
        currentSign.transform.SetParent(transform, true);
        currentSign.transform.position = new Vector3(signPositionX, signPositionY, 0);
        currentSigns.Add(currentSign);

        Debug.Log("Signs drawn");
    }
}
