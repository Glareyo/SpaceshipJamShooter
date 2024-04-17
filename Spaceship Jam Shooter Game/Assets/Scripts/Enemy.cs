using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    Camera cam;
    public int health = 3;
    public Transform weaponMuzzle;
    public GameObject bullet;
    private float shootTime;
    public float fireRate = 3000f;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        Speed = 5;

        Direction.x = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Movement();
        Fire();
    }

    public override void Movement()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
       
        if (screenPos.x <= 0) 
        {
            Direction.x = 1;
        }
        else if(screenPos.x >= Screen.width)
        {
            Direction.x = -1;
        }
        

        transform.Translate(Direction * Speed * Time.deltaTime);
    }
    public bool Fire()
    {
        if (Time.time > shootTime)
        {
            shootTime = Time.time + fireRate / 1000;
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); 
            Bullet projectile = GameObject.Instantiate(bullet, myPos, Quaternion.identity).GetComponent<Bullet>();
            projectile.rb.velocity = Vector2.left * projectile.speed;
            return true;
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        ScoreManager.Score++;
    }

}
