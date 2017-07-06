using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour {

    private bool gyroEnabled;
    public Gyroscope gyro;

    // Use this for initialization
    void Start () {
        gyroEnabled = EnableGyro();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }

    private void OnApplicationQuit()
    {
        gyro.enabled = false;
    }
}
