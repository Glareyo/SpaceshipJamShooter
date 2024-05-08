using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Enable(); //enable here for using an event
        controls.Player.Shoot.performed += Shoot; //subscribe
    }

    private void OnDisable()
    {
        controls.Player.Shoot.performed -= Shoot; //unsubscribe
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }*/
    }

    /*
    void Shoot()
    {
        Bullet projectile = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
        projectile.rb.velocity = Vector2.up * projectile.speed;
    }*/

    //switch to use event instead of checking update to save some performance
    private void Shoot(InputAction.CallbackContext callback)
    {
        Bullet projectile = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
        projectile.rb.velocity = Vector2.up * projectile.speed;
        projectile.PlayerIsShooter = true;
    }
}
