using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject target;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 60, target.transform.position.z);
        //transform.position.z = target.transform.position.z;
    }
}
