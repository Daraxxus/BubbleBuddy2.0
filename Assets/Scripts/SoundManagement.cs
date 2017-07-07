using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManagement : MonoBehaviour {

    public AudioClip firstPhaseBGM;
    public AudioClip secondPhaseBGM;
    public AudioClip deathSound;
    public AudioSource audio;
	public Animator bubble;
	bool bubbleAlive = true;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(BGM());
	}
	
	// Update is called once per frame
	void Update () {
		BubbleDied();
	}

    IEnumerator BGM()
    {
        audio.clip = firstPhaseBGM;
        audio.Play();
        yield return new WaitForSeconds(25);
        audio.clip = secondPhaseBGM;
        audio.Play();
    }

    private void BubbleDied()
    {
        if (bubble.GetInteger("State") == 1 && bubbleAlive)
        {
			StartCoroutine(Death());
			bubbleAlive = false;
		}
    }

	IEnumerator Death()
	{
		audio.Stop();
		audio.PlayOneShot(deathSound, 1f) ;
		yield return new WaitForSeconds(0.085f);
		Time.timeScale = 0f;
		
	}
}
