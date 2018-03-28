using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

    public float Size = 1f;
    public Vector2 tileSize;
    public Transform nodePrefab;
    private List<Node> nodeList;
    private Vector3 location;

    public bool playerInZone;

    void Start() {
        location = this.transform.position;
        nodeList = new List<Node>();
        NodeGenerator();
        //foreach (Node a in nodeList)
        //    Debug.Log(a.transform.position);
        checkZone();
    }

    public void NodeGenerator() { 
        var zone = new GameObject();
        zone.name = "Zone";
        for(int x = 1; x <= tileSize.x; x++) {
            for(int y = 1; y <= tileSize.y; y++) { 
                Vector3 nodePos = new Vector3((location.x-((tileSize.x/2)+0.5f))+x,0, (location.z - ((tileSize.y / 2) + 0.5f)) + y);
                Transform newNode = Instantiate(nodePrefab, nodePos, Quaternion.Euler(Vector3.right * 0)) as Transform;
                newNode.SetParent(zone.transform);
                newNode.name = "Node " + (tileSize.y*x + (y+1)).ToString();
                nodeList.Add(newNode.gameObject.GetComponent<Node>());
            }
        }
    }

    //Skal returnere en liste af zombier i rigtig targeting order
    //Denne metode skal bruges til når der angribes i en zone, og når zombierne skal 
    public GameObject[] checkZone() {
        foreach(Node node in nodeList) {
            node.check();
            //print(node.isEmpty());
        }
        return null;
    }

    public GameObject[] getUnits() {
        return null;
    }
}
