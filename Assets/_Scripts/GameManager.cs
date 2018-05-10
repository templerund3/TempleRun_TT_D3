﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;

        PlayerPrefs.DeleteAll();
        for (int i = 1; i <= 24; i++)
        {
            if (i == 1)
            {
                if (!PlayerPrefs.HasKey(ContsInGame.STARLEVEL + i))
                {
                    PlayerPrefs.SetString(ContsInGame.STARLEVEL + i, "0");
                }
            }
            else
            {
                if (!PlayerPrefs.HasKey(ContsInGame.STARLEVEL + i))
                {
                    PlayerPrefs.SetString(ContsInGame.STARLEVEL + i, "");
                }
            }
        }

        PlayerPrefs.SetInt(ContsInGame.COIN, 900);
    }

    public int coin = 0;

    public int level = 1;

    public GameObject panelPause;
    public GameObject panelReady;
    public GameObject panelGameOver;
    public GameObject panelGameWin;
    public GameObject player;
    public GameObject objPlayer;
    public Transform sceneGamePlay;

    public Transform mapObj;


    public void BtnSelectLevelOnclick()
    {
        HidePanelAll();
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.SelectLevel);
    }

    public void BtnPauseOnClick()
    {
        Time.timeScale = 0.0f;
        GameState.Instance.gamestate = STATE.NONE;
        panelPause.SetActive(true);
        
    }

    public void BtnResumeOnClick()
    {
        HidePanelAll();
        GameState.Instance.gamestate = STATE.PLAYING;
    }

    public void BtnHomeOnClick()
    {
        HidePanelAll();
        GameState.Instance.gamestate = STATE.NONE;
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.Home);
    }

    public void LoadLevel(float timeLoad,int mLevel)
    {
        ResetLevel();
        GameObject mapLevelCurrent = Resources.Load("Map" + mLevel) as GameObject;
        Instantiate(mapLevelCurrent, mapObj);
        mapObj.position = Vector3.zero;
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.GamePlay,()=> StartCoroutine(StartLevel(timeLoad, mLevel)));
        
    }

    public IEnumerator StartLevel(float timeLoad, int mLevel)
    {
        level = mLevel; 
        panelReady.SetActive(true);
        yield return new WaitForSeconds(3f);
        objPlayer = Instantiate(player, sceneGamePlay) as GameObject;
        objPlayer.GetComponent<Animator>().SetFloat("Index", (float)PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT));
        panelReady.SetActive(false);
        GameState.Instance.gamestate = STATE.PLAYING;
        
    }

    public void BtnReplayOnclick()
    {
        ResetLevel();
        HidePanelAll();
        LoadLevel(3f,level);
    }

    public void BtnNextLevelOnclick()
    {
        ResetLevel();
        HidePanelAll();
        LoadLevel(3f, level+1);
    }

    public void ResetLevel()
    {
        coin = 0;
        Time.timeScale = 1f;
        if (objPlayer != null)
        {
            Destroy(objPlayer);
        }
        foreach (Transform childTransform in mapObj.transform)
        {
            Destroy(childTransform.gameObject);
        }
    }

    public void HidePanelAll()
    {
        Time.timeScale = 1.0f;
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGameWin.SetActive(false);
        panelReady.SetActive(false);
    }

}
