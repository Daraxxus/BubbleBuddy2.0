using GooglePlayGames;
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
            if (Social.localUser.authenticated)
            {
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_pop_goes_the_weasel, 100.0f, (bool success) => { Debug.Log("Success"); });

                if (SpikeGeneration.score == 15)
                {
                    PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_up_up_and_away, 100.0f, (bool success) => { Debug.Log("Success"); });
                }
            }
            AdManager.Instance.ShowVideo();
		}
	}

    
}
