using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManagement : MonoBehaviour {

    public AudioClip firstPhaseBGM;
    public AudioClip secondPhaseBGM;
    public AudioClip deathSound;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(BGM());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator BGM()
    {
        audio.clip = firstPhaseBGM;
        audio.Play();
        yield return new WaitForSeconds(25);
        audio.clip = secondPhaseBGM;
        audio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            audio.clip = deathSound;
            audio.Play();
        }
    }
}
