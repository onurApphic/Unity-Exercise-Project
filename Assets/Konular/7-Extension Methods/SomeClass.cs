using UnityEngine;
public class SomeClass : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 myVec3;
    void Start()
    {
        transform.ResetTransformation();
        myRb.ImpulseForce(myVec3);
    }
}