using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public string Name;
    [Range(10,100)]
    public int Age;
    [Popup("Imperial", "Independant", "Evil")]
    string Faction;
    [Popup("Mayor","Wizard","Layabout")]
    public string Occupation;
    [Range(1,10)]
    public int Level;
    public int Health;
    public int Strength;
    public int Magic;
    public int Defense;
    public int Speed;
    public int Damage;
    public int Armor;
    public int NoOfAttacks;
    public string Weapon;
    public Vector2 Position;
}
