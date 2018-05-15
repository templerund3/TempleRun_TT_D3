using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads : MonoBehaviour 
{
    // code ads

	// code ads

    //[Header("Admob")]
    //private string ADMOB_idApp;
    //InterstitialAd interstitalAd;
    //BannerView bannerView;
    //public string idInter;
    //public string idBanner;
    //public string idUnityAds;
    //public string linkMoreGame;
    //bool isLoadAds = false;

    //public GameObject btnUnityAds;
    //public GameObject btnHint;

    //public static Ads Instance = new Ads();
    //void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        return;
    //    }
    //    Instance = this;
    //    DontDestroyOnLoad(this);
    //}

    //void Start()
    //{
    //    RequestBanner();
    //    RequestAd();
    //    ShowBanner();

    //    //Unity Ads
    //    Advertisement.Initialize(idUnityAds, false);
    //}

    //void FixedUpdate()
    //{
    //    if (PlayerPrefs.GetInt("Hint") <= 0)
    //    {
    //        if (!btnUnityAds.activeSelf)
    //            btnUnityAds.SetActive(true);

    //        if (btnHint.activeSelf)
    //            btnHint.SetActive(false);
    //    }
    //    else
    //    {
    //        if (btnUnityAds.activeSelf)
    //            btnUnityAds.SetActive(false);

    //        if (!btnHint.activeSelf)
    //            btnHint.SetActive(true);
    //    }
    //}

    //public void btnMoreGame()
    //{
    //    Application.OpenURL(linkMoreGame);
    //}

    //#region ===ADMOB===
    //public void RequestBanner()
    //{
    //    if (idBanner != null)
    //    {
    //        bannerView = new BannerView(idBanner, AdSize.SmartBanner, AdPosition.Bottom);
    //        AdRequest requestBanner = new AdRequest.Builder().Build();
    //        bannerView.LoadAd(requestBanner);
    //        Debug.Log("Load Banner");
    //    }
    //}

    //public void RequestAd()
    //{
    //    if (isLoadAds == false && idInter != null)
    //    {
    //        interstitalAd = new InterstitialAd(idInter);
    //        AdRequest requestInterAd = new AdRequest.Builder().Build();
    //        interstitalAd.LoadAd(requestInterAd);
    //        isLoadAds = true;
    //        Debug.Log("Load Ads");
    //    }
    //}

    //public void ShowBanner()
    //{
    //    if (bannerView != null)
    //    {
    //        bannerView.Show();
    //        Debug.Log("Show Banner");
    //    }
    //}

    //public void HideBanner()
    //{
    //    if (bannerView != null)
    //    {
    //        bannerView.Hide();
    //    }
    //}

    //public void ShowInterstitialAd()
    //{
    //    if (interstitalAd != null)
    //    {
    //        if (interstitalAd.IsLoaded())
    //        {
    //            interstitalAd.Show();

    //            isLoadAds = false;
    //            Debug.Log("Show Ads");
    //        }
    //    }
    //}



    //#endregion
}
