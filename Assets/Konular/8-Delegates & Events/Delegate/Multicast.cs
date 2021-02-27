using UnityEngine;
using System.Collections;

public class Multicast : MonoBehaviour
{
    delegate void MultiDelegate();
    MultiDelegate myMultiDelegate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myMultiDelegate += PowerUp;
            myMultiDelegate += TurnRed;
        }

        if (myMultiDelegate != null && Input.GetMouseButtonDown(0))
        {
            myMultiDelegate();
        }
    }

    void PowerUp()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }

    void TurnRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}