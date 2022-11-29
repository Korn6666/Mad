using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFromEnnemy : MonoBehaviour
{

    public Fire monscript;

    private float timeBtwShots;
    private Vector2 direction;
    private float force = 10.0f;
    private Rigidbody2D Rbd2D;

    public int startTimeBtwShots = 2;

    public GameObject projectile;
    private GameObject projectile2;


    private Transform target;
    public float DetectionRange = 10;


    public float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < DetectionRange)
        {
            if (timeBtwShots <= 0)
            {
                monscript.Launch_Fire(target.position, transform.position);
                //Rbd2D.AddForce(direction * force);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;

            }
        }

        
    }
}