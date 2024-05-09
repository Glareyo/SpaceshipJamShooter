using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy bullets when they go off screen script: https://www.youtube.com/watch?v=MMPuDPcihAE&t=335s

public class Bullet : MonoBehaviour
{
    private bool playerIsShooter;
    public bool PlayerIsShooter { set { playerIsShooter = value; } }


    public float speed = 20f;
    public int damage = 1;
    Camera cam;
    public Rigidbody2D rb;
    public Enemy enemy;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        cam = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D hitCollide)
    {
        if (playerIsShooter)
        {
            Enemy enemy = hitCollide.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            Destroy(gameObject);
            }
        }
        else
        {
            Player player = hitCollide.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            Destroy(gameObject);
            }
        }

        

        Meteor meteor = hitCollide.GetComponent<Meteor>();
        if (meteor != null)
        {
            meteor.TakeDamage(damage);
            Destroy(gameObject);
        }

    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyWhenOffScreen();
    }

    // Destroys the Bullet when the bullet is off the camera view 
    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > cam.pixelWidth || screenPosition.y < 0 || screenPosition.y > cam.pixelHeight)
        {
            Destroy(this.gameObject);
        }
    }

}
