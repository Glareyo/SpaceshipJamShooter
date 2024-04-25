using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float Speed = 5f;
    bool move = true;
    private int health = 1;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            MovingMeteorRight();
        }
        if (!move)
        {
            MovingMeteorLeft();
        }

        if (transform.position.x >= 8f)
        {
            move = false;
            sprite.flipX = true;
        }

        if (transform.position.x <= -8f)
        {
            move = true;
            sprite.flipX = false;
        }
    }

    void MovingMeteorRight()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }

    void MovingMeteorLeft()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        ScoreManager.Score++;
    }
}
