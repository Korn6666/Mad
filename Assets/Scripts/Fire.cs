using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    // private float timeBtwShots;
    private Vector2 direction;
    // private float force = 10.0f;
    private Rigidbody2D Rbd2D;

    // public int startTimeBtwShots = 2;

    public GameObject projectile;
    private GameObject projectile2;


    // public Transform target;
    // public float DetectionRange = 10;


    // public float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        // timeBtwShots = startTimeBtwShots;
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        //target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector2.Distance(transform.position, target.position) < DetectionRange)
        // {
        //     if (timeBtwShots <= 0)
        //     {
        //         direction = target.position - transform.position;       
        //         Vector3 offset = new Vector3(0,0.7f,0);
        //         projectile2 = Instantiate(projectile, transform.position + offset, Quaternion.identity);
        //         Rbd2D = projectile2.GetComponent<Rigidbody2D>();
        //         direction = target.position - (transform.position + offset);       
        //         Rbd2D.velocity = direction;

        //         //Rbd2D.AddForce(direction * force);

        //         timeBtwShots = startTimeBtwShots;
        //     }
        //     else
        //     {
        //         timeBtwShots -= Time.deltaTime;

        //     }
        // }
    }

    public void Launch_Fire(Vector3 target, Vector3 launcher)
    {
        direction = target - launcher;
        Vector3 offset = new Vector3(0,2f,0);
        projectile2 = Instantiate(projectile, launcher + offset, Quaternion.identity);
        Rbd2D = projectile2.GetComponent<Rigidbody2D>();
        direction = target - (launcher + offset);       
        Rbd2D.velocity = direction;
    }
}