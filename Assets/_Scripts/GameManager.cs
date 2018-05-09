using System.Collections;
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
                if (!PlayerPrefs.HasKey("StarLevel" + i))
                {
                    PlayerPrefs.SetString("StarLevel" + i, "0");
                }
            }
            else
            {
                if (!PlayerPrefs.HasKey("StarLevel" + i))
                {
                    PlayerPrefs.SetString("StarLevel" + i, "");
                }
            }
        }
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


    public void BtnStartOnclick()
    {
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.SelectLevel);
    }

    public void BtnPauseOnClick()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void BtnResumeOnClick()
    {
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGameWin.SetActive(false);
        Time.timeScale = 1f;
        panelPause.SetActive(false);
    }

    public void BtnGotoHomeOnClick()
    {
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGameWin.SetActive(false);
        GameState.Instance.gamestate = STATE.NONE;
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.Home);
    }

    public void LoadLevel(float index,int _level)
    {
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.GamePlay,()=> StartCoroutine(StartLevel(index, _level)));
        
    }

    public IEnumerator StartLevel(float _a, int _level)
    {
        level = _level;
        GameObject mapLevelCurrent = Resources.Load("Map" + _level) as GameObject;
        if (mapObj.childCount > 0)
        {
            Destroy(mapObj.GetChild(0).gameObject);
        }
        Instantiate(mapLevelCurrent, mapObj);
        panelReady.SetActive(true);
        yield return new WaitForSeconds(3f);
        mapObj.position = Vector3.zero;
        objPlayer = Instantiate(player, sceneGamePlay) as GameObject;
        panelReady.SetActive(false);
        GameState.Instance.gamestate = STATE.PLAYING;
        
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGameWin.SetActive(false);
        panelReady.SetActive(false);
        LoadLevel(3f,level);
    }

}
