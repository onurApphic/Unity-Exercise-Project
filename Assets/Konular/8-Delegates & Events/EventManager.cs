using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();

    // Define Our Static Event
    public static event ClickAction OnClicked;

    // Declare When our Event Will be Fired
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))    
        {
            if (OnClicked != null)  // Null Check
                OnClicked();
        }
    }
}