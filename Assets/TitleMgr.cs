using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject controlsPanel;
    public GameObject creditsPanel;
    public List<Transform> wayPointList;
    public static TitleMgr inst;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //reset scene completely
        //SceneManager.LoadScene("main");
        StartCoroutine(LoadMainAsyc());
    }
    IEnumerator LoadMainAsyc()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while(!asyncLoad.isDone)
            yield return null;
    }
    public void DisplayControlsPanel()
    {
        titlePanel.SetActive(!titlePanel.activeSelf);
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }
    public void DisplayCreditsPanel()
    {
        titlePanel.SetActive(!titlePanel.activeSelf);
        creditsPanel.SetActive(!creditsPanel.activeSelf);
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
