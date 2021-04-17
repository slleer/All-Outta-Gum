using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player inst;
    public float playerHealth;
    public float maxHealth;
    public float playerStamina;
    public float maxStamina;
    public int ammoCount;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        playerStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
