using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDied : MonoBehaviour {
	public Animator bubble;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Spike"))
		{
			bubble.SetInteger("State", 1);
			Handheld.Vibrate();
            AdManager.Instance.ShowVideo();
		}
	}

    
}
