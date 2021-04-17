using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputMgr : MonoBehaviour
{
    void Start()
    {
        player = Player.inst;
    }
    public float deltaPosition = 10.0f;
    public float sprintMultiplier = 1.0f;
    public Player player;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Player.inst.playerStamina > 0)
            {
                sprintMultiplier = 3.0f;
                Player.inst.playerStamina -= sprintMultiplier * Time.deltaTime;
                Player.inst.playerStamina = (Player.inst.playerStamina <= 0 ? 0 : Player.inst.playerStamina);
            }
            else
                sprintMultiplier = 1f;

            if (Input.GetKey(KeyCode.W))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.right * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.left * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.forward * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.back * Time.deltaTime);
        }
        else
        {
            sprintMultiplier = 1f;
            if (Player.inst.playerStamina < Player.inst.maxStamina)
            {
                float deltaStamina = Player.inst.playerStamina + Time.deltaTime;
                Player.inst.playerStamina = (deltaStamina > Player.inst.maxStamina ? Player.inst.maxStamina : deltaStamina);
            }
            if (Input.GetKey(KeyCode.W))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.right * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.left * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.forward * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                            Application.Quit();
            #endif
        }
    }
}
