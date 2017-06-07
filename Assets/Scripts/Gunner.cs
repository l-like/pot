using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{

    public float speed = 2;
    public GameObject bullet;

    public GameObject canon;
    private float timeleft;

    public void Shot(Transform origin)
    {
        var rot = origin.rotation;
        var pos = origin.position;
        Instantiate(bullet, pos, rot);
    }

    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // Use this for initialization
    /*
    IEnumerator Start () {

        while (true)
        {

            Shot(transform);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
	    }
    */

    void Start()
    {
        canon = transform.Find("Gun").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, 0).normalized;

        Move(direction);

        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Shot(canon.transform);
                timeleft = 0.5f;
            }
        }
    }
}
