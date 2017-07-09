using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsAnimFinish : MonoBehaviour {

    public string animName;
    public string lvlName;
    public Animator animControl;
    public Animation anim;

	// Use this for initialization
	void Start () {
        animControl = gameObject.GetComponent<Animator>();
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        animControl.Play(animName);
    }

    public void LoadAfterAnim()
    {
        SceneManager.LoadSceneAsync(lvlName);
    }
}
