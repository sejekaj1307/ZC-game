using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    public NavMeshAgent agent;
    public int actions = 3;
    public int maxActions = 3;

    public Vector3 getPos()
    {
        return transform.position;
    }

    public void moveToPos(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
}
