using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gun
{
    pistol,
    assaultRifle,
    shotgun
}

public class Weapon : MonoBehaviour
{
    public float baseDmg;
    public float bonusDmg;
    public float shotsPerSecond;
    public int clipSize;
    public int clipCount;
    public int ammoCapacity;
    public int ammoCount;
    public float reloadRate;
    public float timeToFire;
    public bool reload;
    public Weapon weaponObject;
    public GameObject gunSprite;
    public Gun gunType;



    public virtual void Init()
    {

    }
    public virtual void Reload()
    {

    }
    public virtual void Shoot()
    {

    }

    public void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        //Debug.Log(start + " " + end + " " + color);
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
