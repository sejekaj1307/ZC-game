using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    public NavMeshAgent agent;
    public int actions = 3;
    public int maxActions = 3;
    public bool isActive = false;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
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

    public Vector3 getPos()
    {
        return transform.position;
    }

    public void moveToPos(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
}
