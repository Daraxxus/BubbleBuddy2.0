using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesSwitch : MonoBehaviour {

    public Slider masterSlider;
    public Slider musicSlider;
    public AudioSource music;

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
        SceneManager.LoadScene("bubblegame");
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
}
