using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.EventSystems;

public class GooglePlayController : MonoBehaviour {
	public GameObject achButton;
	// Use this for initialization
	void Start () {
		GameObject startButton = GameObject.Find("PlayBtn");
		EventSystem.current.firstSelectedGameObject = startButton;

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

		// Enable debugging output (recommended)
		PlayGamesPlatform.DebugLogEnabled = true;

		// Initialize and activate the platform
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();
	}
	
	// Update is called once per frame
	void Update () {
		achButton.SetActive(Social.localUser.authenticated);
	}

    public void achievementLoad()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            PlayGamesPlatform.Instance.Authenticate(ScenesSwitch.SignInCallback, false);
        }
    }
}
