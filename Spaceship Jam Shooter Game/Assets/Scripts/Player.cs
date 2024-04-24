using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Jobs;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    private PlayerControls controls;
    private InputAction Move;
    private int health = 5;
    public Weapon weapon;
    Camera cam;
    private float DefaultSpeed;

    private void Awake()
    {
        controls = new PlayerControls();
        cam = Camera.main;
        
    }

    private void OnEnable()
    {
        Move = controls.Player.MoveDirection;
        Move.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        DefaultSpeed = Speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Movement();
    }

    //For the player to move around
    public override void Movement()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
        var move = Move.ReadValue<Vector2>();
       
        //Come back to edit
        if (screenPos.x <= 0 || screenPos.x >= Screen.width )
        {
            Direction.x = -move.x;            
        }
        else
        {
            Direction.x = move.x;

        }

        if (screenPos.y <= 0 || screenPos.y >= Screen.height)
        {
            Direction.y = -move.y;
        }
        else
        {
            Direction.y = move.y;
        }
        
        transform.Translate(Direction * Speed * Time.deltaTime);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        ScoreManager.Lives--;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
