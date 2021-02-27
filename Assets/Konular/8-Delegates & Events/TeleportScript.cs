using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnClicked += Teleport;  // Subscribe To Event
    }


    void OnDisable()
    {
        EventManager.OnClicked -= Teleport;     // Unsubscribe when Leave
    }


    void Teleport()
    {
        Vector3 pos = transform.position;
        pos.y = Random.Range(1.0f, 3.0f);
        transform.position = pos;
    }
}