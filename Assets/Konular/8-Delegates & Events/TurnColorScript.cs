using UnityEngine;
using System.Collections;

public class TurnColorScript : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnClicked += TurnColor;     // Subscribe To Event // Subscribe when Do U Want
    }


    void OnDisable()
    {
        EventManager.OnClicked -= TurnColor;    // Unsubscribe when Leave
    }


    void TurnColor()
    {
        Color col = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = col;
    }
}