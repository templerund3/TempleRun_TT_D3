using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public GameObject panelReady;
    public GameObject player;

    public BtnnLevel[] arrayLevels;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BtnStartOnclick()
    {
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.SelectLevel);
    }

    public void StartGame()
    {
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.GamePlay);
        StartCoroutine(ActionTimer(3f, () => panelReady.SetActive(true), () => PlayingGame()));
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

    public IEnumerator ActionTimer(float time, UnityAction actionBegin = null, UnityAction actionEnd = null)
    {
        if (actionBegin != null)
            actionBegin();
        yield return new WaitForSeconds(time);
        if (actionEnd != null)
            actionEnd();
    }

    public void PlayingGame()
    {
        GameState.Instance.gamestate = STATE.PLAYING;
        player.transform.position = new Vector3(-3.8f, 2f, 0f);
        panelReady.SetActive(false);
        player.SetActive(true);
        
    }
}
