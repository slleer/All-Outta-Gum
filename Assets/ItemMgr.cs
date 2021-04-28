using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour
{

    int chance;
    public List<GameObject> items;
    public GameObject testCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(items.Count > 0)
        {
            //handle items
        }
        chance = Random.Range(1, 101);
        if(chance < 10)
        {
            //GameObject item = Instantiate(testCube, Player.inst.gameObject.transform);
        }
    }
}
