using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    // put the points from unity interface
    

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    // Use this for initialization
    void Start()
    {
        currentWayPoint = Random.Range(0, TitleMgr.inst.wayPointList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint <= TitleMgr.inst.wayPointList.Count)
        {
            if (targetWayPoint == null)
                targetWayPoint = TitleMgr.inst.wayPointList[currentWayPoint];
            walk();
        }
    }

    void walk()
    {
        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
        //Debug.Log((transform.position - targetWayPoint.position).sqrMagnitude);
        if ((transform.position - targetWayPoint.position).sqrMagnitude < 300) //items[0].gameObject.transform.position - Player.inst.transform.position).sqrMagnitude < 1000f
        {
            int index = Random.Range(0, TitleMgr.inst.wayPointList.Count);
            while(currentWayPoint == index)
                index = Random.Range(0, TitleMgr.inst.wayPointList.Count);

            targetWayPoint = TitleMgr.inst.wayPointList[index];
        }
    }
}