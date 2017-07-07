using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject bubble;
    public int speed;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        ballMovement();
	}
    
    void ballMovement()
    {
        if (Input.gyro.enabled)
        {
            GyroMovement();
        }else
        {
            AcceleroMovement();
        }

		if ((Random.Range(1, 6)) % 2 == 1)
		{
			bubble.transform.Translate(new Vector2(0.001f, 0));
		}
		else
		{
			bubble.transform.Translate(new Vector2(-0.001f, 0));
		}
	}

    void GyroMovement() //Movement Through Gyroscopic Controls
    {
        float horizontalOffset = Input.gyro.gravity.x;
        bubble.transform.Translate(new Vector2(horizontalOffset, 0.0f) * speed * Time.deltaTime);
    }

    void AcceleroMovement() //Movement Through Accelerometer Controls
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            bubble.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            bubble.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        transform.Translate(Input.acceleration.x, 0, 0);
    }
}
