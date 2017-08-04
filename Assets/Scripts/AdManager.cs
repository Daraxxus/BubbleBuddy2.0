using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdManager : MonoBehaviour {

	public static AdManager Instance { get; set; }

    public string bannerId;
    public string videoId;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
#if UNITY_EDITOR
#elif UNITY_ANDROID
            Admob.Instance().initAdmob(bannerId, videoId);
            Admob.Instance().loadInterstitial();
#endif
    }

    public void ShowBannner()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play ads from EDITOR");
        #elif UNITY_ANDROID
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 20);
        #endif
    }

    public void ShowVideo()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play ads from EDITOR");
#elif UNITY_ANDROID
            if (Admob.Instance().isInterstitialReady())
            {
                Admob.Instance().showInterstitial();
            }
#endif
    }

    public void RemoveBannner()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play ads from EDITOR");
#elif UNITY_ANDROID
        Admob.Instance().removeBanner("defaultBanner");
#endif
    }
}
