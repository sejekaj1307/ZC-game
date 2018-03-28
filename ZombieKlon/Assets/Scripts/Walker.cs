using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour,zom {
    public Zombie zombie;
    
    public Walker(){
        zombie = new Zombie();
        zombie.hp = 1;
        zombie.dmg = 1;
        zombie.name = "Walker";
    }

    public override string ToString() {
        return name + "... Argh";
    }
}

public interface zom{

}