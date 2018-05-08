using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

    public int coin = 0;

    public int level = 1;

    public GameObject panelPause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BtnStartOnclick()
    {
        GameState.Instance.gamestate = STATE.PLAYING;
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.GamePlay);
    }

    public void BtnPauseOnClick()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void BtnResumeOnClick()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
    }

    public void BtnGotoHomeOnClick()
    {
        GameState.Instance.gamestate = STATE.NONE;
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.Home);
    }

}
