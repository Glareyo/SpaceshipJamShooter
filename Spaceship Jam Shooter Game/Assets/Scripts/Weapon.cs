using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float delayShots = 1f;
    private bool canShoot = true;

    private PlayerControls controls;

    public AudioSource audioSource;
    public AudioClip shootingClip;


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
        if (canShoot)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    //Delay between shots
    private IEnumerator ShootWithDelay()
    {
        canShoot = false;
        audioSource.PlayOneShot(shootingClip);
        Bullet projectile = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
        projectile.rb.velocity = Vector2.up * projectile.speed;

        yield return new WaitForSeconds(delayShots);
        canShoot = true;
    }
}
