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

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Enable(); //enable here for using an event
        controls.Player.Shoot.performed += Shoot; //subscribe
    }

    private void OnEnable()
    {
        Move = controls.Player.MoveDirection;
        Move.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
        controls.Player.Shoot.performed -= Shoot; //unsubscribe
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Movement();
    }

    //For the player to move around
    public override void Movement()
    {
        var move = Move.ReadValue<Vector2>();
        Direction.x = move.x; 
        Direction.y = move.y;

        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    //an event for the ship to shoot once 
    //TODO: have another class to handle
    private void Shoot(InputAction.CallbackContext callback)
    {
        Debug.Log("Shooting");
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
