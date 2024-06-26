using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using Random = UnityEngine.Random;

public enum MeteorState { Idle, MoveLeft, MoveRight, MoveUp, MoveDown }

public class Meteor : MonoBehaviour
{
    public MeteorState State;
    public int Damage;

    private float Speed = 5f;
    private int health = 1;
    private SpriteRenderer sprite;

    //Credit: Gursimar
    //Code copied from his bullet script
    private Vector2 screenBounds;

    Camera cam;
    [SerializeField]
    private Vector2 Direction;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        State = MeteorState.MoveRight;
        sprite = GetComponent<SpriteRenderer>();


        //Credit: Gursimar
        //Code copied from his bullet script
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        DetemineDirection();
    }

    void DetemineDirection()
    {
        //Spawned on right side of screen, go left
        if (transform.position.x > screenBounds.x)
        {
            State = MeteorState.MoveLeft;
        }
        //Spawned on left side of screen, go right
        if (transform.position.x < screenBounds.x * -1.0f)
        {
            State = MeteorState.MoveRight;
        }

        //*******************************************************
        // Buggy, Still trying to work on it.
        //*******************************************************
        //Spawned on top side of screen, go down
        if (transform.position.y < screenBounds.y * -1.0f)
        {
            State = MeteorState.MoveDown;
        }
        //Spawned on bottom side of screen, go up
        if (transform.position.y > screenBounds.y)
        {
            State = MeteorState.MoveUp;
        }
        //*******************************************************
        //*******************************************************
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case MeteorState.Idle:
                break;
            case MeteorState.MoveLeft:
                MovingMeteorLeft();
                break;
            case MeteorState.MoveRight:
                MovingMeteorRight();
                break;
            case MeteorState.MoveUp:
                MovingMeteorUp();
                break;
            case MeteorState.MoveDown:
                MovingMeteorDown();
                break;
        }
        transform.Translate(Direction * Speed * Time.deltaTime);
        
        RotateMeteor();
        KeepAsteroidOnScreen();
        //DestroyAsteroidOffScreen();
    }

    //******************************************************************************
    //Makes the asteroid move in a certain direction
    //******************************************************************************
    void MovingMeteorRight()
    {
        //transform.Translate(Speed * Time.deltaTime, 0, 0);
        Direction.x = 1;
        sprite.flipX = false;
    }
    void MovingMeteorLeft()
    {
        //transform.Translate(-Speed * Time.deltaTime, 0, 0);
        Direction.x = -1;
        sprite.flipX = true;
    }
    void MovingMeteorUp()
    {
        //transform.Translate(0, Speed * Time.deltaTime, 0);
        Direction.y = 1;
    }
    void MovingMeteorDown()
    {
        //transform.Translate(0, -Speed * Time.deltaTime, 0);
        Direction.y = -1;
    }
    //******************************************************************************
    //******************************************************************************

    void RotateMeteor()
    {
        //transform.Rotate.Z +=1;
    }


    /// <summary>
    /// Checks collision to see if it collides with the player or enemy.
    /// </summary>
    /// <param name="hitCollide">Colliding Target</param>
    void OnTriggerEnter2D(Collider2D hitCollide)
    {
        //***************************************************
        //Commented out for now.
        /*Enemy enemy = hitCollide.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }*/
        //***************************************************

        Player player = hitCollide.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Destroys asteroids if they are off screen
    /// </summary>
    /// Credit: Gusimar
    /// Used code from his Bullet Object
    void DestroyAsteroidOffScreen()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > cam.pixelWidth || screenPosition.y < 0 || screenPosition.y > cam.pixelHeight)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Keeps the asteroid on screen
    /// </summary>
    void KeepAsteroidOnScreen()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);

        //Evy: Adjusted the condition to check based on the position within the camera
        //Asteroid off screen to the right.
        if (screenPos.x >= Screen.width) //State cannot be MoveRight //(transform.position.x >= 8f)
        {
            RandomizeAsteroidMovement(2, MeteorState.MoveLeft);
            //State = MeteorState.MoveLeft;
        }
        //Asteroid off Screen to the left.
        if (screenPos.x <= 0) //(transform.position.x <= -8f)
        {
            //State = MeteorState.MoveRight;
            RandomizeAsteroidMovement(1, MeteorState.MoveRight);
        }
        //Asteroid off screen at the top.
        if (screenPos.y >= Screen.height)//(transform.position.y >= 8f)
        {
            State = MeteorState.MoveDown;
        }
        //Asteroid off screen at the bottom.
        if ((screenPos.y <= 0))//(transform.position.y <= -8f)
        {
            State = MeteorState.MoveUp;
        }
        
    }

    /// <summary>
    /// This is to randomize the astroid to move around the screen. This first gets a random number and
    /// sets it as the state. If the random number is the same as the direction it was currently going, 
    /// it just sets the opposite direction. This is to ensure they don't get stuck or push out of the 
    /// screen.
    /// </summary>
    /// <param name="stateValue"></param>
    /// <param name="setNextState"></param>
    private void RandomizeAsteroidMovement(int stateValue, MeteorState setNextState)
    {
        int setState = Random.Range(1, 5);
        if (setState == stateValue)
        {
            State = setNextState;
        }
        else
        {
            State = (MeteorState)setState;
        }
    }

    /// <summary>
    /// Asteroid takes damage
    /// </summary>
    /// <param name="damage">Amount of Damage Recieved</param>
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroys the asteroid and increases the score.
    /// </summary>
    public void Die()
    {
        Destroy(gameObject);
        ScoreManager.Score++;
        ScoreManager.MeteorsDestroyed++;
    }
}
