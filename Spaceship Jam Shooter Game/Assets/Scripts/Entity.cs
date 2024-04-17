using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Base class for player and enemies

    public float Speed;
    public Vector2 Direction;

    public virtual void Movement()
    {

    }
}
