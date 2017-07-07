using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeGeneration : MonoBehaviour {
	List<GameObject> Spikes = new List<GameObject>();
	public GameObject m_Spike;
	public Transform SpikeStartPos;
	public Transform SpikeStartPos2;
	public Animator bubble;
	public int score = 0;
	private int nextScoreTime;
	private int scorePeriod = 2;
	private int scoreAmount = 1;
	private int checkPoint = 0;
	private float speed = -0.1f;
	public Text text;
	// Use this for initialization
	void Start () {
		NewSpike();
		SpikeStartPos2.Rotate(new Vector3(0, 180, 0));
	}

	
	// Update is called once per frame
	void Update ()
	{
		BubbleDead();
		if (Time.timeScale == 1f)
		{
			for (int x = 0; x < Spikes.Count; x++)
			{
				Spikes[x].transform.position = new Vector2(Spikes[x].transform.position.x, Spikes[x].transform.position.y + speed);
				if (Spikes[x].transform.position.y < -5.5f)
				{
					Destroy(Spikes[x]);
					Spikes.RemoveAt(x);
					NewSpike();
				}
			}

			if ((Time.time > nextScoreTime))
			{
				score = score + scoreAmount;
				nextScoreTime += scorePeriod;
				Debug.Log(score);
			}

			if (Spikes.Count < 5)
			{
				if (score - checkPoint == 5)
				{
					NewSpike();
					checkPoint = score;
				}
			}

			if (speed > -0.15f)
			{
				if (score % 25 == 1)
				{
					speed = speed - 0.001f;
				}
			}
		}
	}
	

	private void NewSpike() {
		GameObject newSpike;
		int Side = Random.Range (1, 10);
		if (Side % 2 == 1) {
			newSpike = Instantiate (m_Spike, SpikeStartPos);
		} else {
			newSpike = Instantiate (m_Spike, SpikeStartPos2);
		}	
		Spikes.Add(newSpike);
	}

	private void BubbleDead()
	{
		if (bubble.GetInteger("State")==1)
		{
			text.text = "Your Score: " + score;
		}
	}
}
