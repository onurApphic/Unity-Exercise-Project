using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RotationExamples : MonoBehaviour
{
    public GameObject targetObject;
    public bool LookMousePosition;
    public bool LookTargetObject;
}
public partial class RotationExamples : MonoBehaviour
{
    private void Update()
    {
        if (LookMousePosition)
        {
            LookAtMousePosition(5.0f);
        }
        if (LookTargetObject)
        {
            LookAtTarget(targetObject.transform);
        }
    }
}
public partial class RotationExamples : MonoBehaviour
{
    private void LookAtCustomEuler(float x, float y, float z)
    {
        transform.rotation = Quaternion.Euler(x, y, z);
    }
    private void LookAtTarget(Transform target)
    {
        Vector3 directionToFace = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToFace);
    }
    private void LookAtMousePosition()  // with new keyword == Garbage Collector --> Bad Choice
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + mouseX, 0);
    }
    private void LookAtMousePosition(float sensivity)   // Same as but no New Keyword + Sensivity Option
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 targetRotation = transform.localEulerAngles;
        targetRotation.y = targetRotation.y + (mouseX * sensivity);
        transform.localEulerAngles = targetRotation;
    }

}