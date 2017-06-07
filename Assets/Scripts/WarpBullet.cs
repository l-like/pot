using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBullet : MonoBehaviour
{

    public int speed = 30;
    public float lifetime = 5;
    Canon canon;
    GameObject tank;

    // Use this for initialization
    void Start()
    {
        canon = GameObject.Find("Canon").GetComponent<Canon>();
        tank = GameObject.Find("Tank");
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed * canon.power / 100;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rot = tank.transform.rotation;
        Debug.Log(collision.transform.position[0]);
        tank.transform.position = collision.transform.position + new Vector3(0,0.2f,0);
        tank.transform.rotation = rot;
        
    }

}
