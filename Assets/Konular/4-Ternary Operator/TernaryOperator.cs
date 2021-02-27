using UnityEngine;
public class TernaryOperator : MonoBehaviour
{
    void Start()
    {
        int health = 10;
        string message = health > 0 ? "Condition is True" : "Condition is False";
    }
}