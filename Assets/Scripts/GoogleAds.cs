using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAds : MonoBehaviour {

    InterstitialAd interstitial;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RequestBanner()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
            string adUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
        .Build();
        //AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void GameOver()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
}
