using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	public GameObject background;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1f)
		{
			if (background.transform.position.y > -4.8f) {
				background.transform.Translate(Vector2.down * speed);
			}
		}
	}
}
