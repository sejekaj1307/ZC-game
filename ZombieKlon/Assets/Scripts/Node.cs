using UnityEngine;

public class Node : MonoBehaviour {
    public bool occupied = false;
    public LayerMask interactionMask;


    public void Start() {
        //check();
        //print(unit.name);
    }

    //Ved ikke om denne her er nødvendig
    //Teoretisk set behøver vi ikke have de to her(leave og occupie) da ScanAbove burde kunne gøre det, 
    //men tænker at det måske kommer til at kræve meget energi hvis ALLE tiles skal scanne hele tiden
    public void leavePosition() {
        occupied = false;
    }

    //Til at sætte hvilket unit type der står oven på noden
    public void occupiePosition(Unit unit) {
        //this.unit = unit;
    }

    public bool isEmpty() {
        return occupied;
    }

    public void check() {
        RaycastHit hit;
        Vector3 up = transform.TransformDirection(Vector3.up);
        if (Physics.Raycast(transform.position, up, out hit, 100f, interactionMask)) {
            occupied = true;
        }
    }

}
/*
 * public void check() {
        RaycastHit hit;
        Vector3 up = transform.TransformDirection(Vector3.up);
        Debug.DrawRay(transform.position, up, Color.green);
        //if it is a zombie
        if (Physics.Raycast(transform.position, up, out hit, 100f, interactionMask)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Zombie")) {

                unit = hit.transform.gameObject.GetComponent<zom>();
                print(unit.ToString());
            }
        }
    }
 */