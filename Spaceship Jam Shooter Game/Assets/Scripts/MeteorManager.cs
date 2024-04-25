using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ManagerState { Active, Inactive }

public class MeteorManager : MonoBehaviour
{
    //Determines how frequent the asteroids spawn
    public int SpawnInterval;
    //Determines the state of the manager
    public ManagerState State;
    //Has the meteor object on hand
    public GameObject Meteor;

    //Current Timer before spawning.
    private int currentSpawnInterval;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        currentSpawnInterval = 0;
        State = ManagerState.Active;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //Program Defensively. Ensures SpawnInterval doesn't go below zero.
        if (SpawnInterval < 0)
        {
            SpawnInterval = 0;
        }


        if (State == ManagerState.Active) 
        {
            currentSpawnInterval--;
            if (currentSpawnInterval <= 0) 
            {
                SpawnMeteor();
                currentSpawnInterval = SpawnInterval;
            }
        }
        else if (State == ManagerState.Inactive)
        {
            currentSpawnInterval = SpawnInterval;
        }
    }


    /// <summary>
    /// Spawns an asteroid randomly
    /// </summary>
    void SpawnMeteor()
    {
        //Randomly Select a location based outside of screen bounds

        Vector2 myPos = RandomlyCreateLocation();
        Meteor m = GameObject.Instantiate(Meteor, myPos, Quaternion.identity).GetComponent<Meteor>();
    }

    

    Vector2 RandomlyCreateLocation()
    {
        Vector2 Location = new Vector2(0, 0);
        int Direction = Random.Range(0, 4);
        switch(Direction)
        {
            case 0: //Spawn on left side of screen
                Location.x = screenBounds.x * -1.1f;
                Location.y = Random.Range(10, screenBounds.y - 10);
                break;
            case 1: //Spawn on Right side of Screen
                Location.x = screenBounds.x * 1.1f;
                Location.y = Random.Range(10, screenBounds.y - 10);
                break;
            case 2: //Spawn on top of screen
                Location.y = screenBounds.y * -1.1f;
                Location.x = Random.Range(10, screenBounds.x - 10);
                break;
            case 3: //Spawn on bottom of screen
                Location.y = screenBounds.y * 1.1f;
                Location.x = Random.Range(10, screenBounds.x - 10);
                break;
        }
        return Location;
    }
}
