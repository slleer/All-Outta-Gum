/*
 * Filename : InputMgr.cs
 * Purpose  : Handle input (minus mouse input)
 * Date     : 4/24/21                                                           */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
    float regen;
    float drain;
    float deltaPosition;
    float regenTimer;
    float maxDelay;
    public Player player;

    void Awake()
    {
        player = Player.inst;
    }

    private void Start()
    {
        deltaPosition = Player.inst.speed;
        regen = Player.inst.staminaRegenPerSecond;
        drain = Player.inst.staminaDrainPerSecond;
        maxDelay = Player.inst.regenDelay;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            WeaponMgr.inst.SelectPreviousWeapon();
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            WeaponMgr.inst.SelectNextWeapon();
        }
        //reload on R keyup
        if (Input.GetKeyUp(KeyCode.R))
            WeaponMgr.inst.selectedWeapon.Reload();
        //check for left mouse, nextTimeToFire, and not reloading
        if ((Input.GetMouseButton(0)) && (Time.time >= WeaponMgr.inst.selectedWeapon.timeToFire))
        {
            WeaponMgr.inst.selectedWeapon.Shoot();
        }
        //if tab is pressed pause or unpause
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if(UIMgr.inst.pausePanel.activeSelf)
            {
                Time.timeScale = 1;
                WeaponMgr.inst.selectedWeapon.timeToFire = Time.time + .01f;
                UIMgr.inst.pausePanel.SetActive(false);
                UIMgr.inst.scoreText.text = string.Concat("Score: ", ((int)Player.inst.score).ToString());
            }
            //pause menu
            else
            {
                Time.timeScale = 0;
                UIMgr.inst.pausePanel.SetActive(true);
            }
        }

        //while shift is pressed & stamina is remaining - set moveSpeedMultiplier to 3
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //regenTimer = regenDelay
            regenTimer = maxDelay;
            if (Player.inst.playerStamina > 0)
            {
                Player.inst.speedMultiplier = Player.inst.sprintMultiplier;
                Player.inst.playerStamina -= drain * Time.deltaTime;
                Player.inst.playerStamina = (Player.inst.playerStamina <= 0 ? 0 : Player.inst.playerStamina);
            }
            else
                Player.inst.speedMultiplier = 1.0f;
        }
        //if shift is not pressed, regen stamina and moveSpeedMultiplier is set to 1
        //this allows one function call for movement calculation, instead of having one for normal speed and one for sprint speed
        else
        {
            regenTimer -= Time.deltaTime;
            Player.inst.speedMultiplier = 1.0f;
            //regen stamina
            //wait a second before stamina regen begins

            if(regenTimer < 0)
            {
                //Debug.Log(regenTimer)
                if (Player.inst.playerStamina < Player.inst.maxStamina)
                {
                    Player.inst.playerStamina += regen * Time.deltaTime;
                }
            }

        }

        //movement happens whether shift is pressed or not, shift pressed turns sprintMultiplier to 3, defaults to 1 otherwise
        if (Input.GetKey(KeyCode.W))
            player.transform.Translate(Player.inst.speedMultiplier * deltaPosition * Vector3.forward * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            player.transform.Translate(Player.inst.speedMultiplier * deltaPosition * Vector3.back * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            player.transform.Translate(Player.inst.speedMultiplier * deltaPosition * Vector3.left * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))
            player.transform.Translate(Player.inst.speedMultiplier * deltaPosition * Vector3.right * Time.deltaTime, Space.World);

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
