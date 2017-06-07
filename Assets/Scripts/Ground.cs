using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    SpriteRenderer MainSpriteRenderer;
    PolygonCollider2D pc2d;
    Texture2D change_image = null;
    private float timeleft;

    public void Explosion(Vector3 pos)
    {
        //Debug.Log(pos); //pos of attached bullet
        float bulletx = pos[0] * 100 + 960; //magic number (display size), 0-1920
        float bullety = pos[1] * 100;//0-540

        Texture2D image = Resources.Load("Ground") as Texture2D;
        //Texture2D image = Resources.Load("test") as Texture2D;
        Color[] pixels;
        if (change_image == null)
        {
            pixels = image.GetPixels();
        }
        else
        {
            pixels = change_image.GetPixels();
        }
        Color[] change_pixels = new Color[pixels.Length];
        for (int i = 0; i < pixels.Length; i++)
        {
            int h = i / 1920 - 540;//ground:540, !=depth
            int w = i % 1920;

            Color pixel = pixels[i];
            //Color change_pixel = new Color(pixel.r, pixel.g, pixel.b, pixel.a);
            //change_pixels.SetValue(change_pixel, i);

            if ((bulletx-w)*(bulletx-w) + (bullety-h)*(bullety-h) < 10000)
            {
                Color change_pixel = new Color(pixel.r, pixel.g, pixel.b, 0);
                change_pixels.SetValue(change_pixel, i);
            }
            else
            {
                Color change_pixel = new Color(pixel.r, pixel.g, pixel.b, pixel.a);
                change_pixels.SetValue(change_pixel, i);
            }

            
            

        }

        change_image = new Texture2D(image.width, image.height, TextureFormat.RGBA32, false);
        change_image.filterMode = FilterMode.Point;
        change_image.SetPixels(change_pixels);
        change_image.Apply();

        MainSpriteRenderer.sprite = Sprite.Create(change_image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
        Object.Destroy(pc2d);
        pc2d = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;

    }

    // Use this for initialization
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        pc2d = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;


    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            Explosion();

            timeleft = 2f;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explosion(collision.transform.position);
        Destroy(collision.gameObject);
    }
}

