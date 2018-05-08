using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panelShop;

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
        AndroidNativeFunctions.ShareText("Hello World", "Subject", "Share Text");
    }

    /// <summary>
    /// Hàm khi nhấn button LeaderBoard
    /// </summary>
    public void btnLeaderBoard()
    {

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
        g.SetActive(false);
    }
}
