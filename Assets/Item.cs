using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    ammo,
    gun,
    boost
}
public class Item : MonoBehaviour
{
    public Gun gunType = Gun.shotgun;
    public int ammo = 100;
}
