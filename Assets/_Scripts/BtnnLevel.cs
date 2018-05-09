using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnnLevel : MonoBehaviour {

    public int Level;
    private bool isStart;
    public Text txtLevel;
    public Image imgBtnLevel;
    public Image imgStar;

    public Sprite[] sprBtnLevel;
    public Sprite[] sprStar;

    public void Start()
    {
        isStart = true;
    }

    private void OnEnable()
    {
        if (isStart)
            InitLevel();
    }

    public void InitLevel()
    {
        if (PlayerPrefs.GetString("StarLevel" + Level) != "")
        {
            imgBtnLevel.sprite = sprBtnLevel[1];
            txtLevel.gameObject.SetActive(true);
            imgStar.gameObject.SetActive(true);
            txtLevel.text = Level.ToString();
            imgStar.sprite = sprStar[int.Parse(PlayerPrefs.GetString("StarLevel" + Level))];
            gameObject.GetComponent<Button>().onClick.AddListener(() => BtnLevelOnclick());

        }
    }

    public void BtnLevelOnclick()
    {
        if (PlayerPrefs.GetString("StarLevel" + Level) != "")
        {
            GameManager.Instance.LoadLevel(4f, Level);
        }
    }

}
