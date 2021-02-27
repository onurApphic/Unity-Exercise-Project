using UnityEngine;
using UnityEngine.AI;

public partial class NavmeshSimpleMovement : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    private bool isRunning;
    private Camera cam;
}
public partial class NavmeshSimpleMovement : MonoBehaviour
{
    private void Awake()
    {
        cam = Camera.main;
        meshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100))
            {
                meshAgent.SetDestination(raycastHit.point);
            }
        }
    }
}
public partial class NavmeshSimpleMovement : MonoBehaviour
{
    private void ControlTheState()
    {
        if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }
}