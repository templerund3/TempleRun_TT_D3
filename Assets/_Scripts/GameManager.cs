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
        if (!PlayerPrefs.HasKey(ContsInGame.COIN))
        {
            PlayerPrefs.SetInt(ContsInGame.COIN, 500);
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
    public DeadzoneCamera mainCamera;


    public void BtnSelectLevelOnclick()
    {
        mainCamera.transform.position = new Vector3(0f, 0f, -10f);
        HidePanelAll();
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.SelectLevel);
    }

    public void BtnPauseOnClick()
    {
        if (GameState.Instance.gamestate == STATE.PLAYING)
        {
            Time.timeScale = 0.0f;
            GameState.Instance.gamestate = STATE.NONE;
            panelPause.SetActive(true);
        }
        
    }

    public void BtnResumeOnClick()
    {
        HidePanelAll();
        GameState.Instance.gamestate = STATE.PLAYING;
    }

    public void BtnHomeOnClick()
    {
        mainCamera.transform.position = new Vector3(0f, 0f, -10f);
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
        mainCamera.target = objPlayer.GetComponent<SpriteRenderer>();
        Vector3 _smoothPos = objPlayer.transform.position;
        _smoothPos.z = -10f;
        mainCamera.smoothPos = _smoothPos;
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

    public Transform mapEndless;
    public GameObject longHouse;
    public GameObject[] arrayItem;
    public Vector3 posObjMapOld;
    public Vector3 posObjHouse = new Vector3(5f, -5f, 0f);
    Vector2 randomMap;

    public void ModeEndlessRun()
    {
        if(mapObj.transform.position.x <= (posObjMapOld.x - 5f))
        {
            for (int i = 0; i < 8; i+=2)
            {
                Vector2 randomMap = new Vector2(Random.Range(0, 1), Random.Range(0, 3));
                if (randomMap.x == 1)
                {
                    Instantiate(longHouse, mapEndless).transform.position = posObjHouse;
                    posObjHouse += new Vector3(5f, 0f, 0f);
                    if (Random.Range(0, 1) == 1)
                    {
                        Instantiate(longHouse, mapEndless).transform.position = posObjHouse;
                        randomMap = new Vector2(1, Random.Range(0, 3));
                    }
                    else
                    {
                        randomMap = new Vector2(0, Random.Range(0, 3));
                        posObjHouse += new Vector3(5f, 0f, 0f);
                    }
                }
                else
                {
                    posObjHouse += new Vector3(5f, 0f, 0f);
                    Instantiate(longHouse, mapEndless).transform.position = posObjHouse;
                    posObjHouse += new Vector3(5f, 0f, 0f);
                }
            }
            
        }
    }

    public void InstantiatePlatformer(int index)
    {
        if (index == 1)
        {
            Instantiate(longHouse, mapEndless).transform.position = posObjHouse;
            posObjHouse += new Vector3(5f, 0f, 0f);
        }
        
    }

    public void InstantiateItem(int index)
    {
        Instantiate(arrayItem[index], mapEndless).transform.position = posObjHouse - new Vector3(-2.5f, -5f, 0f);
    }

}
