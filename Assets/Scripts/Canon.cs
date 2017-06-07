using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public int power = 50;
    GameObject powerGUI;
    public GUIText t;

	// Use this for initialization
	void Start () {
        powerGUI = GameObject.Find("powerGUI");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 angle = transform.eulerAngles;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            angle.z += 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            angle.z -= 1;
        }
        
        transform.eulerAngles = angle;

        if (Input.GetKey(KeyCode.Q) && power < 100)
        {
            power += 1;
        }
        else if (Input.GetKey(KeyCode.E) && power > 20)
        {
            power -= 1;
        }
        if (t)
        {
            t.text = "POW: " + power;
        }

	}
}
