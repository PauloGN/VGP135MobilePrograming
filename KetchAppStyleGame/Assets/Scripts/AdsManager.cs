using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{

    public static AdsManager instance;


    private InterstitialAd interstitialAd ;
    private AdsInitializer adsInitializer ;
    private BannerAd showBanner;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            interstitialAd = GetComponent<InterstitialAd>();
            adsInitializer = GetComponent<AdsInitializer>();
            showBanner = GetComponent<BannerAd>();
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ShowInterstitialAd()
    {
        interstitialAd.ShowAd();
    }


    public void ShowBanner()
    {
        showBanner.LoadBanner();
        showBanner.ShowBannerAd();
    }

    public void HideBanner()
    {
        showBanner.LoadBanner();
        showBanner.HideBannerAd();
    }


    public void ShowBunnerfor_x_Seconds()
    {
        ShowBanner();
        StartCoroutine(nameof(HideBunnerAfert_x_Seconds));
    }



    IEnumerator HideBunnerAfert_x_Seconds()
    {

        yield return new WaitForSeconds(15);//starts a counter internally in this case 15 seconds after the time it will execute the next line of code
        HideBanner();
    }




}
