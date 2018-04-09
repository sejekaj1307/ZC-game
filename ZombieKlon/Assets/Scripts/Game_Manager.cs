using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {
    //public Zone targetZone;

    public GameObject[] playerPrefab;
    private Player[] player;
    public int playerTurn = 0;

    Camera cam;
    CameraOrbit cameraOrbit;

    //UI elements
    public GameObject panel;
    public LayerMask interactionMask;

    void Start () {
        cam = Camera.main;
        cameraOrbit = cam.GetComponent<CameraOrbit>();
        spawnPlayers();
    }
	
    void spawnPlayers()
    {
        //Set spawnZone
        //Get nodes pos for players spawnPos

        player = new Player[playerPrefab.Length];
        for (int i = 0; i < playerPrefab.Length; i++)
        {
            GameObject p = Instantiate(playerPrefab[i], transform.position, transform.rotation);
            player[i] = p.GetComponent<Player>();
        }
        cameraOrbit.target = player[playerTurn].gameObject;
        player[playerTurn].isActive = true;
    }
	
	void Update () {
        if (player[playerTurn].actions <= 0)
        {
            changeTurn();
        }
        openMenu();
    }

    public void move(Vector3 pos)
    {
        player[playerTurn].moveToPos(pos);    
        //action--;
    }

    void changeTurn()
    {
        player[playerTurn].isActive = false;
        player[playerTurn].actions = player[playerTurn].maxActions;

        if(playerTurn == playerPrefab.Length - 1) { playerTurn = 0; print("Zombie move!"); }
        else { playerTurn++; }
        cameraOrbit.target = player[playerTurn].gameObject;
        player[playerTurn].isActive = true;
    }

    public void zombieTurn() {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach(GameObject z in zombies) {
            Zombie zom = z.GetComponent<Zombie>();
            zom.action();
        }
    }

    void openMenu()
    {
        if (Input.GetMouseButtonDown(1) && player[playerTurn].actions > 0)
        {
            //canMove = false;

            Vector3 pos = Input.mousePosition;
            if (pos.x < 120) { pos.x = 120; }
            else if (pos.x > (Screen.width - 120)) { pos.x = Screen.width - 120; }
            if (pos.y < 100) { pos.y = 100; }
            else if (pos.y > (Screen.height - 120)) { pos.y = Screen.height - 120; }

            panel.transform.position = pos;
            panel.SetActive(true);
        }
    }

    public void openDoor()
    {
        print("Open Door!");
    }

    public void search()
    {
        
    }

    public void attack()
    {
        print("Attack!");
    }

    public void pass()
    {
        player[playerTurn].actions = 0;
        panel.SetActive(false);
    }

    public void shout()
    {
        //Add noice token
        player[playerTurn].actions--;
        panel.SetActive(false);
    }

    public void movePressed()
    {
        //canMove = true;
        Debug.Log("Move!");
        panel.SetActive(false);

        //Update this so it only finds the zones near by and not all
        GameObject[] zones = GameObject.FindGameObjectsWithTag("Zone");
        foreach(GameObject item in zones)
        {
            item.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
