using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour
{

    public int chance;
    public bool bbGumActive;
    public List<GameObject> items;
    public GameObject testCube;
    public GameObject itemSpawnLocation;
    public float timedSpawn;
    public static ItemMgr inst;
    public static int itemCount;
    public AudioSource pickUpSound;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bbGumActive = false;
        itemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {   //only make an item if one doesn't already exist, for now.
        if(items.Count > 0)
        {
            if ((items[0].gameObject.transform.position - Player.inst.transform.position).sqrMagnitude < 1000f && items[0].GetComponent<Renderer>().enabled)
            {
                items[0].GetComponent<Item>().itemText.text = items[0].GetComponent<Item>().itemLabel;
            }
            else
                items[0].GetComponent<Item>().itemText.text = "";
            //handle items
            //Debug.Log("Item count is not zero");
            //Debug.Log((items[0].gameObject.transform.position - Player.inst.transform.position).sqrMagnitude);
        }
        else if (Time.timeScale == 1 && !GameMgr.inst.betweenWave)
        {   
            // If no items, pick random number to decide to spawn or not
            chance = Random.Range(1, 10001);
            if(chance <= 10)
            {
                //add item to item list and get the Item class component to instantiate the item. 
                int itemsIndex = items.Count;
                items.Add(Instantiate(testCube, itemSpawnLocation.transform));
                Item item = items[itemsIndex].GetComponent<Item>();
                // Instantiate as ammo if 1-6 (60%), powerup 7-10(40%)
                if (chance <= 6)
                    item.InstantiateAmmo();
                else
                    item.InstantiateBoost();
                //Debug.Log(items.Count);
                itemCount++;
            }
        }
    }
}
