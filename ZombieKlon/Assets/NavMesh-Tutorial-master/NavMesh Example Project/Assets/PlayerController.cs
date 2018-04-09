using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;

    //isActive is only used for debug in this class !
    public bool isActive = false;

    private void Start()
    {
        cam = Camera.main;
    }
    
    void Update () {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
	}
}
