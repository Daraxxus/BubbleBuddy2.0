using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDied : MonoBehaviour {
	public Animator bubble;
    GoogleAds ads;
	// Use this for initialization
	void Start () {
        ads = FindObjectOfType<GoogleAds>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Spike"))
		{
			bubble.SetInteger("State", 1);
<<<<<<< HEAD
            ads.GameOver();
=======
			Handheld.Vibrate();
>>>>>>> ecac29f6faca6d28bc6ccc34c2e49c9980877c6f
		}
	}

    
}
