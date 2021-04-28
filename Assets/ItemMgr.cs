using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour
{

    int chance;
    public List<GameObject> items;
    public GameObject testCube;
    public GameObject itemSpawnLocation;
    public float timedSpawn;
    public static ItemMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timedSpawn = Time.time + 5;
    }

    // Update is called once per frame
    void Update()
    {   
        if(items.Count > 0)
        {
            //handle items
            //Debug.Log("Item count is not zero");
        }
        else
        {
            chance = Random.Range(1, 10001);
            if(chance < 10)
            {
                int itemsIndex = items.Count;
                items.Add(Instantiate(testCube, itemSpawnLocation.transform));
                Item item = items[itemsIndex].GetComponent<Item>();
                item.InstantiateAmmo();
                Debug.Log(items.Count);
            }
        }
    }
}
