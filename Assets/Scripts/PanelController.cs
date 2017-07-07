using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {
    public GameObject panel;
    public Animator bubble;
	public GameObject m_Bubble;
	// Use this for initialization
	void Start () {
        //panel = this.GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        bubbleDied();
	}

    void bubbleDied ()
    {
        if (bubble.GetInteger("State") == 1)
        {
            panel.SetActive(true);
        }
    }
}
