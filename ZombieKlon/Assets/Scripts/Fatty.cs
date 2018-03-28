using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty : MonoBehaviour, zom {
    public Zombie zombie;

    public Fatty() {
        zombie = new Zombie();
        zombie.hp = 2;
        zombie.dmg = 2;
        zombie.name = "Fatty";
    }

    public override string ToString() {
        return name + " fatass";
    }
}