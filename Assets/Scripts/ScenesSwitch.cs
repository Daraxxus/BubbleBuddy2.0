using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using admob;

public class ScenesSwitch : MonoBehaviour {

    public Slider masterSlider;
    public Slider musicSlider;
    public AudioSource music;
	bool SignIn = false;
    public string bannerId;
    public string videoId;
    private string sceneName;

    // Use this for initialization
    void Start () {
        AudioSource music = gameObject.GetComponent<AudioSource>();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update () {
        Quit();
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void PlayGame()
	{
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			SceneManager.LoadScene("bubblegame");
            Admob.Instance().initAdmob(bannerId, videoId);
            Admob.Instance().loadInterstitial();
            Time.timeScale = 1;

            if (Social.localUser.authenticated)
            {
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_make_a_friend, 100.0f, (bool success) => { Debug.Log("Success"); });
            }
		}
		else
		{
			if (!PlayGamesPlatform.Instance.localUser.authenticated)
			{
				// Sign in with Play Game Services, showing the consent dialog
				// by setting the second parameter to isSilent=false.
				PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
			}
			else
			{
			}
		}
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_no_mans_land, 100.0f, (bool success) => { Debug.Log("Success"); });
        }
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && sceneName == "MainMenu")
        {
            Application.Quit();
        }
    }

    public void MasterVol()
    {
        AudioListener.volume = masterSlider.value;
    }

    public void MusicVol()
    {
        music.volume = musicSlider.value;
    }

	public void ShowAcheivements()
	{
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.ShowAchievementsUI();
		}
		else
		{
			Debug.Log("Cannot show Achievements, not logged in");
		}
	}	

	public static void SignInCallback(bool success)
	{
		if (success)
		{
			Debug.Log("(Lollygagger) Signed in!");
		}
		else
		{
			Debug.Log("(Lollygagger) Sign-in failed...");
		}
	}
}
