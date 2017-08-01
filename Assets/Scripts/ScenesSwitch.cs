using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class ScenesSwitch : MonoBehaviour {

    public Slider masterSlider;
    public Slider musicSlider;
    public AudioSource music;
	bool SignIn = false;

    // Use this for initialization
    void Start () {
        AudioSource music = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void PlayGame()
	{
		if (SignIn)
		{
			SceneManager.LoadScene("bubblegame");
			Time.timeScale = 1;
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
				// Sign out of play games
				PlayGamesPlatform.Instance.SignOut();
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
    }

    public void Quit()
    {
        Application.Quit();
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

	public void SignInCallback(bool success)
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
