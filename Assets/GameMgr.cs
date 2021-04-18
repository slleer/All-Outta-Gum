using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    // Start is called before the first frame update
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
        Player.inst.score = 0;
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
