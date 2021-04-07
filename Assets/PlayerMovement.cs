using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //float deltaPosition = 5.0f;
    //Vector3 position;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            transform.Translate(10 * Vector3.forward * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(10 * Vector3.back * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(10 * Vector3.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(10 * Vector3.right * Time.deltaTime);

        //transform.Translate(position);
    }
}
