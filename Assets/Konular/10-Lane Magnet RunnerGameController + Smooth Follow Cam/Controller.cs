using UnityEngine;
using DG.Tweening;
public class Controller : MonoBehaviour // Assignments
{
    [Header("Assignments")]
    public Joystick myJoystick;
    public GameObject character;
    public Ease laneChange;
    [Header("Move Setup")]
    public float horizontalMove;
    public float speed;
    [Range(0.1f, 1.0f)]
    public float laneChangeTime;
    [Range(1.0f, 2.0f)]
    public float acceleration;
    private int targetLane;

    private void Update()
    {
        ControlTheCharacter();
    }
    public void ControlTheCharacter()
    {
        if (myJoystick.Horizontal >= 0.2f || myJoystick.Horizontal <= -0.2f)
        {
            horizontalMove = myJoystick.Horizontal * speed * Mathf.Abs(myJoystick.Horizontal * acceleration);
        }
        else
        {
            horizontalMove = 0;
        }
        if (character.transform.position.x < 1 && character.transform.position.x > -1)  // Genel Aralık
        {
            character.transform.Translate(Vector3.right * horizontalMove * Time.deltaTime);
        }
        else if (character.transform.position.x >= 1 && myJoystick.Horizontal <= -0.2f)
        {
            character.transform.Translate(Vector3.right * horizontalMove * Time.deltaTime);
        }
        else if (character.transform.position.x <= -1 && myJoystick.Horizontal >= 0.2f)
        {
            character.transform.Translate(Vector3.right * horizontalMove * Time.deltaTime);
        }
    }
    public void GoToClosestLane()
    {
        float x = character.transform.position.x;
        if (x > .5f)
        {
            targetLane = 1;
        }
        else if (x < -.5f)
        {
            targetLane = -1;
        }
        else
        {
            targetLane = 0;
        }
        character.transform.DOMoveX(targetLane, laneChangeTime).SetEase(laneChange);
    }
 
}





