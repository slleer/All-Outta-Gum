using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;
    public float coolDown = 5.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.inst.health <= 0)
        {
            Time.timeScale = 0;
            UIMgr.inst.OnGameOver();
        }
        if(ZombieManager.inst.waveFinishedSpawning && ZombieManager.inst.zombies.Count <= 0)
        {
            if (coolDown < 0)
            {
                Debug.Log("Wave cleared. Gonna display this out later. ");
                //Player.inst.score += 10000;
                Time.timeScale = 0;
                UIMgr.inst.OnGameOver();
            }
            coolDown -= Time.deltaTime;
        }
    }
    
    public void StartGame()
    {
        //Initiate wave somehow here
        Time.timeScale = 1;
        UIMgr.inst.OnGameStart();

    }
    public void NewGame()
    {
        //Initiate wave somehow here
        Time.timeScale = 1;
        Debug.Log("NewGame");
        UIMgr.inst.NewGame();
        Player.inst.ResetPlayer();
        ZombieManager.inst.ResetScene();
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                                Application.Quit();
        #endif
    }
}
