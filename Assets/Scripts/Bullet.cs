using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 30;
    public float lifetime = 5;
    Canon canon;

	// Use this for initialization
	void Start ()
    {
        canon = GameObject.Find("Canon").GetComponent<Canon>();
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed * canon.power / 100;
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
