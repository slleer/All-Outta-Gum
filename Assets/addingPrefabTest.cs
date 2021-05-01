using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addingPrefabTest : MonoBehaviour
{
    public GameObject go;
    public GameObject ammoBox;
    public Renderer rend;
    public GameObject newMesh;

    // Start is called before the first frame update
    void Start()
    {
        go = new GameObject("TestEmptyGOItem");
        go.AddComponent<MeshRenderer>();

        MeshFilter objMesh = go.AddComponent<MeshFilter>();
        //newMesh = Resources.Load("Assets/Store Assets/ammo_box/Prefabs/Ammo_box.prefab") as GameObject;
        objMesh.mesh = newMesh.GetComponent<MeshFilter>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
