using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    Camera cam;

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

}
