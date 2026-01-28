using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AutoScrollDown : MonoBehaviour
{
    ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = this.GetComponent<ScrollRect>();
    }

    public void ScrollToTop()
    {
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }
    public void ScrollToBottom()
    {
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}
