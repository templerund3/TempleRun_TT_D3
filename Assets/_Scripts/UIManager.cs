using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Menu")]
    //public Text txtCoinPlayer;
    public GameObject panelShop;

    [Header("UI GamePlay")]
    public Text txtCoinValue;
    public Text txtLevelValue;

    

    private void Update()
    {
        //txtCoinPlayer.text = PlayerPrefs.GetInt("Coin").ToString();
        txtCoinValue.text = GameManager.Instance.coin.ToString();
        txtLevelValue.text = ContsInGame.LEVEL_TEXT + " " + GameManager.Instance.level.ToString();
    }

    /// <summary>
    /// Hàm khi nhấn button Play
    /// </summary>
    public void btnPlay()
    {

    }

    /// <summary>
    /// Hàm khi nhấn button Shop
    /// </summary>
    public void btnShop()
    {
        MusicController.Instance.PlayUIClick();
        if (panelShop != null)
        {
            panelShop.SetActive(true);
        }      
    }

    /// <summary>
    /// Hàm khi nhấn button Share
    /// </summary>
    public void btnShare()
    {
        MusicController.Instance.PlayUIClick();
        AndroidNativeFunctions.ShareText("Hi ! I'am DatDz. Ahihi !!!", "Subject", "RoboFlight");
    }

    public void btnShareScreenShot()
    {
        MusicController.Instance.PlayUIClick();
        ShareImage.Instance.ButtonShare();
    }

    /// <summary>
    /// Hàm khi nhấn button LeaderBoard
    /// </summary>
    public void btnLeaderBoard()
    {
        MusicController.Instance.PlayUIClick();
    }

    /// <summary>
    /// Hàm khi nhấn button Music
    /// </summary>
    public void btnMusic()
    {
        MusicController.Instance.OnClickButton();
    }

    public void btnClosePanel(GameObject g)
    {
        MusicController.Instance.PlayUIClick();
        g.SetActive(false);
    }

    public void btnPlayAgain()
    {

    }

    public void btnPlayNext()
    {

    }

    public void btnBackToMenu()
    {

    }
}
