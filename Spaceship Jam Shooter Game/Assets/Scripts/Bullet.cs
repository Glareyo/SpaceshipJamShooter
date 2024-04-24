using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This reddit post helped figure out how to delete bullet when going off the main camera view: https://www.reddit.com/r/Unity2D/comments/rjgcti/objects_wont_delete_when_they_go_off_screen/
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public Enemy enemy;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void OnTriggerEnter2D(Collider2D hitCollide)
    {
        Enemy enemy = hitCollide.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Player player = hitCollide.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Meteor meteor = hitCollide.GetComponent<Meteor>();
        if (meteor != null) 
        {
            meteor.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * 1.2) 
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y > screenBounds.y * 1.2) 
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x < screenBounds.x * -1.2) 
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y < screenBounds.y * -1.2) 
        {
            Destroy(this.gameObject);
        }
    }
}
